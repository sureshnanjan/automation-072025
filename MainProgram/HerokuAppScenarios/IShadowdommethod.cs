// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShadowDomHandlerTests.cs" company="Keyur Nagvekar">
//   Copyright (c) 2025 Keyur Nagvekar. All rights reserved.
//   This file contains automated test cases for the ShadowDomHandler class,
//   verifying behavior of Shadow DOM element interactions using JavaScript execution.
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
    /// Tests ShadowDomHandler methods to verify Shadow DOM interactions on
    /// https://the-internet.herokuapp.com/shadowdom.
    /// </summary>
    [TestClass]
    public class ShadowDomHandlerTests
    {
        private IWebDriver driver;
        private ShadowDomHandler shadowDom;

        /// <summary>
        /// Initializes the ChromeDriver and navigates to the Shadow DOM page.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/shadowdom");
            shadowDom = new ShadowDomHandler(driver);
        }

        /// <summary>
        /// Quits the browser after each test.
        /// </summary>
        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        /// <summary>
        /// Validates the first shadow host’s paragraph text.
        /// </summary>
        [TestMethod]
        public void GetFirstShadowHostText_ReturnsExpectedText()
        {
            string expected = "My default text";
            string actual = shadowDom.GetFirstShadowHostText();
            Assert.AreEqual(expected, actual, "Mismatch in first shadow host paragraph text.");
        }

        /// <summary>
        /// Validates the second shadow host’s span text.
        /// </summary>
        [TestMethod]
        public void GetSecondShadowHostText_ReturnsExpectedText()
        {
            string expected = "Let's have some different text!";
            string actual = shadowDom.GetSecondShadowHostText();
            Assert.AreEqual(expected, actual, "Mismatch in second shadow host span text.");
        }

        /// <summary>
        /// Validates text from a nested shadow DOM structure.
        /// </summary>
        [TestMethod]
        public void GetNestedShadowText_ReturnsExpectedText()
        {
            string expected = "Let's have some different text!";
            string actual = shadowDom.GetNestedShadowText();
            Assert.AreEqual(expected, actual, "Mismatch in nested shadow text.");
        }
    }
}
