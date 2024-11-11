using OpenQA.Selenium;
using System.Reflection;

namespace ENSEKTestUIApplication.WebDriver
{
     public abstract class BaseDriver : IWebDriverBuilder
        {
        protected BaseDriver(DriverOptions options)
        {
            Options = options;
            CommandTimeout = TimeSpan.FromMinutes(30);
        }
        protected DriverOptions Options { get; }
        protected TimeSpan CommandTimeout { get; }
        public IWebDriver Build()
        {
            return MakeLocalWebDriver();
        }

        public abstract IWebDriverBuilder SetHeadless();

        protected static string GetAssemblyPath()
        {
            var codeBase = Assembly.GetExecutingAssembly().Location ?? throw new Exception();
            var uriBuilder = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uriBuilder.Path);
            return Path.GetFullPath(path);
        }
        protected abstract IWebDriver MakeLocalWebDriver();

    }
}
