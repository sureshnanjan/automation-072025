// Author: Siva Sree
// Date Created: 2025-07-31
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# NUnit test class validates the behavior of the Forgot Password functionality
// on the HerokuApp using the IForgotPassword interface. The focus is on input field
// acceptance, response messaging, UI visibility, usability, and edge case handling without
// relying on any underlying implementation such as browser drivers.

using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test class for validating Forgot Password form behavior using the IForgotPassword interface.
    /// </summary>
    [TestFixture]
    public class ForgotPasswordTests
    {
        [Test]
        public void EmailField_ShouldAcceptValidEmail()
        {
            // Arrange
            string testEmail = "test@example.com";
            IForgotPassword forgotPage = new ForgotPasswordPage();

            // Act
            forgotPage.EnterEmail(testEmail);
            bool isAccepted = forgotPage.IsEmailFieldAcceptingInput();

            // Assert
            Assert.IsTrue(isAccepted, "Email field should accept valid email input.");
        }

        [Test]
        public void EmailField_ShouldRejectEmptyInput()
        {
            // Arrange
            string testEmail = "";
            IForgotPassword forgotPage = new ForgotPasswordPage();

            // Act
            forgotPage.EnterEmail(testEmail);
            forgotPage.Submit();
            string message = forgotPage.GetConfirmationMessage();

            // Assert
            Assert.IsNotEmpty(message, "Empty input should trigger a confirmation or error message.");
        }

        [Test]
        public void Submit_ShouldTriggerSuccessMessage()
        {
            // Arrange
            string validEmail = "user@domain.com";
            IForgotPassword forgotPage = new ForgotPasswordPage();
            forgotPage.EnterEmail(validEmail);

            // Act
            forgotPage.Submit();
            string message = forgotPage.GetConfirmationMessage();

            // Assert
            Assert.IsTrue(message.ToLower().Contains("email has been sent"),
                "Expected success message was not found after submission.");
        }

        [Test]
        public void SubmitButton_ShouldBeVisible()
        {
            // Arrange
            IForgotPassword forgotPage = new ForgotPasswordPage();

            // Act
            bool isVisible = forgotPage.IsSubmitButtonVisible();

            // Assert
            Assert.IsTrue(isVisible, "Submit button should be visible to the user.");
        }

        [Test]
        public void PlaceholderText_ShouldBeEmail()
        {
            // Arrange
            string expectedPlaceholder = "email@example.com";
            IForgotPassword forgotPage = new ForgotPasswordPage();

            // Act
            string actualPlaceholder = forgotPage.GetEmailPlaceholder();

            // Assert
            Assert.AreEqual(expectedPlaceholder, actualPlaceholder, "Email field placeholder text is incorrect.");
        }

        [Test]
        public void PageUrl_ShouldContainForgotPassword()
        {
            // Arrange
            IForgotPassword forgotPage = new ForgotPasswordPage();

            // Act
            string url = forgotPage.GetCurrentUrl();

            // Assert
            Assert.IsTrue(url.Contains("forgot_password"),
                "URL does not contain the expected 'forgot_password' keyword.");
        }

        [Test]
        public void PageTitle_ShouldBeForgotPassword()
        {
            // Arrange
            IForgotPassword forgotPage = new ForgotPasswordPage();

            // Act
            string title = forgotPage.GetPageTitle();

            // Assert
            Assert.IsTrue(title.ToLower().Contains("forgot password"),
                "Page title does not contain expected 'Forgot Password' text.");
        }

        [Test]
        public void InvalidEmailFormat_ShouldStillAllowSubmission()
        {
            // Arrange
            string invalidEmail = "invalid-email";
            IForgotPassword forgotPage = new ForgotPasswordPage();
            forgotPage.EnterEmail(invalidEmail);

            // Act
            forgotPage.Submit();
            string message = forgotPage.GetConfirmationMessage();

            // Assert
            Assert.IsNotNull(message, "Form did not respond to invalid email submission.");
        }

        [Test]
        public void SubmitMultipleTimes_ShouldNotCrash()
        {
            // Arrange
            string email = "repeat@test.com";
            IForgotPassword forgotPage = new ForgotPasswordPage();
            forgotPage.EnterEmail(email);

            // Act & Assert
            for (int i = 0; i < 5; i++)
            {
                forgotPage.Submit();
                string message = forgotPage.GetConfirmationMessage();

                // Assert inside loop
                Assert.IsNotEmpty(message, $"No message shown on submission attempt #{i + 1}.");
            }
        }
    }
}
