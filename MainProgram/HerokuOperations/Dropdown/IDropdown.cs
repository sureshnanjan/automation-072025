using OpenQA.Selenium;              // For IWebDriver and IWebElement
using OpenQA.Selenium.Chrome;       // For ChromeDriver
using OpenQA.Selenium.Support.UI;   // For WebDriverWait and SelectElement
using System;                       // For TimeSpan

// Parameters required for dropdown testing using Selenium
private IWebDriver driver;          // Controls the browser instance (Chrome, Firefox, etc.)
private WebDriverWait wait;         // Provides explicit wait functionality for specific elements or conditions
private IWebElement dropdown;       // Represents the <select> HTML element on the page
private SelectElement select;       // Wrapper around the <select> element to simplify dropdown interactions
