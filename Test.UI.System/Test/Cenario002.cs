using Framework.Base;
using NUnit.Framework;
using Test.Selenium.Sistema.Page;

namespace Test.Selenium.Sistema.Test
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Cenario002 : BaseTest
    {
        [Test]
        public void Test_Cenario002_Login()
        {
            Login _loginPage = new Login(_driver);

            _loginPage.PreencherUsuario("fernandaaguilar");
            _loginPage.PreencherSenha("olesenha01");
            _loginPage.ClicarAcessar();
        }
    }
}
