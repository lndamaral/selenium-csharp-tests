using OpenQA.Selenium;
using System.Configuration;
using System;
using Framework.Driver;

namespace Framework.Helper
{
    public class DriverFactory
    {
        public static IWebDriver Instance { get; set; }

        static DriverFactory()
        {
            Instance = null;
        }

        public static void Initialize(string browser)
        {
            double timeout = Convert.ToDouble(ConfigurationManager.AppSettings["DefaultTimeout"]);

            if (browser.Equals("Chrome"))
            {
                Instance = Chrome.Build();
            }

            else if (browser.Equals("Firefox"))
            {
                Instance = Firefox.Build();
            }

            else
            {
                throw new Exception("Driver não suportado!");
            }

            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);

        }
    }
}
