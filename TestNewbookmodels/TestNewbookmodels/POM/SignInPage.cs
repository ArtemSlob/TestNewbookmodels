using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestNewbookmodels.POM
{
    class SignInPage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _emailField = By.CssSelector("input[type=email]");
        private readonly By _passwordField = By.CssSelector("input[type=password]");
        private readonly By _loginButton = By.CssSelector("button[class^=SignInForm__submitButton]");
        private readonly By _errorMessage = By.XPath("//*[contains(@class, 'SignInForm__submitButton')]/../../div[contains(@class, 'PageFormLayout__errors--3dFcq')]/div/div");

        public SignInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignInPage GoToSignInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public SignInPage InputEmailField(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SignInPage InputPasswordField(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public void ClickLoginButton()
        {
            _webDriver.FindElement(_loginButton).Click();
            Thread.Sleep(1000);
        }

        public string GetErrorMessage()
        {
            return _webDriver.FindElement(_errorMessage).Text;
        }

        public bool IsLoginButtonPresent()
        {
            _webDriver.FindElement(_loginButton);
            return true;
        }
    }
}