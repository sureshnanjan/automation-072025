// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicLoadingTests.cs" company="Keyur Nagvekar">
//   Copyright (c) 2025 Keyur Nagvekar. All rights reserved.
//   This file provides MSTest test cases for the DynamicLoading class,
//   which interacts with dynamically loading content on the Herokuapp example page.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using System.Threading;

namespace HerokuOperationsTests
{
    /// <summary>
    /// Tests the DynamicLoading class for dynamic content interaction on
    /// https://the-internet.herokuapp.com/dynamic_loading.
    /// </summary>
    [TestClass]
    public class DynamicLoadingTests
    {
        private IWebDriver driver;
        private DynamicLoading dynamicLoading;

        /// <summary>
        /// Sets up the ChromeDriver and DynamicLoading instance before each test.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            dynamicLoading = new DynamicLoading(driver);
        }

        /// <summary>
        /// Tears down the driver instance after each test.
        /// </summary>
        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }

        /// <summary>
        /// Verifies that Example 1 loads the correct "Hello World!" text.
        /// </summary>
        [TestMethod]
        public void Example1_LoadsHelloWorldSuccessfully()
        {
            dynamicLoading.NavigateToExample(1);
            dynamicLoading.ClickStartButton();
            dynamicLoading.WaitForLoadingToFinish();
            string result = dynamicLoading.GetResultText();
            Assert.AreEqual("Hello World!", result, "Text from Example 1 was incorrect.");
        }

        /// <summary>
        /// Verifies that Example 2 loads the correct "Hello World!" text.
        /// </summary>
        [TestMethod]
        public void Example2_LoadsHelloWorldSuccessfully()
        {
            dynamicLoading.NavigateToExample(2);
            dynamicLoading.ClickStartButton();
            dynamicLoading.WaitForLoadingToFinish();
            string result = dynamicLoading.GetResultText();
            Assert.AreEqual("Hello World!", result, "Text from Example 2 was incorrect.");
        }

        /// <summary>
        /// Ensures that the loading spinner becomes visible after clicking Start.
        /// </summary>
        [TestMethod]
        public void LoadingIndicator_IsVisibleDuringLoad()
        {
            dynamicLoading.NavigateToExample(2);
            dynamicLoading.ClickStartButton();
            Thread.Sleep(500);
            Assert.IsTrue(dynamicLoading.IsLoadingIndicatorVisible(), "Spinner was not visible.");
        }

        /// <summary>
        /// Validates that an exception is thrown when navigating to unsupported example numbers.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NavigateToExample_InvalidExampleNumber_ThrowsException()
        {
            dynamicLoading.NavigateToExample(5);
        }
    }
}
