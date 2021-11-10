using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNewbookmodels.POM
{
    class ExplorePage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _welcomTitle = By.CssSelector("[class='Section__title--1wSQt']");


        public ExplorePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string WelcomeTitleText()
        {
            return _webDriver.FindElements(_welcomTitle)[0].Text;
        }
    }
}
