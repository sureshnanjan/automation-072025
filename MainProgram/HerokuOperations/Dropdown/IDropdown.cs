using OpenQA.Selenium;              // For IWebDriver and IWebElement
using OpenQA.Selenium.Chrome;       // For ChromeDriver
using OpenQA.Selenium.Support.UI;   // For WebDriverWait and SelectElement
using System;                       // For TimeSpan

namespace Dropdown
{
    // Parameters required for dropdown testing using Selenium
    public class DropdownHandler
    {
        private IWebDriver driver;          // Controls the browser instance (Chrome, Firefox, etc.)
        private WebDriverWait wait;         // Provides explicit wait functionality for specific elements or conditions
        private IWebElement dropdown;       // Represents the <select> HTML element on the page
        private SelectElement select;       // Wrapper around the <select> element to simplify dropdown interactions

        // Constructor to initialize the fields
        public DropdownHandler(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}