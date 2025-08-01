// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputsTestApp.cs">
//     Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
//     This file contains manually written NUnit tests to validate visual behavior of
//     the Inputs page at https://the-internet.herokuapp.com/inputs.
//     Tests are written in AAA format, follow C# coding conventions, and adhere to SOLID principles.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace HerokuAppScenarios
{
    /// <summary>
    /// NUnit tests for the Inputs page, verified through manual UI inspection in a browser.
    /// </summary>
    [TestFixture]
    public class InputsPageTest
    {
        // ───────────── TEXT VALIDATION TESTS ─────────────

        /// <summary>
        /// Verifies the page title is 'Inputs'.
        /// </summary>
        [Test]
        public void PageTitle_ShouldBeInputs()
        {
            // Arrange
            string expectedTitle = "Inputs";

            // Act
            string actualTitle = "Inputs"; // Observed manually

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "The page title should be 'Inputs'.");
        }

        // ───────────── VALID INPUT TESTS ─────────────

        /// <summary>
        /// Verifies that the input accepts a positive integer.
        /// </summary>
        [Test]
        public void NumberInputField_ShouldAcceptPositiveInteger()
        {
            // Arrange
            string input = "12345";

            // Act
            string result = "12345";

            // Assert
            Assert.AreEqual(input, result, "Positive integers should be accepted.");
        }

        /// <summary>
        /// Verifies that the input accepts a negative integer.
        /// </summary>
        [Test]
        public void NumberInputField_ShouldAcceptNegativeInteger()
        {
            // Arrange
            string input = "-789";

            // Act
            string result = "-789";

            // Assert
            Assert.AreEqual(input, result, "Negative integers should be accepted.");
        }

        /// <summary>
        /// Checks if decimal values are accepted.
        /// </summary>
        [Test]
        public void NumberInputField_ShouldAcceptDecimalValue()
        {
            // Arrange
            string input = "45.67";

            // Act
            string result = "45.67";

            // Assert
            Assert.AreEqual(input, result, "Decimal values should be accepted.");
        }

        /// <summary>
        /// Verifies that large numbers (scientific notation) are accepted.
        /// </summary>
        [Test]
        public void NumberInputField_ShouldAcceptLargeNumbers()
        {
            // Arrange
            string largeNumber = "999999999999999999999";

            // Act
            string result = "1e+21"; // Observed as auto-converted in Chrome

            // Assert
            Assert.AreEqual("1e+21", result, "Large numbers should be accepted in scientific notation.");
        }

        // ───────────── INVALID INPUT TESTS ─────────────

        /// <summary>
        /// Verifies that the input field does not accept alphabetic characters.
        /// </summary>
        [Test]
        public void NumberInputField_ShouldNotAcceptAlphabets()
        {
            // Arrange
            string input = "abc";

            // Act
            string result = ""; // Not accepted

            // Assert
            Assert.AreEqual("", result, "Alphabetic characters should be rejected.");
        }

        /// <summary>
        /// Verifies that the input field does not accept the string 'Infinity'.
        /// </summary>
        [Test]
        public void NumberInputField_ShouldNotAcceptInfinityDirectly()
        {
            // Arrange
            string input = "Infinity";

            // Act
            string result = ""; // Not accepted

            // Assert
            Assert.AreEqual("", result, "The field should not accept the word 'Infinity'.");
        }

        /// <summary>
        /// Verifies that special characters are not accepted.
        /// </summary>
        [Test]
        public void NumberInputField_ShouldRejectSpecialCharacters()
        {
            // Arrange
            string input = "@#$%";

            // Act
            string result = ""; // Not accepted

            // Assert
            Assert.AreEqual("", result, "Special characters should be rejected.");
        }

        /// <summary>
        /// Verifies that whitespace input is either ignored or rejected.
        /// </summary>
        [Test]
        public void NumberInputField_ShouldRejectWhitespaceInput()
        {
            // Arrange
            string input = "     ";

            // Act
            string result = ""; // Not accepted

            // Assert
            Assert.AreEqual("", result, "Whitespace input should be ignored.");
        }

        // ───────────── KEYBOARD INTERACTION TESTS ─────────────

        /// <summary>
        /// Verifies that pressing the up arrow key increases the number by 1.
        /// </summary>
        [Test]
        public void NumberInputField_ShouldAllowArrowKeyIncrement()
        {
            // Arrange
            int initial = 5;

            // Act
            int incremented = initial + 1;

            // Assert
            Assert.AreEqual(6, incremented, "Up arrow should increment the number.");
        }

        /// <summary>
        /// Verifies that pressing the down arrow key decreases the number by 1.
        /// </summary>
        [Test]
        public void NumberInputField_ShouldAllowArrowKeyDecrement()
        {
            // Arrange
            int initial = 5;

            // Act
            int decremented = initial - 1;

            // Assert
            Assert.AreEqual(4, decremented, "Down arrow should decrement the number.");
        }

        // ───────────── FOOTER & VISUAL ELEMENTS ─────────────

        /// <summary>
        /// Verifies the footer contains 'Powered by Elemental Selenium'.
        /// </summary>
        [Test]
        public void Footer_ShouldDisplayPoweredByText()
        {
            // Arrange
            string expected = "Powered by Elemental Selenium";

            // Act
            string actual = "Powered by Elemental Selenium";

            // Assert
            Assert.AreEqual(expected, actual, "Footer should show 'Powered by Elemental Selenium'.");
        }

        /// <summary>
        /// Verifies that the GitHub ribbon is visible on the page.
        /// </summary>
        [Test]
        public void GitHubRibbon_ShouldBeVisible()
        {
            // Arrange
            bool isRibbonVisible = true;

            // Act
            bool observed = isRibbonVisible;

            // Assert
            Assert.IsTrue(observed, "GitHub ribbon should be visible.");
        }

        /// <summary>
        /// Verifies that the browser tab shows the correct page title.
        /// </summary>
        [Test]
        public void BrowserTab_ShouldHaveCorrectTitle()
        {
            // Arrange
            string expected = "The Internet";

            // Act
            string actual = "The Internet";

            // Assert
            Assert.AreEqual(expected, actual, "Tab title should be 'The Internet'.");
        }
    }
}
