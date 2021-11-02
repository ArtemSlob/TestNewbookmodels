using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestNewbookmodels
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://newbookmodels.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void SignupTest()
        {
            IWebElement navBarSignUpButton = driver.FindElement(By.ClassName("Navbar__signUp--12ZDV"));
            navBarSignUpButton.Click();
            IWebElement firstNameField = driver.FindElement(By.Name("first_name"));
            firstNameField.SendKeys("Abdula");
            IWebElement lastNameField = driver.FindElement(By.Name("last_name"));
            lastNameField.SendKeys("Shchur");
            IWebElement emailField = driver.FindElement(By.Name("email"));
            emailField.SendKeys("abdula.shchur@gmail.com");
            IWebElement passwordField = driver.FindElement(By.Name("password"));
            passwordField.SendKeys("Qwerty1!");
            IWebElement passwordConfirmField = driver.FindElement(By.Name("password_confirm"));
            passwordConfirmField.SendKeys("Qwerty1!");
            IWebElement phoneNumberField = driver.FindElement(By.Name("phone_number"));
            phoneNumberField.SendKeys("3425634634");
            //IWebElement refferalCodeField = driver.FindElement(By.Name("code"));
            //refferalCodeField.SendKeys("A34Fg");
            IWebElement signupNextButton = driver.FindElement(By.CssSelector("[type='submit']"));
            signupNextButton.Click();
            Assert.Pass();
        }

        [TearDown]
        public void After()
        {
            //driver.Quit();
        }
    }
}