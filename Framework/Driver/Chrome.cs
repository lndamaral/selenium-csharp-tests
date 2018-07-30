using System;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Framework.Driver
{
    public class Chrome
    {
        public static RemoteWebDriver Build()
        {
            Uri uri = new Uri(ConfigurationManager.AppSettings["SeleniumServerURL"]);

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "Downloads"));
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddArguments("--start-maximized");

            return new RemoteWebDriver(uri, chromeOptions);
        }

        public static ChromeDriver BuildLocal()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("e.default_directory", AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "Downloads"));
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

            return new ChromeDriver(chromeOptions);
        }
    }
}
