using OpenQA.Selenium;              // For IWebDriver and IWebElement
using OpenQA.Selenium.Chrome;       // For ChromeDriver
using OpenQA.Selenium.Support.UI;   // For WebDriverWait and SelectElement
using System;                       // For TimeSpan

IWebDriver driver;                  // Controls the browser instance (Chrome, Firefox, etc.)
WebDriverWait wait;                // Provides explicit wait functionality for specific elements or conditions
IWebElement dropdown;              // Represents the <select> HTML element on the page
SelectElement select;              // Wrapper around the <select> element to simplify dropdown interactions
