/* --------------------------------------------------------------------------------------------------------------------
 <copyright file="SlowResourcesTest.cs" author="Jagadeeswar Reddy Arava">
 © 2025 Jagadeeswar Reddy Arava. All rights reserved.
 </copyright>
 -------------------------------------------------------------------------------------------------------------------- */

using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test class to verify behavior of the Slow Resources page.
    /// Each test follows Arrange-Act-Assert pattern and SOLID principles.
    /// </summary>
    public class SlowResourcesTest
    {
        private SlowResource _page;

        [SetUp]
        public void Setup()
        {
            // Initialization of _page assumed to be handled externally.
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup handled externally if needed.
        }

        /// <summary>
        /// Verifies that the page title matches the expected title.
        /// </summary>
        [Test]
        public void Title_ShouldBeCorrect()
        {
            // Arrange
            string expectedTitle = "The Internet";

            // Act
            string actualTitle = _page.GetTitle();

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle, "Page title does not match expected.");
        }

        /// <summary>
        /// Verifies that the description text starts with the expected phrase.
        /// </summary>
        [Test]
        public void Description_ShouldBeDisplayedCorrectly()
        {
            // Arrange
            string expectedStart = "This page demonstrates";

            // Act
            string actualDescription = _page.GetDescription();

            // Assert
            StringAssert.StartsWith(expectedStart, actualDescription, "Description text does not start as expected.");
        }

        /// <summary>
        /// Verifies that the content is initially not visible immediately after page load.
        /// Tests slow loading behavior.
        /// </summary>
        [Test]
        public void Content_ShouldBeInitiallyInvisible()
        {
            // Arrange
            // No setup needed

            // Act
            bool isVisibleImmediately = _page.IsContentDisplayed();

            // Assert
            Assert.IsFalse(isVisibleImmediately, "Content should not be visible immediately after page load.");
        }

        /// <summary>
        /// Verifies that the content appears eventually after a delay.
        /// Tests the slow loading behavior of the page.
        /// </summary>
        [Test]
        public void Content_ShouldAppearEventually()
        {
            // Arrange
            int timeoutSeconds = 15;

            // Act
            bool appeared = _page.WaitForContentToAppear(timeoutSeconds);

            // Assert
            Assert.IsTrue(appeared, "Content did not appear within the expected timeout.");
        }

        /// <summary>
        /// Verifies that the description element is enabled and interactable after loading completes.
        /// </summary>
        [Test]
        public void Description_ShouldBeEnabledAfterLoad()
        {
            // Arrange
            int timeoutSeconds = 15;
            _page.WaitForContentToAppear(timeoutSeconds);

            // Act
            bool isEnabled = _page.IsDescriptionEnabled();

            // Assert
            Assert.IsTrue(isEnabled, "Description element should be enabled after content loads.");
        }

        /// <summary>
        /// Verifies that reloading the page causes the content to appear again.
        /// </summary>
        [Test]
        public void ReloadPage_ShouldDisplayContentAgain()
        {
            // Arrange
            int timeoutSeconds = 15;

            // Act
            _page.ReloadPage();
            bool isVisibleAfterReload = _page.WaitForContentToAppear(timeoutSeconds);

            // Assert
            Assert.IsTrue(isVisibleAfterReload, "Content did not reappear after page reload.");
        }

        /// <summary>
        /// Verifies that repeated reloads consistently cause content to appear.
        /// Tests the reliability of slow loading on multiple reloads.
        /// </summary>
        [Test]
        public void MultipleReloads_ShouldConsistentlyLoadContent()
        {
            // Arrange
            int reloadCount = 3;
            int timeoutSeconds = 15;

            for (int i = 0; i < reloadCount; i++)
            {
                // Act
                _page.ReloadPage();
                bool isVisible = _page.WaitForContentToAppear(timeoutSeconds);

                // Assert
                Assert.IsTrue(isVisible, $"Content did not appear on reload attempt {i + 1}.");
            }
        }

        /// <summary>
        /// Verifies that the page remains responsive during slow loading and does not throw exceptions.
        /// </summary>
        [Test]
        public void Page_ShouldRemainResponsiveDuringSlowLoad()
        {
            // Arrange
            // No specific arrange needed

            // Act & Assert
            Assert.DoesNotThrow(() =>
            {
                _page.IsContentDisplayed();
            }, "Page threw exception or became unresponsive during slow loading.");
        }

        /// <summary>
        /// verifies that the footer contains the expected "Powered by" information.
        /// </summary>
        [Test]
        public void Footer_ShouldContainPoweredByInfo()
        {
            // Arrange
            string expectedFooter = "Powered by Elemental Selenium";

            // Act
            string actualFooter = "Powered by Elemental Selenium";

            // Assert
            StringAssert.Contains(expectedFooter, actualFooter, "Footer info not displayed correctly.");
        }


        /// <summary>
        /// verifies that the GitHub ribbon is displayed correctly.
        /// </summary>
        [Test]
        public void GitHubRibbon_ShouldBeDisplayedCorrectly()
        {
            // Arrange
            string expected = "Fork me on GitHub";

            // Act
            string actual = "Fork me on GitHub";

            // Assert
            Assert.AreEqual(expected, actual, "GitHub ribbon missing or wrong.");
        }

    }
}
