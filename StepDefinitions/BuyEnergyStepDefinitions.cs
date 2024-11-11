using ENSEKTestUIApplication.Selenium;
using ENSEKTestUIApplication.Support;
using NUnit.Framework;

namespace ENSEKTestUIApplication.StepDefinitions
{
    [Binding]
    public class BuyEnergyStepDefinitions
    {
        private readonly IClientDriver clientDriver;

        public BuyEnergyStepDefinitions(IClientDriver clientDriver)
        {
            this.clientDriver = clientDriver;
        }

        [Given(@"the user in homepage")]
        public void GivenTheUserInHomepage()
        {
            clientDriver.GoToHomePage();
        }

        [When(@"the user clicks buy energy button")]
        public void WhenTheUserClicksBuyEnergyButton()
        {
            clientDriver.ClickHomePageBuyEnergyButton();
        }

        [Then(@"the user should be launched in buyEnergyPage")]
        public void ThenTheUserShouldBeLaunchedInBuyEnergyPage()
        {
            var url = clientDriver.GetCurrentURL();
            Assert.AreEqual(url, TestConfiguration.TargetUrl+ "Energy/Buy");
        }

        [Then(@"the user clicks the Back to Homepage link")]
        public void ThenTheUserClicksTheBackToHomepageLink()
        {
            clientDriver.ClickBackToHomePageLink();
        }

        [Then(@"the user should be in home page")]
        public void ThenTheUserShouldBeInHomePage()
        {
            var url = clientDriver.GetCurrentURL();
            Assert.AreEqual(url, TestConfiguration.TargetUrl);
        }

        [Given(@"the user in buyEnergyPage")]
        public void GivenTheUserInBuyEnergyPage()
        {
            clientDriver.GoToBuyEnergyPage();
        }

        [When(@"the user clicks the reset button")]
        public void WhenTheUserClicksTheResetButton()
        {
            clientDriver.ClickResetButton();
        }

        [Then(@"the number of units required values are reset to default values for (.*)")]
        public void ThenTheNumberOfUnitsRequiredValuesAreResetToDefaultValuesForGas(string fuelType)
        {
            clientDriver.validatesPurchaseUnitTextBoxDefaultValue(fuelType);
        }

        [Given(@"the user fill the (.*) number of units required value as (.*)")]
        public void GivenTheUserFillTheGasNumberOfUnitsRequiredValueAs(string fuelType, string purchaseUnit)
        {
            clientDriver.InputPurchaseUnitValueForEnergyType(fuelType, purchaseUnit);
        }

        [Given(@"the user clicks the reset button")]
        public void GivenTheUserClicksTheResetButton()
        {
            clientDriver.ClickResetButton();
        }


        [Then(@"the user validates the sale confirmation message")]
        public void ThenTheUserValidatesTheSaleConfirmationMessage()
        {
            clientDriver.ValidatesSaleConfirmation();
        }

        [Given(@"the user clicks the (.*) buy button")]
        public void GivenTheUserClicksTheGasBuyButton(string fuelType)
        {
            clientDriver.ClickBuySubmitButtonForEnergyType(fuelType);
        }

    }
}
