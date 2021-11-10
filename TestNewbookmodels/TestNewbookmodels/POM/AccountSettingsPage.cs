using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestNewbookmodels.POM
{
    class AccountSettingsPage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _welcomeTitle = By.CssSelector("[class~='link_type_logout']");

        public AccountSettingsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ClickLogoutLink()
        {
            _webDriver.FindElement(_welcomeTitle).Click();
            Thread.Sleep(1000);
        }
    }
}
