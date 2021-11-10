using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestNewbookmodels.POM
{
    class ExplorePage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _welcomeTitle = By.CssSelector("[class='Section__title--1wSQt']");
        private readonly By _avatarIcon = By.CssSelector("[class='AvatarClient__avatar--3TC7_']");


        public ExplorePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ExplorePage GoToExplorePage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/explore");
            return this;
        }

        public string WelcomeTitleText()
        {
            return _webDriver.FindElements(_welcomeTitle)[0].Text;
        }

        public void ClickAvatarIcon()
        {
            _webDriver.FindElement(_avatarIcon).Click();
        }
    }
}
