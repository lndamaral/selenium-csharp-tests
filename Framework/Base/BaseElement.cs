using OpenQA.Selenium;
using Framework.Helper;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Framework.Base
{
    public class BaseElement
    {
        public static bool Exists(By locator)
        {
            return WaitUntil.ElementExists(locator);
        }

        public static void Click(IWebElement element)
        {
            IWebElement e = WaitUntil.ElementToBeClickable(element);
            General.ScrollTo(GetElement(element));
            new Actions(DriverFactory.Instance).MoveToElement(e).Click().Perform();
        }

        public static void Click(By locator)
        {
            IWebElement e = WaitUntil.ElementToBeClickable(locator);
            General.ScrollTo(GetElement(locator));
            new Actions(DriverFactory.Instance).MoveToElement(e).Click().Perform();
        }

        public static void Type(IWebElement element, string value)
        {
            WaitUntil.ElementToBeClickable(element).SendKeys(value + Keys.Tab);
        }

        public static void Type(By locator, string value)
        {
            WaitUntil.ElementToBeClickable(locator).SendKeys(value + Keys.Tab);
        }

        public static IWebElement GetElement(IWebElement element)
        {
            return WaitUntil.ElementToBeClickable(element);
        }

        public static IWebElement GetElement(By locator)
        {
            return WaitUntil.ElementToBeClickable(locator);
        }

        public static string GetElementText(IWebElement element)
        {
            return WaitUntil.ElementToBeClickable(element).GetAttribute("innerText");
        }

        public static string GetElementText(By locator)
        {
            return WaitUntil.ElementToBeClickable(locator).GetAttribute("innerText");
        }

        public static void Wait(IWebElement element)
        {
            WaitUntil.ElementToBeClickable(element);
        }

        public static void Wait(By locator)
        {
            WaitUntil.ElementToBeClickable(locator);
        }

        public static void Clear(IWebElement element)
        {
            WaitUntil.ElementToBeClickable(element).Clear();
        }

        public static void Clear(By locator)
        {
            WaitUntil.ElementToBeClickable(locator).Clear();
        }

        public static void Select(IWebElement element, string value)
        {
            new SelectElement(GetElement(element)).SelectByText(value);
        }

        public static void Select(By locator, string value)
        {
            new SelectElement(GetElement(locator)).SelectByText(value);
        }

        public static string GetSelectedText(IWebElement element)
        {
            return new SelectElement(GetElement(element)).SelectedOption.Text;
        }

        public static string GetSelectedText(By locator)
        {
            return new SelectElement(GetElement(locator)).SelectedOption.Text;
        }

        public static bool IsEnabled(By element)
        {
            return WaitUntil.ElementToBeVisible(element).Enabled;
        }
    }
}
