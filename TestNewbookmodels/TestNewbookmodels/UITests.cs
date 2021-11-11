using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestNewbookmodels.POM;

namespace TestNewbookmodels
{
    public class Tests
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            _webDriver = new ChromeDriver(options);
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void After()
        {
            _webDriver.Dispose();
        }

        [Test]
        public void RegistrationTest()
        {
            var homepage = new Homepage(_webDriver);
            var signUpPage = new SignUpPage(_webDriver);
            var signUpCompanyPage = new SignUpCompanyPage(_webDriver);
            var explorePage = new ExplorePage(_webDriver);
            string actualResultURL;

            homepage.GoToHomepage()
                .ClickNavBarSignUpButton();
            signUpPage.InputFirstNameField("Abdula")
                .InputLastNameField("Shchur")
                .InputEmailField("abdula" + AdditionalMethods.DateTimeNowString + "@gmail.com")
                .InputPasswordField("Qwerty1!")
                .InputPasswordConfirmField("Qwerty1!")
                .InputPhoneNumberField("3425634634")
                .ClickSignupNextButton();
            signUpCompanyPage.InputCompanyNameField("Abdula Inc.")
                .InputCompanyWebsiteField("abdulashchur.com")
                .InputLocationField("FGH Building, Harrison Avenue, Boston, MA, USA");
            signUpCompanyPage.ClickIndustryInput();
            signUpCompanyPage.ClickIndustryOption();
            signUpCompanyPage.ClickSignupFinishButton();
            actualResultURL = _webDriver.Url;
            Assert.AreEqual("https://newbookmodels.com/explore", actualResultURL);
            Assert.IsTrue(explorePage.WelcomeTitleText().Contains("Abdula"));
        }

        [Test]
        public void AuthorizationTest()
        {
            var explorePage = new ExplorePage(_webDriver); 
            var authorization = new AdditionalMethods(_webDriver)
                .Authorization();
            string actualResultURL;

            actualResultURL = _webDriver.Url;
            Assert.AreEqual("https://newbookmodels.com/explore", actualResultURL);
            Assert.IsTrue(explorePage.WelcomeTitleText().Contains("Abdula"));
        }

        [Test]
        public void LogoutTest()
        {
            var explorePage = new ExplorePage(_webDriver);
            var signInPage = new SignInPage(_webDriver);
            var accountSettingsPage = new AccountSettingsPage(_webDriver);
            var authorization = new AdditionalMethods(_webDriver);
            string actualResultURL;
            bool isLoginButtonPresent;

            authorization.Authorization();
            explorePage.ClickAvatarIcon();
            accountSettingsPage.ClickLogoutLink();
            explorePage.GoToExplorePage();
            actualResultURL = _webDriver.Url;
            isLoginButtonPresent = signInPage.IsLoginButtonPresent();
            Assert.AreEqual("https://newbookmodels.com/auth/signin?goBackUrl=%2Fexplore", actualResultURL);
            Assert.IsTrue(isLoginButtonPresent);
        }

        [Test]
        public void EditFirstNameTest()
        {
            var explorePage = new ExplorePage(_webDriver);
            var accountSettingsPage = new AccountSettingsPage(_webDriver);
            var authorization = new AdditionalMethods(_webDriver);
            bool actualResultNameContainsNewName;
            string newFirstName;

            authorization.Authorization();
            explorePage.ClickAvatarIcon();
            accountSettingsPage.ClickGeneralInfoEditButton();
            newFirstName = "Abdula" + AdditionalMethods.DateTimeNowString;
            accountSettingsPage.InputFirstNameGeneralInfo(newFirstName)
                .ClickSaveGeneralInfoChangesButton();
            actualResultNameContainsNewName = accountSettingsPage.NonEditablePersonalDataNameFieldText().Contains(newFirstName);
            Assert.IsTrue(actualResultNameContainsNewName);
        }

        [Test]
        public void EditLastNameTest()
        {
            var explorePage = new ExplorePage(_webDriver);
            var accountSettingsPage = new AccountSettingsPage(_webDriver);
            var authorization = new AdditionalMethods(_webDriver);
            bool actualResultNameContainsNewName;
            string newLastName;

            authorization.Authorization();
            explorePage.ClickAvatarIcon();
            accountSettingsPage.ClickGeneralInfoEditButton();
            newLastName = "Schur" + AdditionalMethods.DateTimeNowString;
            accountSettingsPage.InputLastNameGeneralInfo(newLastName)
                .ClickSaveGeneralInfoChangesButton();
            actualResultNameContainsNewName = accountSettingsPage.NonEditablePersonalDataNameFieldText().Contains(newLastName);
            Assert.IsTrue(actualResultNameContainsNewName);
        }

        [Test]
        public void EditCompanyLocationTest()
        {
            var explorePage = new ExplorePage(_webDriver);
            var accountSettingsPage = new AccountSettingsPage(_webDriver);
            var authorization = new AdditionalMethods(_webDriver);
            bool actualResultNameContainsNewName;
            string newCompanyLocation = "San Francisco, CA, USA";

            authorization.Authorization();
            explorePage.ClickAvatarIcon();
            accountSettingsPage.ClickGeneralInfoEditButton();
            accountSettingsPage.InputCompanyLocationGeneralInfo(newCompanyLocation)
                .ClickSaveGeneralInfoChangesButton();
            actualResultNameContainsNewName = accountSettingsPage.NonEditablePersonalDataCompanyLocationFieldText().Contains(newCompanyLocation);
            Assert.IsTrue(actualResultNameContainsNewName);
        }

        [Test]
        public void EditCompanyIndustryTest()
        {
            var explorePage = new ExplorePage(_webDriver);
            var accountSettingsPage = new AccountSettingsPage(_webDriver);
            var authorization = new AdditionalMethods(_webDriver);
            bool actualResultNameContainsNewName;
            string newCompanyIndustry;

            authorization.Authorization();
            explorePage.ClickAvatarIcon();
            accountSettingsPage.ClickGeneralInfoEditButton();
            newCompanyIndustry = "Promotion" + AdditionalMethods.DateTimeNowString;
            accountSettingsPage.InputCompanyIndustryGeneralInfo(newCompanyIndustry)
                .ClickSaveGeneralInfoChangesButton();
            actualResultNameContainsNewName = accountSettingsPage.NonEditablePersonalCompanyIndustryText().Contains(newCompanyIndustry);
            Assert.IsTrue(actualResultNameContainsNewName);
        }

        //[Test]
        //public void AddCardTest()
        //{
        //    var accountSettingsPage = new AccountSettingsPage(_webDriver);
        //    string actualResult;

        //    accountSettingsPage.GoToAccountSettingsPage()
        //        .InputCardFullName("Abdula Schur")
        //        .InputCardNumber("377439511404894")
        //        .InputCardExpirationDate("12/22")
        //        .InputCardCVC("377")
        //        .ClickCardSaveChangesButton();

        //    actualResult = "";
        //    Assert.AreEqual("", actualResult);
        //}


        [Test]
        public void AuthorizationWithWrongCredential()
        {
            var signInPage = new SignInPage(_webDriver);
            signInPage.GoToSignInPage()
                .InputEmailField("wrongEmail@gmail.com")
                .InputPasswordField("wrongPassword123")
                .ClickLoginButton();
            var actualResultMessage = signInPage.GetErrorMessage();

            Assert.AreEqual(expected: "Please enter a correct email and password.", actualResultMessage);
        }
    }
}