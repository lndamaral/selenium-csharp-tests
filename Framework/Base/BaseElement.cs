using OpenQA.Selenium;
using Framework.Helper;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace Framework.Base
{
    public class BaseElement
    {
        IWebDriver _driver;
        WaitUntil _waitUntil;
        
        public BaseElement(IWebDriver driver)
        {
            _driver = driver;
            _waitUntil = new WaitUntil(_driver);
        }

        public bool Exists(By locator)
        {
            return _waitUntil.ElementExists(locator);
        }

        public void Click(IWebElement element)
        {
            IWebElement e = _waitUntil.ElementToBeClickable(element);
            General.ScrollTo(_driver, e);
            new Actions(_driver).MoveToElement(e).Click().Perform();
        }

        public void Click(By locator)
        {
            IWebElement e = _waitUntil.ElementToBeClickable(locator);
            General.ScrollTo(_driver, e);
            new Actions(_driver).MoveToElement(e).Click().Perform();
        }

        public void Type(IWebElement element, string value)
        {
            _waitUntil.ElementToBeClickable(element).SendKeys(value + Keys.Tab);
        }

        public void Type(By locator, string value)
        {
            _waitUntil.ElementToBeClickable(locator).SendKeys(value + Keys.Tab);
        }

        public IWebElement GetElement(IWebElement element)
        {
            return _waitUntil.ElementToBeClickable(element);
        }

        public IWebElement GetElement(By locator)
        {
            return _waitUntil.ElementToBeClickable(locator);
        }

        public string GetElementText(IWebElement element)
        {
            return _waitUntil.ElementToBeClickable(element).GetAttribute("innerText");
        }

        public string GetElementText(By locator)
        {
            return _waitUntil.ElementToBeClickable(locator).GetAttribute("innerText");
        }

        public void Wait(IWebElement element)
        {
            _waitUntil.ElementToBeClickable(element);
        }

        public void Wait(By locator)
        {
            _waitUntil.ElementToBeClickable(locator);
        }

        public void Clear(IWebElement element)
        {
            _waitUntil.ElementToBeClickable(element).Clear();
        }

        public void Clear(By locator)
        {
            _waitUntil.ElementToBeClickable(locator).Clear();
        }

        public void Select(IWebElement element, string value)
        {
            new SelectElement(GetElement(element)).SelectByText(value);
        }

        public void Select(By locator, string value)
        {
            new SelectElement(GetElement(locator)).SelectByText(value);
        }

        public string GetSelectedText(IWebElement element)
        {
            return new SelectElement(GetElement(element)).SelectedOption.Text;
        }

        public string GetSelectedText(By locator)
        {
            return new SelectElement(GetElement(locator)).SelectedOption.Text;
        }

        public bool IsEnabled(By element)
        {
            return _waitUntil.ElementToBeVisible(element).Enabled;
        }
        
    }
}
