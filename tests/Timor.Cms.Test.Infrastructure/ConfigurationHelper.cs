using System.IO;
using Microsoft.Extensions.Configuration;

namespace Timor.Cms.Test.Infrastructure
{
    public class ConfigurationHelper
    {
        public static IConfigurationRoot InitConfiguration()
        {
            var test = Directory.GetCurrentDirectory();

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables();

            var config = configBuilder.Build();

            return config;
        }
    }
}