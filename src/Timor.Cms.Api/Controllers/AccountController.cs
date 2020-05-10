using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Timor.Cms.Api.ViewModels.Account;
using Timor.Cms.Dto.Accounts;
using Timor.Cms.Infrastructure.Configuration;
using Timor.Cms.Infrastructure.Exceptions;
using Timor.Cms.Service.Users;

namespace Timor.Cms.Api.Controllers
{
    [Route("/api/v1/accounts")]
    public class AccountController : Controller
    {
        private readonly JwtOption _jwtOption;
        private readonly SigningCredentials _signingCredentials;
        private readonly UserService _userService;

        public AccountController(IOptionsMonitor<JwtOption> option, SigningCredentials signingCredentials, UserService userService)
        {
            _signingCredentials = signingCredentials;
            _userService = userService;
            _jwtOption = option.CurrentValue;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("token")]
        public async Task<LoginResult> Login([FromBody]LoginInput request)
        {
            var loginResult = await _userService.Login(request);

            if (loginResult.IsSuccess)
            {
                loginResult.Claims.Add(new Claim (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));
            }

            TimeSpan tokenExpirationDate = TimeSpan.FromDays(1);

            var jwtToken = GenerateJwtToken(loginResult.Claims.ToArray(), tokenExpirationDate);

            return new LoginResult
            {
                Token = jwtToken,
                TokenType = JwtBearerDefaults.AuthenticationScheme,
                ExpireInSeconds = tokenExpirationDate.TotalSeconds,
                UserName = loginResult.UserName
            };
        }

        private string GenerateJwtToken(Claim[] claims, TimeSpan tokenExpirationDate)
        {
            var now = DateTime.Now;

            var securityToken = new JwtSecurityToken(
                issuer: _jwtOption.Issuer,
                audience: _jwtOption.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(tokenExpirationDate),
                signingCredentials: _signingCredentials
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return jwtToken;
        }
    }
}
