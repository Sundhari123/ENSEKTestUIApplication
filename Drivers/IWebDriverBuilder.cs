using OpenQA.Selenium;

namespace ENSEKTestUIApplication.WebDriver
{
    public interface IWebDriverBuilder
    {
        IWebDriverBuilder SetHeadless();
        IWebDriver Build();
    }
}
