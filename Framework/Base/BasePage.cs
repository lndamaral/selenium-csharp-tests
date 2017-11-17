using System;
using System.Configuration;
using System.Threading;
using Framework.Helper;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.Base
                        
{
    public class BasePage
    {
        protected WebDriverWait Wait { get; private set; }

        public BasePage()
        {
            PageFactory.InitElements(DriverFactory.Instance, this);
            Wait = new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultTimeout"])));
        }

        public void Refresh()
        {
            DriverFactory.Instance.Navigate().Refresh();
        }

        public void NavigateTo(string url)
        {
            DriverFactory.Instance.Navigate().GoToUrl(url);
        }

        public void AcceptAlert()
        {
            DriverFactory.Instance.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
        }

        public void DismissAlert()
        {
            DriverFactory.Instance.SwitchTo().Alert().Dismiss();
        }
    }
}
