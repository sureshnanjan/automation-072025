using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using System;

namespace HerokuTests

{
    [TestClass]
    public class DynamicControlsTests
    {
        // The error CS0101 indicates that there are multiple definitions of the 'DynamicControlsTests' class in the same namespace 'HerokuTests'.  
        // To fix this, ensure that there is only one definition of the 'DynamicControlsTests' class in the namespace.  
        // If there is another file with the same class definition, rename or remove the duplicate class.  

        // Assuming this file contains the correct implementation, you should check other files in the 'HerokuTests' namespace for duplicate definitions.  
        // If you find a duplicate, either rename the class or remove it if it is not needed.  

        // If you cannot locate the duplicate, please provide additional files or information for further assistance.
        private IWebDriver driver;
        private IDynamicControlsPage page;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            page = new DynamicControlsPage(driver); // Your implementation of the interface
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Checkbox_Remove_Then_Add()
        {
            // Remove
            page.ClickRemoveOrAddButton();
            Assert.IsFalse(page.IsCheckboxDisplayed(), "Checkbox should be removed.");
            Assert.AreEqual("It's gone!", page.GetCheckboxMessage());

            // Add
            page.ClickRemoveOrAddButton();
            Assert.IsTrue(page.IsCheckboxDisplayed(), "Checkbox should be added back.");
            Assert.AreEqual("It's back!", page.GetCheckboxMessage());
        }

        [TestMethod]
        public void Input_Enable_Then_Disable()
        {
            // Enable
            page.ClickEnableOrDisableButton();
            Assert.IsTrue(page.IsInputEnabled(), "Input field should be enabled.");
            Assert.AreEqual("It's enabled!", page.GetInputMessage());

            // Type text
            page.EnterText("Selenium Test");

            // Disable
            page.ClickEnableOrDisableButton();
            Assert.IsFalse(page.IsInputEnabled(), "Input field should be disabled.");
            Assert.AreEqual("It's disabled!", page.GetInputMessage());
        }
    }
}
