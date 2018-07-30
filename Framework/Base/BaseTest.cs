using System;
using System.Configuration;
using Framework.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Framework.Base
{
    public class BaseTest
    {
        protected IWebDriver _driver;

        [SetUp]
        public void SetupTest()
        {
            _driver = new DriverFactory().Initialize(ConfigurationManager.AppSettings["DefaultBrowser"]);
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseURL"]);
            
            Console.WriteLine(TestContext.CurrentContext.Test.FullName);
        }

        [TearDown]
        public void TearDownTest()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
