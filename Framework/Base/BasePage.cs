using OpenQA.Selenium;

namespace Framework.Base
                        
{
    public class BasePage : BaseElement
    {
        private IWebDriver _driver;
        
        public BasePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }

        public void DismissAlert()
        {
            _driver.SwitchTo().Alert().Dismiss();
        }
    }
}
