using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNewbookmodels.POM
{
    class SignUpPage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _firstNameField = By.CssSelector("[name='first_name']");
        private readonly By _lastNameField = By.CssSelector("[name='last_name']");
        private readonly By _emailField = By.CssSelector("[name='email']");
        private readonly By _passwordField = By.CssSelector("[name='password']");
        private readonly By _passwordConfirmField = By.CssSelector("[name='password_confirm']");
        private readonly By _phoneNumberField = By.CssSelector("[name='phone_number']");
        private readonly By _signupNextButton = By.CssSelector("[type='submit']");

        public SignUpPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SignUpPage InputFirstNameField(string firstName)
        {
            _webDriver.FindElement(_firstNameField).SendKeys(firstName);
            return this;
        }

        public SignUpPage InputLastNameField(string lastName)
        {
            _webDriver.FindElement(_lastNameField).SendKeys(lastName);
            return this;
        }

        public SignUpPage InputEmailField(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SignUpPage InputPasswordField(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public SignUpPage InputPasswordConfirmField(string password)
        {
            _webDriver.FindElement(_passwordConfirmField).SendKeys(password);
            return this;
        }

        public SignUpPage InputPhoneNumberField(string phoneNumber)
        {
            _webDriver.FindElement(_phoneNumberField).SendKeys(phoneNumber);
            return this;
        }

        public void ClickSignupNextButton() =>
            _webDriver.FindElement(_signupNextButton).Click();
    }
}
