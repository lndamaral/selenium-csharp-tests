using System;
using System.Configuration;
using Framework.Helper;
using NUnit.Framework;

namespace Framework.Base
{
    public class BaseTest
    {
        [SetUp]
        public void SetupTest()
        {
            DriverFactory.Initialize(ConfigurationManager.AppSettings["DefaultBrowser"]);
            DriverFactory.Instance.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseURL"]);
            DriverFactory.Instance.Manage().Window.Maximize();

            Console.WriteLine(TestContext.CurrentContext.Test.FullName);
        }

        [TearDown]
        public void TearDownTest()
        {
            DriverFactory.Instance.Quit();
        }
    }
}
