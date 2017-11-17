using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Framework.Base;

namespace Test.Selenium.Sistema.Page
{
    public class Login : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='username']")]
        public IWebElement username { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='btnLogin']")]
        public IWebElement btnLogin { get; set; }

        public void TypeUsername(string valor)
        {
            BaseElement.Type(username, valor);
        }

        public void TypePassword(string valor)
        {
            BaseElement.Type(password, valor);
        }

        public void ClickLogin()
        {
            BaseElement.Click(btnLogin);
        }
    }
}
