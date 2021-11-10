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
            var homeage = new Homepage(_webDriver);
            var signUpPage = new SignUpPage(_webDriver);
            var signUpCompanyPage = new SignUpCompanyPage(_webDriver);

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
                .InputLocationField("FGH Building, Harrison Avenue, Boston, MA, USA")
                .ClickLocationGoogle();
            signUpCompanyPage.ClickIndustryInput();
            signUpCompanyPage.ClickIndustryOption();
            Thread.Sleep(1000);
            signUpCompanyPage.ClickSignupFinishButton();
            Thread.Sleep(1000);
            string actualResultURL = _webDriver.Url;
            Assert.AreEqual("https://newbookmodels.com/explore", actualResultURL);
        }

        //[Test]
        //public void RegistrationNegativeTest()
        //{
        //    IWebElement navBarSignUpButton = _webDriver.FindElement(By.ClassName("Navbar__signUp--12ZDV"));
        //    navBarSignUpButton.Click();
        //    IWebElement signupNextButton = _webDriver.FindElement(By.CssSelector("[type='submit']"));
        //    signupNextButton.Click();
        //    Thread.Sleep(1000);
        //    IWebElement signupFinishButton = _webDriver.FindElement(By.CssSelector("[type='submit']"));
        //    signupFinishButton.Click();
        //    Thread.Sleep(1000);
        //    string expectedResultURL = "https://newbookmodels.com/join";
        //    string actualResultURL = _webDriver.Url;
        //    Assert.AreEqual(expectedResultURL, actualResultURL);
        //}


        [Test]
        public void LoginWithWrongCredential()
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