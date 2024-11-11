using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ENSEKTestUIApplication.WebDriver
{
    public class ChromeDriverBuilder :BaseDriver
    {
        public ChromeDriverBuilder() : base(new ChromeOptions())
        {
        }

        private ChromeOptions ChromeOptions => (Options as ChromeOptions)!;

        public override IWebDriverBuilder SetHeadless()
        {
            ChromeOptions.AddArgument("headless");
            return this;
        }

        protected override IWebDriver MakeLocalWebDriver()
        {
            var path = GetAssemblyPath();
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            /*var downloadPath = Path.GetFullPath(Path.Join(projectPath, @"..\TestFiles\Download\"));
            ChromeOptions.Proxy = null;
            ChromeOptions.AddUserProfilePreference("download.default_directory", downloadPath);
            ChromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            ChromeOptions.AddUserProfilePreference("disable-popup-blocking", true);*/

            var service = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(path));
            var driver = new ChromeDriver(service, ChromeOptions, CommandTimeout);
            return driver;
        }
    }
}
