using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;

namespace ENSEKTestUIApplication.PageObjects
{
    public class BuyEnergyPage : PageObject
    {
        private readonly WebDriverWait wait;

        public BuyEnergyPage(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement GetBackToHomePageLink()
        {
            return WaitForElementByXPath(wait, "//a[contains(text(), 'Back to Homepage')]");
        }

        public List<IWebElement> GetRowforSpecificEnergyType(string fuelType)
        {
            switch (fuelType)
            {
                case "Gas":
                    return WaitForElementsByXPath(wait, "//tr[1]//td");
                    
                case "Electricity":
                    return WaitForElementsByXPath(wait, "//tr[3]//td");
                 
                default:
                    return WaitForElementsByXPath(wait, "//tr[4]//td");
            }
        }

        public IWebElement GetPurchaseUnitValueForEnergyType(string fuelType)
        {
            return getPurchaseQuantityTextBoxForEnergType(fuelType);

        }

        public IWebElement GetBuySubmitButtonForEnergyType(string fuelType)
        {
            var row = GetRowforSpecificEnergyType(fuelType);

            return row[4].FindElement(By.TagName("input"));
        }

        public IWebElement GetResetButton()
        {
            return WaitForElementByXPath(wait, "//input[@name='Reset']");
        }

        public IWebElement GetPurchaseUnitTextBoxDefaultValue(string fuelType)
        {
            return getPurchaseQuantityTextBoxForEnergType(fuelType);
        }

        public void ValidatesSaleConfirmation(string url)
        {
            Assert.That(url.Contains("SaleConfirmed"), "Sale for energy type didnt happen properly");
            //TODO
            // Heading validation and proper message validation with calclution from previous page values
        }

        private IWebElement getPurchaseQuantityTextBoxForEnergType(string fuelType)
        {
            var row = GetRowforSpecificEnergyType(fuelType);

            return row[3].FindElement(By.TagName("input"));
        }
    }
}
