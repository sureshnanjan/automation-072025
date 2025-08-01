// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShadowDomHandlerTests.cs" company="Keyur Nagvekar">
//   Copyright (c) 2025 Keyur Nagvekar. All rights reserved.
//   This file contains automated NUnit test cases for the ShadowDomHandler class,
//   verifying behavior of Shadow DOM element interactions using JavaScript execution.
//   Redistribution or modification of this file is subject to author permissions.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;
using HerokuOperations;

namespace HerokuOperationsTests
{
    /// <summary>
    /// Contains NUnit test cases for verifying interactions with Shadow DOM elements
    /// on https://the-internet.herokuapp.com/shadowdom via the <see cref="ShadowDomHandler"/> class.
    /// </summary>
    [TestFixture]
    public class ShadowDomHandlerTests
    {
        private ShadowDomHandler shadowDom;
        /// <summary>
        /// Verifies the text content from the first shadow root host paragraph.
        /// </summary>
        [Test]
        public void GetFirstShadowHostText_ReturnsExpectedText()
        {
            string expected = "My default text";
            string actual = shadowDom.GetFirstShadowHostText();
            Assert.AreEqual(expected, actual, "Mismatch in first shadow host paragraph text.");
        }

        /// <summary>
        /// Verifies the text content from the second shadow host's span element.
        /// </summary>
        [Test]
        public void GetSecondShadowHostText_ReturnsExpectedText()
        {
            string expected = "Let's have some different text!";
            string actual = shadowDom.GetSecondShadowHostText();
            Assert.AreEqual(expected, actual, "Mismatch in second shadow host span text.");
        }

        /// <summary>
        /// Validates the text retrieved from within a nested Shadow DOM structure.
        /// </summary>
        [Test]
        public void GetNestedShadowText_ReturnsExpectedText()
        {
            string expected = "Let's have some different text!";
            string actual = shadowDom.GetNestedShadowText();
            Assert.AreEqual(expected, actual, "Mismatch in nested shadow text.");
        }

        /// <summary>
        /// Ensures all Shadow DOM methods return non-null strings.
        /// </summary>
        [Test]
        public void ShadowDomText_ShouldNotBeNullOrEmpty()
        {
            Assert.IsFalse(string.IsNullOrEmpty(shadowDom.GetFirstShadowHostText()), "First shadow text was null or empty.");
            Assert.IsFalse(string.IsNullOrEmpty(shadowDom.GetSecondShadowHostText()), "Second shadow text was null or empty.");
            Assert.IsFalse(string.IsNullOrEmpty(shadowDom.GetNestedShadowText()), "Nested shadow text was null or empty.");
        }

        /// <summary>
        /// Confirms that shadow DOM access is case-sensitive and validates accuracy.
        /// </summary>
        [Test]
        public void ShadowDomText_ShouldBeCaseSensitive()
        {
            string incorrect = "my default text";
            string actual = shadowDom.GetFirstShadowHostText();
            Assert.AreNotEqual(incorrect, actual, "Text comparison should be case-sensitive.");
        }

        /// <summary>
        /// Checks all Shadow DOM methods for trimmed output (no leading/trailing whitespace).
        /// </summary>
        [Test]
        public void ShadowDomText_ShouldBeTrimmed()
        {
            Assert.AreEqual(shadowDom.GetFirstShadowHostText().Trim(), shadowDom.GetFirstShadowHostText());
            Assert.AreEqual(shadowDom.GetSecondShadowHostText().Trim(), shadowDom.GetSecondShadowHostText());
            Assert.AreEqual(shadowDom.GetNestedShadowText().Trim(), shadowDom.GetNestedShadowText());
        }
    }
}
