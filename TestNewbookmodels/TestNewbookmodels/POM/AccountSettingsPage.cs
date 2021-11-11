using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
        private readonly WebDriverWait Wait;

        private readonly By _welcomeTitle = By.CssSelector("[class~='link_type_logout']");
        private readonly By _cardFullNameInput = By.CssSelector("input[placeholder='Full name']");
        private readonly By _cardNumberInput = By.CssSelector("input[placeholder='Card number']");
        private readonly By _cardExpirationDateInput = By.CssSelector("input[placeholder='MM / YY']");
        private readonly By _cardCVCInput = By.CssSelector("input[placeholder='CVC']");
        private readonly By _cardSaveChangesButton = By.CssSelector("//common-button-deprecated/button[@type='submit']");
        private readonly By _generalInfoEditButton = By.CssSelector("nb-edit-switcher[_ngcontent-c26] div[class='edit-switcher__icon_type_edit']");
        private readonly By _firstNameGeneralInfoEditInput = By.CssSelector("input[placeholder='Enter First Name']");
        private readonly By _lastNameGeneralInfoEditInput = By.CssSelector("input[placeholder='Enter Last Name']");
        private readonly By _companyLocationGeneralInfoEditInput = By.CssSelector("input[placeholder='Enter Company Location']");
        private readonly By _companyIndustryGeneralInfoEditInput = By.CssSelector("input[placeholder='Enter Industry']");
        private readonly By _saveGeneralInfoChangesButton = By.CssSelector("common-button-deprecated[class='mt-5'] button[type='submit']");
        private readonly By _nonEditablePersonalDataFields = By.CssSelector("div[class='col-24 p-0'] nb-paragraph[class='mt-2'] div[class='paragraph_type_gray']");

        public AccountSettingsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            Wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 20));
        }

        public void ClickLogoutLink()
        {
            _webDriver.FindElement(_welcomeTitle).Click();
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_saveGeneralInfoChangesButton));
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

        public AccountSettingsPage InputCardCVC(string cardCVC)
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

        public AccountSettingsPage InputFirstNameGeneralInfo(string firstNameGeneralInfo)
        {
            _webDriver.FindElement(_firstNameGeneralInfoEditInput).Clear();
            _webDriver.FindElement(_firstNameGeneralInfoEditInput).SendKeys(firstNameGeneralInfo);
            return this;
        }

        public AccountSettingsPage InputLastNameGeneralInfo(string lastNameGeneralInfo)
        {
            _webDriver.FindElement(_firstNameGeneralInfoEditInput).Clear();
            _webDriver.FindElement(_lastNameGeneralInfoEditInput).SendKeys(lastNameGeneralInfo);
            return this;
        }

        public AccountSettingsPage InputCompanyLocationGeneralInfo(string companyLocationGeneralInfo)
        {
            _webDriver.FindElement(_firstNameGeneralInfoEditInput).Clear();
            _webDriver.FindElement(_companyLocationGeneralInfoEditInput).SendKeys(companyLocationGeneralInfo);
            Thread.Sleep(1000);
            _webDriver.FindElement(_companyLocationGeneralInfoEditInput).SendKeys(Keys.ArrowDown);
            Thread.Sleep(1000);
            _webDriver.FindElement(_companyLocationGeneralInfoEditInput).SendKeys(Keys.Enter);
            return this;
        }

        public AccountSettingsPage InputCompanyIndustryGeneralInfo(string companyIndustryGeneralInfo)
        {
            _webDriver.FindElement(_firstNameGeneralInfoEditInput).Clear();
            _webDriver.FindElement(_companyIndustryGeneralInfoEditInput).SendKeys(companyIndustryGeneralInfo);
            return this;
        }

        public void ClickSaveGeneralInfoChangesButton()
        {
            _webDriver.FindElement(_saveGeneralInfoChangesButton).Click();
            Thread.Sleep(5000);
        }

        public string NonEditablePersonalDataNameFieldText()
        {
            return _webDriver.FindElements(_nonEditablePersonalDataFields)[0].Text;
        }

        public string NonEditablePersonalDataCompanyLocationFieldText()
        {
            return _webDriver.FindElements(_nonEditablePersonalDataFields)[1].Text;
        }

        public string NonEditablePersonalCompanyIndustryText()
        {
            return _webDriver.FindElements(_nonEditablePersonalDataFields)[2].Text;
        }

        public string NonEditablePersonalDataEmailFieldText()
        {
            return _webDriver.FindElements(_nonEditablePersonalDataFields)[3].Text;
        }

        public string NonEditablePersonalDataPhoneFieldText()
        {
            return _webDriver.FindElements(_nonEditablePersonalDataFields)[4].Text;
        }
    }
}
