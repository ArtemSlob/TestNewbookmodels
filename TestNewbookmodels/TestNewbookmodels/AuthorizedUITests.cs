using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNewbookmodels.POM;

namespace TestNewbookmodels
{
    class AuthorizedUITests
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("user-data-dir=C:/Users/Artem/AppData/Local/Google/Chrome/User Data/Profile 1");
            //options.AddArgument("--profile-directory=Profile 1");
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
            var homeage = new Homepage(_webDriver);
            var signUpPage = new SignUpPage(_webDriver);
            var signUpCompanyPage = new SignUpCompanyPage(_webDriver);
            var explorePage = new ExplorePage(_webDriver);

            homeage.GoToHomepage()
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
            string actualResultURL = _webDriver.Url;
            Assert.AreEqual("https://newbookmodels.com/explore", actualResultURL);
            Assert.IsTrue(explorePage.WelcomeTitleText().Contains("Abdula"));
        }
    }
}
