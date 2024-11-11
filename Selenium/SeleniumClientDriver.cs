using ENSEKTestUIApplication.Support;
using OpenQA.Selenium;
using ENSEKTestUIApplication.PageObjects;
using NUnit.Framework;

namespace ENSEKTestUIApplication.Selenium
{
    public class SeleniumClientDriver : IClientDriver
    {
        private IWebDriver webDriver = null!;
        private HomePage homePage = null!;
        private BuyEnergyPage buyEnergyPage = null!;

        #region public
        public void SetUp()
        {
            webDriver = MakeDriver();
            homePage = new HomePage(webDriver);
            buyEnergyPage = new BuyEnergyPage(webDriver);

            webDriver.Navigate().GoToUrl($"{TestConfiguration.TargetUrl}");
        }

        public void TearDown()
        {
            webDriver?.Close();
            webDriver?.Quit();
        }

        public void GoToHomePage()
        {
            webDriver.Navigate().GoToUrl($"{TestConfiguration.TargetUrl}");
        }

        public void ClickHomePageBuyEnergyButton()
        {
            homePage.GetHomePageBuyEnergyButton().Click();
        }

        public string GetCurrentURL()
        {
            return webDriver.Url;
        }

        public void ClickBackToHomePageLink()
        {
            buyEnergyPage.GetBackToHomePageLink().Click();
        }

        public void GoToBuyEnergyPage()
        {
            webDriver.Navigate().GoToUrl($"{TestConfiguration.TargetUrl}" + "Energy/Buy");
        }

        public void InputPurchaseUnitValueForEnergyType(string fuelType, string purchaseQuantity)
        {
            var textBoxPurchaseUnit = buyEnergyPage.GetPurchaseUnitValueForEnergyType(fuelType);

            textBoxPurchaseUnit.Clear();

            textBoxPurchaseUnit.SendKeys(purchaseQuantity);

        }

        public void ClickResetButton()
        {
            var resetButton = buyEnergyPage.GetResetButton();
            resetButton.Click();
        }

        public void validatesPurchaseUnitTextBoxDefaultValue(string fuelType)
        {
            var purchaseUnitTextBox = buyEnergyPage.GetPurchaseUnitTextBoxDefaultValue(fuelType);
            Assert.That(purchaseUnitTextBox.GetAttribute("value").Equals("0"), "Purchase Unit text box is not reset properly");
        }

        public void ClickBuySubmitButtonForEnergyType(string fuelType)
        {
            var buyButton = buyEnergyPage.GetBuySubmitButtonForEnergyType(fuelType);
            buyButton.Click();
        }

        public void ValidatesSaleConfirmation()
        {
            buyEnergyPage.ValidatesSaleConfirmation(GetCurrentURL());
        }
        #endregion

        #region private
        private static IWebDriver MakeDriver()
        {
            var builder = WebDriver.WebDriverFactory.MakeWebDriverBuilder(TestConfiguration.BrowserType);

            if (TestConfiguration.SeleniumUiMode == "Headless")
            {
                builder = builder.SetHeadless();
            }

            var driver = builder.Build();
            var manage = driver.Manage();
            manage.Cookies.DeleteAllCookies();
            manage.Window.Maximize();

            return driver;
        }
        #endregion
    }
}
