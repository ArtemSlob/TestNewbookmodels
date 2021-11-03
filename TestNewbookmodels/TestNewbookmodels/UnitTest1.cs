using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestNewbookmodels
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://newbookmodels.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void RegistrationTest()
        {
            DateTime dateTimeNow = DateTime.Now;
            string stringDateTimeNow = dateTimeNow.ToShortDateString() + "." 
                + dateTimeNow.Hour.ToString() + dateTimeNow.Minute.ToString() + dateTimeNow.Second.ToString();
            IWebElement navBarSignUpButton = driver.FindElement(By.ClassName("Navbar__signUp--12ZDV"));
            navBarSignUpButton.Click();
            IWebElement firstNameField = driver.FindElement(By.CssSelector("[name='first_name']"));
            firstNameField.SendKeys("Abdula");
            IWebElement lastNameField = driver.FindElement(By.CssSelector("[name='last_name']"));
            lastNameField.SendKeys("Shchur");
            IWebElement emailField = driver.FindElement(By.CssSelector("[name='email']"));
            emailField.SendKeys($"abdula.shchur.{stringDateTimeNow}@gmail.com");
            IWebElement passwordField = driver.FindElement(By.CssSelector("[name='password']"));
            passwordField.SendKeys("Qwerty1!");
            IWebElement passwordConfirmField = driver.FindElement(By.CssSelector("[name='password_confirm']"));
            passwordConfirmField.SendKeys("Qwerty1!");
            IWebElement phoneNumberField = driver.FindElement(By.CssSelector("[name='phone_number']"));
            phoneNumberField.SendKeys("3425634634");
            IWebElement signupNextButton = driver.FindElement(By.CssSelector("[type='submit']"));
            signupNextButton.Click();
            IWebElement companyNameField = driver.FindElement(By.CssSelector("[name='company_name']"));
            companyNameField.SendKeys("Abdula Inc.");
            IWebElement companyWebsiteField = driver.FindElement(By.CssSelector("[name='company_website']"));
            companyWebsiteField.SendKeys("abdulashchur.com");
            IWebElement locationField = driver.FindElement(By.CssSelector("[name='location']"));
            locationField.SendKeys("FGH Building, Harrison Avenue, Boston, MA, USA");
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[class='pac-item']")));
            IWebElement locationGoogle = driver.FindElement(By.CssSelector("[class='pac-item']"));
            locationGoogle.Click();
            IWebElement industryInput = driver.FindElement(By.CssSelector("[name='industry']"));
            industryInput.Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("[role='option']")));
            IWebElement industryOption = driver.FindElements(By.CssSelector("[role='option']"))[0];
            industryOption.Click();
            Thread.Sleep(1000);
            IWebElement signupFinishButton = driver.FindElement(By.CssSelector("[type='submit']"));
            signupFinishButton.Click();
            Thread.Sleep(1000);
            string expectedResultURL = "https://newbookmodels.com/explore";
            string actualResultURL = driver.Url;
            Assert.AreEqual(expectedResultURL, actualResultURL);
        }

        [Test]
        public void RegistrationNegativeTest()
        {
            IWebElement navBarSignUpButton = driver.FindElement(By.ClassName("Navbar__signUp--12ZDV"));
            navBarSignUpButton.Click();
            IWebElement signupNextButton = driver.FindElement(By.CssSelector("[type='submit']"));
            signupNextButton.Click();
            Thread.Sleep(1000);
            IWebElement signupFinishButton = driver.FindElement(By.CssSelector("[type='submit']"));
            signupFinishButton.Click();
            Thread.Sleep(1000);
            string expectedResultURL = "https://newbookmodels.com/join";
            string actualResultURL = driver.Url;
            Assert.AreEqual(expectedResultURL, actualResultURL);
        }

        [TearDown]
        public void After()
        {
            driver.Dispose();
        }
    }
}