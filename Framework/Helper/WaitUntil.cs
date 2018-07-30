using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Threading;

namespace Framework.Helper
{
    public class WaitUntil
    {
        IWebDriver _driver;

        private double TIMEOUT = Convert.ToDouble(ConfigurationManager.AppSettings["DefaultTimeout"]);
        private int TIMEOUTBETWEENEVENTS = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultTimeoutBetweenEvents"]);
        
        public WaitUntil(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ElementToBeClickable(IWebElement element)
        {
            try
            {
                Thread.Sleep(TIMEOUTBETWEENEVENTS);
                return new WebDriverWait(_driver, TimeSpan.FromSeconds(TIMEOUT)).Until(Clickable(element));
            }
            catch (Exception e)
            {
                var path = General.TakeScreenshot(_driver);
                _driver.Quit();
                throw new Exception("SCREENSHOT GENERATED => " + "url(" + path + ")", e.InnerException);
            }
        }

        public IWebElement ElementToBeClickable(By element)
        {
            try
            {
                Thread.Sleep(TIMEOUTBETWEENEVENTS);
                return new WebDriverWait(_driver, TimeSpan.FromSeconds(TIMEOUT)).Until(Clickable(element));
            }
            catch (Exception e)
            {
                var path = General.TakeScreenshot(_driver);
                _driver.Quit();
                throw new Exception("SCREENSHOT GENERATED => " + "url(" + path + ")", e.InnerException);
            }
        }

        public IWebElement ElementToBeVisible(By element)
        {
            try
            {
                Thread.Sleep(TIMEOUTBETWEENEVENTS);
                return new WebDriverWait(_driver, TimeSpan.FromSeconds(TIMEOUT)).Until(ElementIsVisible(element));
            }
            catch (Exception e)
            {
                var path = General.TakeScreenshot(_driver);
                _driver.Quit();
                throw new Exception("SCREENSHOT GENERATED => " + "url(" + path + ")", e.InnerException);
            }
        }

        public bool ElementExists(By element)
        {
            try
            {
                Thread.Sleep(TIMEOUTBETWEENEVENTS);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                if (new WebDriverWait(_driver, TimeSpan.FromSeconds(2)).Until(Exists(element)) != null &&
                    new WebDriverWait(_driver, TimeSpan.FromSeconds(2)).Until(Exists(element)).Size.ToString() != "0")
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TIMEOUT);
            }
        }

        #region ExpectedConditions Selenium Implementation

        private Func<IWebDriver, IWebElement> Exists(By locator)
        {
            return (driver) => { return driver.FindElement(locator); };
        }

        private IWebElement ElementIfVisible(IWebElement element)
        {
            return element.Displayed ? element : null;
        }

        private Func<IWebDriver, IWebElement> Clickable(By locator)
        {
            return (driver) =>
            {
                var element = ElementIfVisible(driver.FindElement(locator));
                try
                {
                    if (element != null && element.Enabled)
                    {
                        return element;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        private Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
        {
            return (driver) =>
            {
                try
                {
                    return ElementIfVisible(driver.FindElement(locator));
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        private Func<IWebDriver, IWebElement> Clickable(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    if (element != null && element.Displayed && element.Enabled)
                    {
                        return element;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            };
        }

        #endregion
    }
}
