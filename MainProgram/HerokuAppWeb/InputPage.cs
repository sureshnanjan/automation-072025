using HerokuOperations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace HerokuAppWeb
{
    /// <summary>
    /// Page class for the "Inputs" page on Herokuapp.
    /// This class allows entering numbers and simulating arrow key presses.
    /// </summary>
    public class InputPage : IInputPage
    {
        private ChromeDriver driver;          // WebDriver to control Chrome browser
        private string url;                   // URL of the Inputs page
        private By inputLocator;              // Locator for the input element on the page

        /// <summary>
        /// Constructor - Initializes the ChromeDriver, opens the page, and sets up the locator.
        /// </summary>
        public InputPage()
        {
            this.driver = new ChromeDriver();                       // Launch Chrome
            this.driver.Manage().Window.Maximize();                // Maximize browser window

            this.url = "https://the-internet.herokuapp.com/inputs"; // Store the URL
            this.driver.Navigate().GoToUrl(this.url);               // Open the Inputs page

            this.inputLocator = By.TagName("input");                // Locator using <input> tag
        }

        /// <summary>
        /// Navigates to the Inputs page again (in case of refresh or redirection).
        /// </summary>
        public void GotoPage()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        /// <summary>
        /// Enters a specific number into the input field.
        /// Clears any existing text before typing.
        /// </summary>
        /// <param name="number">The number to input as string.</param>
        public void EnterNumber(string number)
        {
            IWebElement input = this.driver.FindElement(this.inputLocator); // Find the input element
            input.Clear();                                                  // Clear existing value
            input.SendKeys(number);                                         // Type the new number
            Thread.Sleep(500);                                              // Wait briefly
        }

        /// <summary>
        /// Increases the input field value by pressing the Arrow Up key.
        /// </summary>
        /// <param name="steps">How many times to press the key.</param>
        public void IncreaseValue(int steps)
        {
            IWebElement input = this.driver.FindElement(this.inputLocator); // Locate the input box
            for (int i = 0; i < steps; i++)                                 // Repeat for number of steps
            {
                input.SendKeys(Keys.ArrowUp);                               // Simulate Arrow Up key
                Thread.Sleep(200);                                          // Wait briefly between presses
            }
        }

        /// <summary>
        /// Decreases the input field value by pressing the Arrow Down key.
        /// </summary>
        /// <param name="steps">How many times to press the key.</param>
        public void DecreaseValue(int steps)
        {
            IWebElement input = this.driver.FindElement(this.inputLocator); // Locate the input box
            for (int i = 0; i < steps; i++)                                 // Repeat for number of steps
            {
                input.SendKeys(Keys.ArrowDown);                             // Simulate Arrow Down key
                Thread.Sleep(200);                                          // Wait briefly between presses
            }
        }

        /// <summary>
        /// Returns the current value from the input field.
        /// </summary>
        /// <returns>Value as string.</returns>
        public string GetInputValue()
        {
            IWebElement input = this.driver.FindElement(this.inputLocator); // Find the input
            return input.GetAttribute("value");                             // Return its value
        }
    }
}
