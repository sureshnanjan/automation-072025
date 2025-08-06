// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputPageTest.cs" company="K Vamsi Krishna">
//   Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
// </copyright>
// <summary>
//   NUnit test cases for validating the Inputs page behavior at https://the-internet.herokuapp.com/inputs.
//   Tests follow the AAA (Arrange, Act, Assert) format and use mocked interface interactions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using HerokuOperations;
using NUnit.Framework;

namespace HerokuTests
{
    /// <summary>
    /// Test suite for the Inputs Page on HerokuApp.
    /// Covers numeric input behaviors, including edge cases.
    /// </summary>
    [TestFixture]
    public class InputPageTest
    {
        private Iinput inputPage;

        [SetUp]
        public void SetUp()
        {
            inputPage = new MockInputPage(); // Stubbed dependency or mock
        }

        /// <summary>
        /// Validates that a positive integer input is accepted and returned correctly.
        /// </summary>
        [Test]
        public void Should_AcceptPositiveInteger()
        {
            // Arrange
            string input = "123";

            // Act
            inputPage.EnterNumber(input);
            string output = inputPage.GetInputValue();

            // Assert
            Assert.AreEqual(input, output);
        }

        /// <summary>
        /// Validates that a negative integer input is accepted and returned correctly.
        /// </summary>
        [Test]
        public void Should_AcceptNegativeInteger()
        {
            // Arrange
            string input = "-456";

            // Act
            inputPage.EnterNumber(input);
            string output = inputPage.GetInputValue();

            // Assert
            Assert.AreEqual(input, output);
        }

        /// <summary>
        /// Validates that decimal values are accepted or appropriately handled.
        /// </summary>
        [Test]
        public void Should_AcceptDecimalInput()
        {
            // Arrange
            string input = "123.45";

            // Act
            inputPage.EnterNumber(input);
            string output = inputPage.GetInputValue();

            // Assert
            Assert.AreEqual(input, output);
        }

        /// <summary>
        /// Validates that alphabetic characters are ignored or rejected.
        /// </summary>
        [Test]
        public void Should_RejectAlphabeticInput()
        {
            // Arrange
            string input = "abc";

            // Act
            inputPage.EnterNumber(input);
            string output = inputPage.GetInputValue();

            // Assert
            Assert.AreNotEqual(input, output);
        }

        /// <summary>
        /// Validates special characters do not affect the numeric field.
        /// </summary>
        [Test]
        public void Should_IgnoreSpecialCharacters()
        {
            // Arrange
            string input = "@#!$";

            // Act
            inputPage.EnterNumber(input);
            string output = inputPage.GetInputValue();

            // Assert
            Assert.AreNotEqual(input, output);
        }

        /// <summary>
        /// Validates that empty input returns empty value.
        /// </summary>
        [Test]
        public void Should_ReturnEmpty_WhenInputIsCleared()
        {
            // Arrange
            string input = "";

            // Act
            inputPage.EnterNumber(input);
            string output = inputPage.GetInputValue();

            // Assert
            Assert.AreEqual(string.Empty, output);
        }

        /// <summary>
        /// Validates large numeric inputs are handled without error.
        /// </summary>
        [Test]
        public void Should_HandleLargeNumericInput()
        {
            // Arrange
            string input = "9999999999";

            // Act
            inputPage.EnterNumber(input);
            string output = inputPage.GetInputValue();

            // Assert
            Assert.AreEqual(input, output);
        }
    }

    /// <summary>
    /// Mock implementation of the Iinput interface for testing purposes only.
    /// </summary>
    public class MockInputPage : Iinput
    {
        private string value = string.Empty;

        public void EnterNumber(string input)
        {
            // Simulate filtering invalid input as the real browser would
            if (decimal.TryParse(input, out _))
                value = input;
            else if (string.IsNullOrWhiteSpace(input))
                value = string.Empty;
        }

        public string GetInputValue()
        {
            return value;
        }
    }
}