using System;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Framework.Driver
{
    public class Firefox
    {
        public static RemoteWebDriver Build()
        {
            Uri uri = new Uri(ConfigurationManager.AppSettings["SeleniumServerURL"]);

            var firefoxOptions = new FirefoxOptions();

            return new RemoteWebDriver(uri, firefoxOptions);
        }
    }
}
