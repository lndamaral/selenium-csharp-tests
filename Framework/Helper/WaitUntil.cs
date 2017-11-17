using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Threading;

namespace Framework.Helper
{
    public class WaitUntil
    {
        static double TIMEOUT = Convert.ToDouble(ConfigurationManager.AppSettings["DefaultTimeout"]);
        static int TIMEOUTBETWEENEVENTS = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultTimeoutBetweenEvents"]);

        public static IWebElement ElementToBeClickable(IWebElement element)
        {
            try
            {
                Thread.Sleep(TIMEOUTBETWEENEVENTS);
                return new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(TIMEOUT)).Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception e)
            {
                var path = General.TakeScreenshot();
                DriverFactory.Instance.Quit();
                throw new Exception("SCREENSHOT GENERATED => " + "url(" + path + ")", e.InnerException);
            }
        }

        public static IWebElement ElementToBeClickable(By element)
        {
            try
            {
                Thread.Sleep(TIMEOUTBETWEENEVENTS);
                return new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(TIMEOUT)).Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception e)
            {
                var path = General.TakeScreenshot();
                DriverFactory.Instance.Quit();
                throw new Exception("SCREENSHOT GENERATED => " + "url(" + path + ")", e.InnerException);
            }
        }

        public static IWebElement ElementToBeVisible(By element)
        {
            try
            {
                Thread.Sleep(TIMEOUTBETWEENEVENTS);
                return new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(TIMEOUT)).Until(ExpectedConditions.ElementIsVisible(element));
            }
            catch (Exception e)
            {
                var path = General.TakeScreenshot();
                DriverFactory.Instance.Quit();
                throw new Exception("SCREENSHOT GENERATED => " + "url(" + path + ")" , e.InnerException);
            }
        }

        public static bool ElementExists(By element)
        {
            try
            {
                Thread.Sleep(TIMEOUTBETWEENEVENTS);
                DriverFactory.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                if (new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(2)).Until(ExpectedConditions.ElementExists(element)) != null &&
                    new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(2)).Until(ExpectedConditions.ElementExists(element)).Size.ToString() != "0")
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
                DriverFactory.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TIMEOUT);
            }
        }
    }
}
