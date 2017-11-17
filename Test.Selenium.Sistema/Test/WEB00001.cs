using System;
using Framework.Base;
using NUnit.Framework;
using Test.Selenium.Sistema.Page;

namespace Test.Selenium.Sistema.Test
{
    public class WEB00001 : BaseTest
    {
        private Login _loginPage;

        [Test]
        public void Test_WEB00001()
        {
            _loginPage = new Login();

            _loginPage.TypeUsername("");
            _loginPage.TypePassword("");
            _loginPage.ClickLogin();
        }
    }
}
