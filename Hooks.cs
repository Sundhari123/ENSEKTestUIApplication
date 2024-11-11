using ENSEKTestUIApplication.Selenium;
using BoDi;


namespace ENSEKTestUIApplication
{
    [Binding]
    public class Hooks
    {
        private static IClientDriver clientDriver = null!;

        [BeforeTestRun]
        public static void TestSetup(IObjectContainer objContainer)
        {
            clientDriver = new SeleniumClientDriver();
            clientDriver.SetUp();
            objContainer.RegisterInstanceAs(clientDriver);
        }

        [BeforeFeature]
        public static void SetupUser()
        {
        }

        [AfterFeature]
        public static void CleanUpUser()
        {
        }

        [AfterTestRun]
        public static void TestTearDown()
        {
            clientDriver.TearDown();
        }

    }
}
