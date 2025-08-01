// Author: Siva Sree
// Date Created: 2025-07-31
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# NUnit test class validates the behavior of the Forgot Password functionality
// on the HerokuApp using the IForgotPasswordPage interface. The focus is on input field
// acceptance, response messaging, UI visibility, usability, and edge case handling without
// relying on any underlying implementation such as browser drivers.

using NUnit.Framework;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test class for validating Forgot Password form behavior using the IForgotPasswordPage interface.
    /// </summary>
    [TestFixture]
    public class ForgotPasswordTests
    {
       
        /// <summary>
        /// ✅ Verifies the email field accepts a properly formatted valid email address.
        /// </summary>
        [Test]
        public void EmailField_ShouldAcceptValidEmail()
        {
            // Arrange
            string testEmail = "test@example.com";

            // Act
            forgotPage.EnterEmail(testEmail);
            bool isAccepted = forgotPage.IsEmailFieldAcceptingInput();

            // Assert
            Assert.IsTrue(isAccepted, "Email field should accept valid email input.");
        }

        /// <summary>
        /// ✅ Verifies the system handles empty input submission gracefully.
        /// </summary>
        [Test]
        public void EmailField_ShouldRejectEmptyInput()
        {
            // Act
            forgotPage.EnterEmail("");
            forgotPage.Submit();
            string message = forgotPage.GetConfirmationMessage();

            // Assert
            Assert.IsNotEmpty(message, "Empty input should trigger a confirmation or error message.");
        }

        /// <summary>
        /// ✅ Verifies a success message appears after submitting a valid email.
        /// </summary>
        [Test]
        public void Submit_ShouldTriggerSuccessMessage()
        {
            // Arrange
            forgotPage.EnterEmail("user@domain.com");

            // Act
            forgotPage.Submit();
            string message = forgotPage.GetConfirmationMessage();

            // Assert
            Assert.IsTrue(message.ToLower().Contains("email has been sent"),
                "Expected success message was not found after submission.");
        }

        /// <summary>
        /// ✅ Verifies that the submit button is visible on the page.
        /// </summary>
        [Test]
        public void SubmitButton_ShouldBeVisible()
        {
            // Act
            bool isVisible = forgotPage.IsSubmitButtonVisible();

            // Assert
            Assert.IsTrue(isVisible, "Submit button should be visible to the user.");
        }

        /// <summary>
        /// ✅ Verifies the placeholder text inside the email field is set to the expected format.
        /// </summary>
        [Test]
        public void PlaceholderText_ShouldBeEmail()
        {
            // Act
            string placeholder = forgotPage.GetEmailPlaceholder();

            // Assert
            Assert.AreEqual("email@example.com", placeholder, "Email field placeholder text is incorrect.");
        }

        /// <summary>
        /// ✅ Verifies the current page URL contains the keyword 'forgot_password'.
        /// </summary>
        [Test]
        public void PageUrl_ShouldContainForgotPassword()
        {
            // Act
            string url = forgotPage.GetCurrentUrl();

            // Assert
            Assert.IsTrue(url.Contains("forgot_password"),
                "URL does not contain the expected 'forgot_password' keyword.");
        }

        /// <summary>
        /// ✅ Verifies the page title contains the text 'Forgot Password'.
        /// </summary>
        [Test]
        public void PageTitle_ShouldBeForgotPassword()
        {
            // Act
            string title = forgotPage.GetPageTitle();

            // Assert
            Assert.IsTrue(title.ToLower().Contains("forgot password"),
                "Page title does not contain expected 'Forgot Password' text.");
        }

        /// <summary>
        /// ✅ Verifies that even an invalid email format is allowed for submission (form behavior test).
        /// </summary>
        [Test]
        public void InvalidEmailFormat_ShouldStillAllowSubmission()
        {
            // Arrange
            forgotPage.EnterEmail("invalid-email");

            // Act
            forgotPage.Submit();
            string message = forgotPage.GetConfirmationMessage();

            // Assert
            Assert.IsNotNull(message, "Form did not respond to invalid email submission.");
        }

        /// <summary>
        /// ✅ Verifies that repeated submissions do not break or crash the form logic.
        /// </summary>
        [Test]
        public void SubmitMultipleTimes_ShouldNotCrash()
        {
            // Arrange
            forgotPage.EnterEmail("repeat@test.com");

            // Act & Assert
            for (int i = 0; i < 5; i++)
            {
                forgotPage.Submit();
                string message = forgotPage.GetConfirmationMessage();
                Assert.IsNotEmpty(message, $"No message shown on submission attempt #{i + 1}.");
            }
        }
    }
}
