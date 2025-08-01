// -----------------------------------------------------------------------------
// <copyright>
//     Copyright (c) 2025 Teja Reddy. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------------
//
// This file contains NUnit test cases for validating the Hovers page functionality.
// It covers:
// - Title verification
// - Hovering over 3 user avatars
// - Displaying usernames after hover
// - Profile link visibility per user
// - Clicking profile links without error
// - Footer validations including:
//     • "Powered by Elemental Selenium" visibility
//     • "Fork me on GitHub" ribbon visibility
// -----------------------------------------------------------------------------

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Contains NUnit test cases for validating the Hovers page functionality.
    /// </summary>
    [TestFixture]
    public class HoversTests
    {
        private IHovers _hoversPage;

        [SetUp]
        public void Setup()
        {
            _hoversPage = new HoversPage();
            _hoversPage.GotoPage();
        }

        /// <summary>
        /// Verifies that the title of the Hovers page is correct.
        /// </summary>
        [Test]
        public void Title_Check()
        {
            Assert.AreEqual("Hovers", _hoversPage.GetTitle());
        }

        /// <summary>
        /// Hover over user1's avatar and verify the displayed name is correct.
        /// </summary>
        [Test]
        public void Hover_User1_Name()
        {
            _hoversPage.HoverOverAvatar(0);
            Assert.AreEqual("name: user1", _hoversPage.GetUsername(0));
        }

        /// <summary>
        /// Hover over user2's avatar and verify the displayed name is correct.
        /// </summary>
        [Test]
        public void Hover_User2_Name()
        {
            _hoversPage.HoverOverAvatar(1);
            Assert.AreEqual("name: user2", _hoversPage.GetUsername(1));
        }

        /// <summary>
        /// Hover over user3's avatar and verify the displayed name is correct.
        /// </summary>
        [Test]
        public void Hover_User3_Name()
        {
            _hoversPage.HoverOverAvatar(2);
            Assert.AreEqual("name: user3", _hoversPage.GetUsername(2));
        }

        /// <summary>
        /// Hover over user1 and verify profile link is visible.
        /// </summary>
        [Test]
        public void ProfileLink_User1_Visible()
        {
            _hoversPage.HoverOverAvatar(0);
            Assert.IsTrue(_hoversPage.IsProfileLinkVisible(0));
        }

        /// <summary>
        /// Hover over user2 and verify profile link is visible.
        /// </summary>
        [Test]
        public void ProfileLink_User2_Visible()
        {
            _hoversPage.HoverOverAvatar(1);
            Assert.IsTrue(_hoversPage.IsProfileLinkVisible(1));
        }

        /// <summary>
        /// Hover over user3 and verify profile link is visible.
        /// </summary>
        [Test]
        public void ProfileLink_User3_Visible()
        {
            _hoversPage.HoverOverAvatar(2);
            Assert.IsTrue(_hoversPage.IsProfileLinkVisible(2));
        }

        /// <summary>
        /// Clicks profile link for user1 and verifies no exception is thrown.
        /// </summary>
        [Test]
        public void Click_User1_ProfileLink()
        {
            _hoversPage.HoverOverAvatar(0);
            Assert.DoesNotThrow(() => _hoversPage.ClickProfileLink(0));
        }

        /// <summary>
        /// Clicks profile link for user2 and verifies no exception is thrown.
        /// </summary>
        [Test]
        public void Click_User2_ProfileLink()
        {
            _hoversPage.HoverOverAvatar(1);
            Assert.DoesNotThrow(() => _hoversPage.ClickProfileLink(1));
        }

        /// <summary>
        /// Clicks profile link for user3 and verifies no exception is thrown.
        /// </summary>
        [Test]
        public void Click_User3_ProfileLink()
        {
            _hoversPage.HoverOverAvatar(2);
            Assert.DoesNotThrow(() => _hoversPage.ClickProfileLink(2));
        }

        /// <summary>
        /// Verifies that the "Powered by Elemental Selenium" footer is visible.
        /// </summary>
        [Test]
        public void Footer_PoweredBy_IsVisible()
        {
            Assert.IsTrue(_hoversPage.IsFooterPoweredByVisible());
        }

        /// <summary>
        /// Verifies that the "Fork me on GitHub" ribbon is visible and interactable.
        /// </summary>
        [Test]
        public void GitHubRibbon_IsVisible()
        {
            Assert.IsTrue(_hoversPage.IsGitHubRibbonVisible());
        }
    }
}
