using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNewbookmodels.POM
{
    class SignUpCompanyPage
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait Wait;

        private readonly By _companyNameField = By.CssSelector("[name='company_name']");
        private readonly By _companyWebsiteField = By.CssSelector("[name='company_website']");
        private readonly By _locationField = By.CssSelector("[name='location']");
        private readonly By _locationGoogle = By.CssSelector("[class='pac-item']");
        private readonly By _industryInput = By.CssSelector("[name='industry']");
        private readonly By _industryOption = By.CssSelector("[role='option']");
        private readonly By _signupFinishButton = By.CssSelector("[type='submit']");

        public SignUpCompanyPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            Wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 20));
        }

        public SignUpCompanyPage InputCompanyNameField(string companyName)
        {
            _webDriver.FindElement(_companyNameField).SendKeys(companyName);
            return this;
        }

        public SignUpCompanyPage InputCompanyWebsiteField(string companyWebsite)
        {
            _webDriver.FindElement(_companyWebsiteField).SendKeys(companyWebsite);
            return this;
        }

        public SignUpCompanyPage InputLocationField(string location)
        {
            _webDriver.FindElement(_locationField).SendKeys(location);
            return this;
        }

        public void ClickLocationGoogle()
        {
            Wait.Until(ExpectedConditions.ElementExists(_locationGoogle));
            _webDriver.FindElement(_locationGoogle).Click();
        }

        public void ClickIndustryInput()
        {
            _webDriver.FindElement(_industryInput).Click();
        }

        public void ClickIndustryOption()
        {
            _webDriver.FindElement(_industryOption).Click();
        }

        public void ClickSignupFinishButton() =>
            _webDriver.FindElement(_signupFinishButton).Click();
    }
}
