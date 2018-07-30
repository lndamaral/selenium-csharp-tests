using OpenQA.Selenium;
using Framework.Base;

namespace Test.Selenium.Sistema.Page
{
    public class Login : BasePage
    {

        private IWebElement login => GetElement(By.XPath("//input[@id='inputEmail']"));
        private IWebElement senha => GetElement(By.XPath("//input[@id='inputPassword']"));
        private IWebElement btnAcessar => GetElement(By.XPath("//button[@type='submit']"));

        public Login(IWebDriver driver) : base (driver)
        {

        }

        public void PreencherUsuario(string valor)
        {
            Type(login, valor);
        }

        public void PreencherSenha(string valor)
        {
            Type(senha, valor);
        }

        public void ClicarAcessar()
        {
            Click(btnAcessar);
        }
    }
}
