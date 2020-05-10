using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Timor.Cms.Domains.Users;
using Timor.Cms.Dto.Accounts;
using Timor.Cms.Dto.Users;
using Timor.Cms.Infrastructure.Dependency;
using Timor.Cms.Infrastructure.Exceptions;
using Timor.Cms.Repository.MongoDb.Repositories.Users;

namespace Timor.Cms.Service.Users
{
    public class UserService : ITransient
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> CreateUser(CreateUserInput input)
        {
            var userDomain = _mapper.Map<User>(input);

            var passwordHash = new PasswordHasher<User>();

            var hashedPassword = passwordHash.HashPassword(userDomain, input.Password);

            userDomain.Password = hashedPassword;

            userDomain.SetNormalizedNames();

            await CheckUserDuplicate(userDomain);

            var userId = await _userRepository.CreateUser(userDomain);

            return userId;
        }

        public async Task<LoginOutput> Login(LoginInput input)
        {
            var user = await _userRepository.FindUserByUserName(input.LoginName);

            if (user == null)
            {
                user = await _userRepository.FindUserByPhoneNumber(input.LoginName);
            }

            if (user == null)
            {
                user = await _userRepository.FindUserByEmail(input.LoginName);
            }

            if (user == null)
            {
                throw new BusinessException("登录失败，用户不存在或密码错误！");
            }

            var verifyPasswordHash = new PasswordHasher<User>();

            var verifyResult = verifyPasswordHash.VerifyHashedPassword(user, user.Password, input.Password);

            if (verifyResult == PasswordVerificationResult.Failed)
            {
                throw new BusinessException("登录失败，用户不存在或密码错误！");
            }

            var loginResult = new LoginOutput
            {
                IsSuccess = verifyResult != PasswordVerificationResult.Failed,
                UserName = user.UserName,
                Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
                }
            };

            return loginResult;
        }

        private async Task CheckUserDuplicate(User user)
        {
            var duplicatedUser =
                await _userRepository.FindUserByUserName(user.NormalizedUserName);

            if (duplicatedUser != null)
                throw new BusinessException("用户名已存在");

            if (!string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                duplicatedUser = await _userRepository.FindUserByPhoneNumber(user.PhoneNumber);

                if (duplicatedUser != null)
                    throw new BusinessException("该手机号码已被占用");
            }

            if (!string.IsNullOrWhiteSpace(user.NormalizedEmail))
            {
                duplicatedUser = await _userRepository.FindUserByEmail(user.NormalizedEmail);

                if (duplicatedUser != null)
                    throw new BusinessException("该邮箱地址已被占用");
            }
        }
    }
}