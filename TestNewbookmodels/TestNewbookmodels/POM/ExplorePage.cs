using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNewbookmodels.POM
{
    class ExplorePage
    {
        private readonly IWebDriver _webDriver;

        public ExplorePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
    }
}
