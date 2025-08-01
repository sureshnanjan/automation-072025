using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

namespace HerokuOperationsTests
{
    [TestClass]
    public class DynamicControlsPageTests
    {
        private IWebDriver driver;
        private DynamicControlsPage dynamicControls;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
            dynamicControls = new DynamicControlsPage(driver);
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Checkbox_CanBeRemovedAndAdded()
        {
            // Arrange
            bool initiallyPresent = dynamicControls.IsCheckboxDisplayed();

            // Act - Remove Checkbox
            dynamicControls.ClickRemoveOrAddButton();
            bool isRemoved = !dynamicControls.IsCheckboxDisplayed();
            string removeMsg = dynamicControls.GetCheckboxMessage();

            // Assert
            Assert.IsTrue(isRemoved, "Checkbox should be removed.");
            Assert.AreEqual("It's gone!", removeMsg, "Remove message mismatch.");

            // Act - Add Checkbox back
            dynamicControls.ClickRemoveOrAddButton();
            bool isReadded = dynamicControls.IsCheckboxDisplayed();
            string addMsg = dynamicControls.GetCheckboxMessage();

            // Assert
            Assert.IsTrue(isReadded, "Checkbox should be added back.");
            Assert.AreEqual("It's back!", addMsg, "Add message mismatch.");
        }

        [TestMethod]
        public void Input_CanBeEnabledAndDisabled()
        {
            // Act - Enable input
            dynamicControls.ClickEnableOrDisableButton();
            bool isEnabled = dynamicControls.IsInputEnabled();
            string enableMsg = dynamicControls.GetInputMessage();

            // Assert
            Assert.IsTrue(isEnabled, "Input field should be enabled.");
            Assert.AreEqual("It's enabled!", enableMsg, "Enable message mismatch.");

            // Act - Disable input
            dynamicControls.ClickEnableOrDisableButton();
            bool isDisabled = !dynamicControls.IsInputEnabled();
            string disableMsg = dynamicControls.GetInputMessage();

            // Assert
            Assert.IsTrue(isDisabled, "Input field should be disabled.");
            Assert.AreEqual("It's disabled!", disableMsg, "Disable message mismatch.");
        }

        [TestMethod]
        public void Input_CanAcceptTextWhenEnabled()
        {
            // Arrange - Enable input
            dynamicControls.ClickEnableOrDisableButton();
            Assert.IsTrue(dynamicControls.IsInputEnabled(), "Input should be enabled to send keys.");

            // Act
            dynamicControls.EnterText("Hello Test");
            string inputValue = driver.FindElement(By.XPath("//form[@id='input-example']/input")).GetAttribute("value");

            // Assert
            Assert.AreEqual("Hello Test", inputValue, "Input text mismatch.");
        }
    }
}
