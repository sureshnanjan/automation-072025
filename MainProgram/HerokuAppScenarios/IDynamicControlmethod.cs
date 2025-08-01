// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicControlsPageTests.cs" company="Keyur Nagvekar">
//   Copyright (c) 2025 Keyur Nagvekar. All rights reserved.
//   This file provides automated MSTest test cases for verifying dynamic interactions
//   with checkbox and input controls on the Dynamic Controls page using the
//   DynamicControlsPage class.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

namespace HerokuOperationsTests
{
    /// <summary>
    /// Contains automated test cases for the DynamicControlsPage class, 
    /// which interacts with dynamic checkbox and input elements on 
    /// https://the-internet.herokuapp.com/dynamic_controls.
    /// </summary>
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
            bool initiallyPresent = dynamicControls.IsCheckboxDisplayed();

            dynamicControls.ClickRemoveOrAddButton();
            bool isRemoved = !dynamicControls.IsCheckboxDisplayed();
            string removeMsg = dynamicControls.GetCheckboxMessage();

            Assert.IsTrue(isRemoved, "Checkbox should be removed.");
            Assert.AreEqual("It's gone!", removeMsg);

            dynamicControls.ClickRemoveOrAddButton();
            bool isReadded = dynamicControls.IsCheckboxDisplayed();
            string addMsg = dynamicControls.GetCheckboxMessage();

            Assert.IsTrue(isReadded, "Checkbox should be added back.");
            Assert.AreEqual("It's back!", addMsg);
        }

        [TestMethod]
        public void Input_CanBeEnabledAndDisabled()
        {
            dynamicControls.ClickEnableOrDisableButton();
            bool isEnabled = dynamicControls.IsInputEnabled();
            string enableMsg = dynamicControls.GetInputMessage();

            Assert.IsTrue(isEnabled);
            Assert.AreEqual("It's enabled!", enableMsg);

            dynamicControls.ClickEnableOrDisableButton();
            bool isDisabled = !dynamicControls.IsInputEnabled();
            string disableMsg = dynamicControls.GetInputMessage();

            Assert.IsTrue(isDisabled);
            Assert.AreEqual("It's disabled!", disableMsg);
        }

        [TestMethod]
        public void Input_CanAcceptTextWhenEnabled()
        {
            dynamicControls.ClickEnableOrDisableButton();
            Assert.IsTrue(dynamicControls.IsInputEnabled());

            dynamicControls.EnterText("Hello Test");
            string inputValue = driver.FindElement(By.XPath("//form[@id='input-example']/input")).GetAttribute("value");

            Assert.AreEqual("Hello Test", inputValue);
        }
    }
}
