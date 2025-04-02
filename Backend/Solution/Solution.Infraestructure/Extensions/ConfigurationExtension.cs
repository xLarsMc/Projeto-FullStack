using Microsoft.Extensions.Configuration;

namespace Solution.Infrastructure.Extensions
{
    public static class ConfigurationExtension
    {
        public static string ConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection")!;
        }

        public static bool isUnitTestEnvironment(this IConfiguration configuration)
        {
            var config = configuration.GetSection("InMemoryTest").Value;

            if (config?.ToLower() == "true")
                return true;

            return false;
        }
    }
}
