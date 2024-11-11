using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace ENSEKTestUIApplication.PageObjects
{
    public class PageObject
    {
        public static IWebElement WaitForElementByXPath(WebDriverWait wait, string xpath)
        {
            return WaitForElement(wait, drv => drv.FindElement(By.XPath(xpath)));
        }

        public static List<IWebElement> WaitForElementsByXPath(WebDriverWait wait, string xpath)
        {
            return WaitForElements(wait, drv => drv.FindElements(By.XPath(xpath)).ToList());
        }

        public static IWebElement WaitForElementById(WebDriverWait wait, string id)
        {
            return WaitForElement(wait, drv => drv.FindElement(By.Id(id)));
        }

        public static IWebElement WaitForElementByCss(WebDriverWait wait, string selector)
        {
            return WaitForElement(wait, drv => drv.FindElement(By.CssSelector(selector)));
        }

        private static IWebElement WaitForElement(WebDriverWait wait, Func<IWebDriver, IWebElement> condition)
        {
            try
            {
                return wait.Until(condition);
            }
            catch
            {
                return null!;
            }
        }

        private static List<IWebElement> WaitForElements(WebDriverWait wait, Func<IWebDriver, List<IWebElement>> condition)
        {
            try
            {
                return wait.Until(condition);
            }
            catch
            {
                return null!;
            }
        }
    }
}
