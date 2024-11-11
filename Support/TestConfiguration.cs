using Microsoft.Extensions.Configuration;

namespace ENSEKTestUIApplication.Support
{
    public class TestConfiguration
    {
        private const string ConfigurationFileName = "AppConfig.json";

        static TestConfiguration()
        {
            var config = BuildConfiguration();
            TestConfig = config.GetSection("TestConfig");
        }

        public static string TargetUrl => GetEnvironmentValue("TargetUrl");

        public static string SeleniumUiMode => GetEnvironmentValue("SeleniumUiMode");

        public static string BrowserType => GetEnvironmentValue("BrowserType");

        public static IConfiguration BuildConfiguration()
        {
            var build = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(ConfigurationFileName, optional: false, reloadOnChange: true);

            return build.Build();
        }

        private static IConfigurationSection TestConfig { get; }

        private static string GetEnvironmentValue(string key)
        {
            var env = Environment.GetEnvironmentVariable(key);
            return env ?? TestConfig[key]!;
        }
    }
}
