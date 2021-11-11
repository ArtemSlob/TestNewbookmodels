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
        private readonly By _cardFullNameInput = By.CssSelector("input[placeholder='Full name']");
        private readonly By _cardNumberInput = By.CssSelector("input[placeholder='Card number']");
        private readonly By _cardExpirationDateInput = By.CssSelector("input[placeholder='MM / YY']");
        private readonly By _cardCVCInput = By.CssSelector("input[placeholder='CVC']");
        private readonly By _cardSaveChangesButton = By.CssSelector("//common-button-deprecated/button[@type='submit']");
        private readonly By _generalInfoEditButton = By.CssSelector("nb-edit-switcher[_ngcontent-c26] div[class='edit-switcher__icon_type_edit']");

        public AccountSettingsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void ClickLogoutLink()
        {
            _webDriver.FindElement(_welcomeTitle).Click();
            Thread.Sleep(1000);
        }

        public AccountSettingsPage InputCardFullName(string cardFullName)
        {
            _webDriver.FindElement(_cardFullNameInput).SendKeys(cardFullName);
            return this;
        }

        public AccountSettingsPage InputCardNumber(string cardNumber)
        {
            _webDriver.FindElement(_cardNumberInput).SendKeys(cardNumber);
            return this;
        }

        public AccountSettingsPage InputCardExpirationDate(string cardExpirationDate)
        {
            _webDriver.FindElement(_cardExpirationDateInput).SendKeys(cardExpirationDate);
            return this;
        }

        public AccountSettingsPage InputcardCVC(string cardCVC)
        {
            _webDriver.FindElement(_cardCVCInput).SendKeys(cardCVC);
            return this;
        }

        public void ClickCardSaveChangesButton()
        {
            _webDriver.FindElement(_cardSaveChangesButton).Click();
        }

        public void ClickGeneralInfoEditButton()
        {
            _webDriver.FindElement(_generalInfoEditButton).Click();
        }
    }
}
