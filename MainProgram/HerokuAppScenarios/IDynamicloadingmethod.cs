// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicLoadingTests.cs" company="Keyur Nagvekar">
//   Copyright (c) 2025 Keyur Nagvekar. All rights reserved.
//   This file provides automated NUnit test cases for the DynamicLoading class,
//   which interacts with dynamically loading content on the Herokuapp example page.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using OpenQA.Selenium;
using HerokuOperations;
using System;

namespace HerokuOperationsTests
{
    /// <summary>
    /// Contains NUnit test cases to verify the behavior of dynamically loading content
    /// using the <see cref="DynamicLoading"/> class on the page:
    /// https://the-internet.herokuapp.com/dynamic_loading
    /// </summary>
    [TestFixture]
    public class DynamicLoadingTests
    {
        private DynamicLoading dynamicLoading;

        /// <summary>
        /// Sets up a fresh <see cref="DynamicLoading"/> instance before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            dynamicLoading = new DynamicLoading(null); // WebDriver mocked or omitted
        }

        /// <summary>
        /// Validates that Example 1 loads the "Hello World!" message successfully after clicking Start.
        /// </summary>
        [Test]
        public void Example1_LoadsHelloWorldSuccessfully()
        {
            dynamicLoading.NavigateToExample(1);
            dynamicLoading.ClickStartButton();
            dynamicLoading.WaitForLoadingToFinish();
            string result = dynamicLoading.GetResultText();
            Assert.AreEqual("Hello World!", result, "Text from Example 1 was incorrect.");
        }

        /// <summary>
        /// Validates that Example 2 also loads the "Hello World!" message correctly.
        /// </summary>
        [Test]
        public void Example2_LoadsHelloWorldSuccessfully()
        {
            dynamicLoading.NavigateToExample(2);
            dynamicLoading.ClickStartButton();
            dynamicLoading.WaitForLoadingToFinish();
            string result = dynamicLoading.GetResultText();
            Assert.AreEqual("Hello World!", result, "Text from Example 2 was incorrect.");
        }

        /// <summary>
        /// Ensures the loading spinner becomes visible during content load in Example 2.
        /// </summary>
        [Test]
        public void LoadingIndicator_IsVisibleDuringLoad()
        {
            dynamicLoading.NavigateToExample(2);
            dynamicLoading.ClickStartButton();
            Assert.IsTrue(dynamicLoading.IsLoadingIndicatorVisible(), "Loading spinner was not visible during load.");
        }

        /// <summary>
        /// Confirms that navigating to an invalid example throws an <see cref="ArgumentException"/>.
        /// </summary>
        [Test]
        public void NavigateToExample_InvalidExampleNumber_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => dynamicLoading.NavigateToExample(5), "Invalid example should throw.");
        }

        /// <summary>
        /// Tests that result text is initially empty before loading begins.
        /// </summary>
        [Test]
        public void ResultText_InitiallyEmpty()
        {
            dynamicLoading.NavigateToExample(1);
            string result = dynamicLoading.GetResultText();
            Assert.IsTrue(string.IsNullOrEmpty(result), "Result text should be empty initially.");
        }

        /// <summary>
        /// Verifies that clicking the Start button changes the state of the loading indicator.
        /// </summary>
        [Test]
        public void StartButton_Click_ShouldTriggerLoading()
        {
            dynamicLoading.NavigateToExample(2);
            dynamicLoading.ClickStartButton();
            Assert.IsTrue(dynamicLoading.IsLoadingIndicatorVisible(), "Loading did not start.");
        }

        /// <summary>
        /// Confirms that WaitForLoadingToFinish waits for the result text to become non-empty.
        /// </summary>
        [Test]
        public void WaitForLoadingToFinish_PopulatesResultText()
        {
            dynamicLoading.NavigateToExample(1);
            dynamicLoading.ClickStartButton();
            dynamicLoading.WaitForLoadingToFinish();
            string result = dynamicLoading.GetResultText();
            Assert.AreEqual("Hello World!", result);
        }

        /// <summary>
        /// Ensures the component can be toggled between Example 1 and Example 2 without error.
        /// </summary>
        [Test]
        public void NavigateBetweenExamples_Successfully()
        {
            dynamicLoading.NavigateToExample(1);
            dynamicLoading.NavigateToExample(2);
            Assert.Pass("Navigation between examples succeeded.");
        }

        /// <summary>
        /// Confirms that calling methods without navigation throws InvalidOperationException.
        /// </summary>
        [Test]
        public void Methods_WithoutNavigation_ThrowInvalidOperation()
        {
            Assert.Throws<InvalidOperationException>(() => dynamicLoading.ClickStartButton());
            Assert.Throws<InvalidOperationException>(() => dynamicLoading.GetResultText());
            Assert.Throws<InvalidOperationException>(() => dynamicLoading.IsLoadingIndicatorVisible());
        }
    }
}
