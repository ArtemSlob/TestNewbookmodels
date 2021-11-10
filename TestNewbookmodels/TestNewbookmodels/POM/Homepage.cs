using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNewbookmodels.POM
{
    class Homepage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _navBarSignUpButton = By.ClassName("Navbar__signUp--12ZDV");

        public Homepage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public Homepage GoToHomepage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/");
            return this;
        }

        public void ClickNavBarSignUpButton() =>
            _webDriver.FindElement(_navBarSignUpButton).Click();
    }
}
