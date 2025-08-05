using HerokuOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace HerokuAppWeb
{
    public class ABTesting : IABTest
    {
        private IWebDriver driver;
        private By titlelocator;
        private By desclocator;
        public void DisableABTest()
        {
            Cookie diasableABTest = new Cookie("optimizelyOptOut","true");
            this.driver.Manage().Cookies.AddCookie(diasableABTest);
        }

        public string GetDescription()
        {
            throw new NotImplementedException();
        }

        public string GetTitle()
        {
            throw new NotImplementedException();
        }
    }
}
