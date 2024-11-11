namespace ENSEKTestUIApplication.WebDriver
{
    class WebDriverFactory
    {
        public const string Chrome = "Chrome";

        public const string FireFox = "Firefox";

        public static IWebDriverBuilder MakeWebDriverBuilder(string browserType)
        {
            var factories = new Dictionary<string, Func<IWebDriverBuilder>>
            {
                { Chrome, () => new ChromeDriverBuilder() },
                { FireFox, () => new FirefoxDriverBuilder() }
            };

            if (!factories.ContainsKey(browserType))
            {
                throw new InvalidOperationException($"The browser type is unknown: {browserType}");
            }

            return factories[browserType]();
        }
    }

}
