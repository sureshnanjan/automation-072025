// -----------------------------------------------------------------------------
// <copyright>
//     Copyright (c) 2025 Teja Reddy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------
//
// NUnit tests for simple key press input display:
// "Press a key and see what you inputted."
// -----------------------------------------------------------------------------

using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// NUnit tests to verify key presses display the correct input text.
    /// </summary>
    [TestFixture]
    public class KeyPressesTests
    {
        private IKeyPresses _keyPressesPage;

        [SetUp]
        public void Setup()
        {
            _keyPressesPage = new KeyPressesPage();
        }

        /// <summary>
        /// Verify the page title text.
        /// </summary>
        [Test]
        public void Title_IsCorrect()
        {
            Assert.AreEqual("Key Presses", _keyPressesPage.GetTitle());
        }

        /// <summary>
        /// Verify the page description text.
        /// </summary>
        [Test]
        public void Description_IsCorrect()
        {
            Assert.AreEqual("Press any key and see what you inputted.", _keyPressesPage.GetDescription());
        }

        /// <summary>
        /// Press key 'A' and verify displayed input matches.
        /// </summary>
        [Test]
        public void PressKey_A_DisplaysCorrect()
        {
            _keyPressesPage.SendKey("A");
            Assert.IsTrue(_keyPressesPage.IsCorrectKeyDisplayed("A"));
        }

        /// <summary>
        /// Press key 'Z' and verify displayed input matches.
        /// </summary>
        [Test]
        public void PressKey_Z_DisplaysCorrect()
        {
            _keyPressesPage.SendKey("Z");
            Assert.IsTrue(_keyPressesPage.IsCorrectKeyDisplayed("Z"));
        }

        /// <summary>
        /// Press key '0' and verify displayed input matches.
        /// </summary>
        [Test]
        public void PressKey_0_DisplaysCorrect()
        {
            _keyPressesPage.SendKey("0");
            Assert.IsTrue(_keyPressesPage.IsCorrectKeyDisplayed("0"));
        }

        /// <summary>
        /// Press key '9' and verify displayed input matches.
        /// </summary>
        [Test]
        public void PressKey_9_DisplaysCorrect()
        {
            _keyPressesPage.SendKey("9");
            Assert.IsTrue(_keyPressesPage.IsCorrectKeyDisplayed("9"));
        }

        /// <summary>
        /// Press special key 'Enter' and verify displayed input matches.
        /// </summary>
        [Test]
        public void PressKey_Enter_DisplaysCorrect()
        {
            Assert.IsTrue(_keyPressesPage.IsSpecialKeyCaptured("Enter"));
        }

        /// <summary>
        /// Press special key 'Tab' and verify displayed input matches.
        /// </summary>
        [Test]
        public void PressKey_Tab_DisplaysCorrect()
        {
            Assert.IsTrue(_keyPressesPage.IsSpecialKeyCaptured("Tab"));
        }

        /// <summary>
        /// Press special key 'Backspace' and verify displayed input matches.
        /// </summary>
        [Test]
        public void PressKey_Backspace_DisplaysCorrect()
        {
            Assert.IsTrue(_keyPressesPage.IsSpecialKeyCaptured("Backspace"));
        }

        /// <summary>
        /// Press special key 'Escape' and verify displayed input matches.
        /// </summary>
        [Test]
        public void PressKey_Escape_DisplaysCorrect()
        {
            Assert.IsTrue(_keyPressesPage.IsSpecialKeyCaptured("Escape"));
        }
        /// <summary>
        /// Verifies that the "Powered by Elemental Selenium" footer is visible.
        /// </summary>
        [Test]
        public void Footer_PoweredBy_IsVisible()
        {
            Assert.IsTrue(_keyPressesPage.IsFooterPoweredByVisible());
        }

        /// <summary>
        /// Verifies that the "Fork me on GitHub" ribbon is visible and interactable.
        /// </summary>
        [Test]
        public void GitHubRibbon_IsVisible()
        {
            Assert.IsTrue(_keyPressesPage.IsGitHubRibbonVisible());
        }
    }
}
