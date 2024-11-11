using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;


namespace ENSEKTestUIApplication.WebDriver
{
    public class FirefoxDriverBuilder :BaseDriver
    {
        public FirefoxDriverBuilder() : base(new FirefoxOptions())
        {
        }

        private FirefoxOptions FirefoxOptions => (Options as FirefoxOptions)!;

        public override IWebDriverBuilder SetHeadless()
        {
            FirefoxOptions.AddArgument("--headless");
            FirefoxOptions.AcceptInsecureCertificates = true;
            return this;
        }

        protected override IWebDriver MakeLocalWebDriver()
        {
            var projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            var downloadPath = Path.GetFullPath(Path.Join(projectPath, @"..\TestFiles\Download\"));
            FirefoxOptions.SetPreference("security.sandbox.content.level", 5);
            FirefoxOptions.SetPreference("network.proxy.type", 0);
            FirefoxOptions.SetPreference("browser.download.folderList", 2);
            FirefoxOptions.SetPreference("browser.download.dir", downloadPath);
            FirefoxOptions.SetPreference("browser.download.useDownloadDir", true);
            FirefoxOptions.LogLevel = FirefoxDriverLogLevel.Info;
            FirefoxOptions.AcceptInsecureCertificates = true;

            var path = GetAssemblyPath();

            var driver = new FirefoxDriver(Path.GetDirectoryName(path), FirefoxOptions, CommandTimeout);

            return driver;
        }
    }
}
