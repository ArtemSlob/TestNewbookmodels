using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestNewbookmodels.POM
{
    public class AdditionalMethods
    {
        private IWebDriver _webDriver;
        public static string DateTimeNowString = DateTime.Now.ToString("ddMMyyyyhhmmss");

        public AdditionalMethods(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AdditionalMethods Authorization()
        {
            var homeage = new Homepage(_webDriver);
            var signInPage = new SignInPage(_webDriver);

            homeage.GoToHomepage()
                .ClickNavBarLogInLink();
            signInPage.GoToSignInPage()
                .InputEmailField("a556793195@emailnax.com")
                .InputPasswordField("Qwerty1!")
                .ClickLoginButton();
            Thread.Sleep(1000);
            return this;
        }
    }
}
