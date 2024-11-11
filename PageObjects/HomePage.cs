using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace ENSEKTestUIApplication.PageObjects
{
    public class HomePage : PageObject
    {
        //TODO: magic strings can be declared initially in all files
        private readonly WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement GetHomePageBuyEnergyButton()
        {
            return WaitForElementByXPath(wait, "//a[@href='/Energy/Buy']");
        }

    }
}
