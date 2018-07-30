using Framework.Base;
using NUnit.Framework;
using Test.Selenium.Sistema.Page;

namespace Test.Selenium.Sistema.Test
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Cenario003 : BaseTest
    {
        [Test]
        public void Test_Cenario003_Login()
        {
            Login _loginPage = new Login(_driver);

            _loginPage.PreencherUsuario("usuario.teste3");
            _loginPage.PreencherSenha("123456");
            _loginPage.ClicarAcessar();
        }
    }
}
