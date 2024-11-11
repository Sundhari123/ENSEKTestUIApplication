namespace ENSEKTestUIApplication.Selenium
{
    public interface IClientDriver
    {
        void SetUp();

        void TearDown();

        void GoToHomePage();

        void ClickHomePageBuyEnergyButton();

        string GetCurrentURL();

        void InputPurchaseUnitValueForEnergyType(string fuelType, string purchaseUnit);

        void ClickBackToHomePageLink();

        void GoToBuyEnergyPage();

        void ClickResetButton();

        void validatesPurchaseUnitTextBoxDefaultValue(string fuelType);

        void ClickBuySubmitButtonForEnergyType(string fuelType);

        void ValidatesSaleConfirmation();
    }
}
