using System.Text;
using Autofac;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Timor.Cms.Infrastructure;
using Timor.Cms.Infrastructure.Configuration;

namespace Timor.Cms.Api
{
    public class ApiModule : AppModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var option = c.Resolve<IOptionsMonitor<JwtOption>>();

                var securityKey = option.CurrentValue.SecurityKey;

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));

                var sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                return sign;

            }).As<SigningCredentials>().SingleInstance();

            base.Load(builder);
        }
    }
}
