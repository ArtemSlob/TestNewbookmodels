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
            homeage.GoToHomepage()
                .ClickNavBarSignUpButton();

            var signUpPage = new SignUpPage(_webDriver);
            signUpPage.InputFirstNameField("Abdula")
                .InputLastNameField("Shchur")
                .InputEmailField("wrongEmail@gmail.com") // change email
                .InputPasswordField("Qwerty1!")
                .InputPasswordConfirmField("Qwerty1!")
                .InputPhoneNumberField("3425634634")
                .ClickSignupNextButton();



            //DateTime dateTimeNow = DateTime.Now;
            //string stringDateTimeNow = dateTimeNow.ToShortDateString() + "."
            //    + dateTimeNow.Hour.ToString() + dateTimeNow.Minute.ToString() + dateTimeNow.Second.ToString();

            //string now = DateTime.Now.ToString("ddMMyyyyhhmmss");
            //string email = now + "@test.com";

            ////IWebElement navBarSignUpButton = _webDriver.FindElement(By.ClassName("Navbar__signUp--12ZDV"));
            ////navBarSignUpButton.Click();
            ////IWebElement firstNameField = _webDriver.FindElement(By.CssSelector("[name='first_name']"));
            ////firstNameField.SendKeys("Abdula");
            ////IWebElement lastNameField = _webDriver.FindElement(By.CssSelector("[name='last_name']"));
            ////lastNameField.SendKeys("Shchur");
            ////IWebElement emailField = _webDriver.FindElement(By.CssSelector("[name='email']"));
            ////emailField.SendKeys($"abdula.shchur.{stringDateTimeNow}@gmail.com");
            ////IWebElement passwordField = _webDriver.FindElement(By.CssSelector("[name='password']"));
            ////passwordField.SendKeys("Qwerty1!");
            ////IWebElement passwordConfirmField = _webDriver.FindElement(By.CssSelector("[name='password_confirm']"));
            ////passwordConfirmField.SendKeys("Qwerty1!");
            ////IWebElement phoneNumberField = _webDriver.FindElement(By.CssSelector("[name='phone_number']"));
            ////phoneNumberField.SendKeys("3425634634");
            ////IWebElement signupNextButton = _webDriver.FindElement(By.CssSelector("[type='submit']"));
            ////signupNextButton.Click();
            IWebElement companyNameField = _webDriver.FindElement(By.CssSelector("[name='company_name']"));
            companyNameField.SendKeys("Abdula Inc.");
            IWebElement companyWebsiteField = _webDriver.FindElement(By.CssSelector("[name='company_website']"));
            companyWebsiteField.SendKeys("abdulashchur.com");
            IWebElement locationField = _webDriver.FindElement(By.CssSelector("[name='location']"));
            locationField.SendKeys("FGH Building, Harrison Avenue, Boston, MA, USA");
            WebDriverWait wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 20));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[class='pac-item']")));
            IWebElement locationGoogle = _webDriver.FindElement(By.CssSelector("[class='pac-item']"));
            locationGoogle.Click();
            IWebElement industryInput = _webDriver.FindElement(By.CssSelector("[name='industry']"));
            industryInput.Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[role='option']")));
            IWebElement industryOption = _webDriver.FindElements(By.CssSelector("[role='option']"))[0];
            industryOption.Click();
            Thread.Sleep(1000);
            IWebElement signupFinishButton = _webDriver.FindElement(By.CssSelector("[type='submit']"));
            signupFinishButton.Click();
            Thread.Sleep(1000);
            //string expectedResultURL = "https://newbookmodels.com/explore";
            //string actualResultURL = _webDriver.Url;
            //Assert.AreEqual(expectedResultURL, actualResultURL);
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