using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNewbookmodels.POM
{
    class SignUpSecondPage
    {
        private readonly IWebDriver _webDriver;

        private readonly By _companyNameField = By.CssSelector("[name='company_name']");
        private readonly By _companyWebsiteField = By.CssSelector("[name='company_website']");
        private readonly By _locationField = By.CssSelector("[name='location']");
        private readonly By _locationGoogle = By.CssSelector("[class='pac-item']");
        private readonly By _industryInput = By.CssSelector("[name='industry']");
        private readonly By _industryOption = By.CssSelector("[role='option']");
        private readonly By _signupFinishButton = By.CssSelector("[type='submit']");

    }
}
