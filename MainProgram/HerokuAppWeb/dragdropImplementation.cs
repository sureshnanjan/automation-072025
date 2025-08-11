// -----------------------------------------------------------------------------
// <copyright file="DragDrop.cs" author="Teja Reddy">
//     © 2025 Teja Reddy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------
//
// Simple Selenium WebDriver implementation for drag and drop of boxes A and B
// on https://the-internet.herokuapp.com/drag_and_drop
//

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace HerokuOperations
{
    /// <summary>
    /// Handles drag and drop actions between two boxes (A and B) on the HerokuApp page.
    /// </summary>
    public class dragdropImplementation
    {
        private IWebDriver driver;
        private Actions actions;

        /// <summary>
        /// Constructor initializes the WebDriver and Actions class.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance</param>
        public dragdropImplementation(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
        }

        /// <summary>
        /// Drags Box A and drops it onto Box B.
        /// </summary>
        public void DragAtoB()
        {
            var boxA = driver.FindElement(By.Id("column-a"));
            var boxB = driver.FindElement(By.Id("column-b"));
            actions.DragAndDrop(boxA, boxB).Perform();
        }

        /// <summary>
        /// Drags Box B and drops it onto Box A.
        /// </summary>
        public void DragBtoA()
        {
            var boxA = driver.FindElement(By.Id("column-a"));
            var boxB = driver.FindElement(By.Id("column-b"));
            actions.DragAndDrop(boxB, boxA).Perform();
        }

        /// <summary>
        /// Returns the label text (A or B) from inside Box A.
        /// </summary>
        public string GetBoxALabel()
        {
            return driver.FindElement(By.CssSelector("#column-a header")).Text.Trim();
        }

        /// <summary>
        /// Returns the label text (A or B) from inside Box B.
        /// </summary>
        public string GetBoxBLabel()
        {
            return driver.FindElement(By.CssSelector("#column-b header")).Text.Trim();
        }
    }
}
