<<<<<<< HEAD
﻿// -----------------------------------------------------------------------------
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

=======
>>>>>>> 39d9ac82c94ebdaa9a086c8441be75d73dc53ddb
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
<<<<<<< HEAD
            _hoversPage = new HoversPage();
            _hoversPage.GotoPage();
=======
            // Start Chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Open the Hovers page
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");

            // Create an object for hover operations
            hover = new HoverImplementation(driver);
>>>>>>> 39d9ac82c94ebdaa9a086c8441be75d73dc53ddb
        }

        /// <summary>
        /// Verifies that the title of the Hovers page is correct.
        /// </summary>
        [Test]
<<<<<<< HEAD
        public void Title_Check()
        {
            Assert.AreEqual("Hovers", _hoversPage.GetTitle());
=======
        public void Title_ShouldBe_Hovers()
        {
            // Get the title from the page
            string title = hover.GetTitle();

            // Check if the title is "Hovers"
            Assert.That(title, Is.EqualTo("Hovers"));
>>>>>>> 39d9ac82c94ebdaa9a086c8441be75d73dc53ddb
        }

        /// <summary>
        /// Hover over user1's avatar and verify the displayed name is correct.
        /// </summary>
        [Test]
<<<<<<< HEAD
        public void Hover_User1_Name()
        {
            _hoversPage.HoverOverAvatar(0);
            Assert.AreEqual("name: user1", _hoversPage.GetUsername(0));
=======
        public void Description_ShouldNotBeEmpty()
        {
            // Get the description text
            string description = hover.Description();

            // Check if it's not null or empty
            Assert.That(description, Is.Not.Null.And.Not.Empty);
>>>>>>> 39d9ac82c94ebdaa9a086c8441be75d73dc53ddb
        }

        /// <summary>
        /// Hover over user2's avatar and verify the displayed name is correct.
        /// </summary>
        [Test]
<<<<<<< HEAD
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
=======
        public void ShouldHave_ThreeProfileImages()
        {
            // Get the number of profile images
            int count = hover.GetProfileCount();

            // Check if there are 3 images
            Assert.That(count, Is.EqualTo(3));
        }

        [Test]
        public void Hover_ShouldShowCaptions()
        {
            int count = hover.GetProfileCount();

            for (int i = 0; i < count; i++)
            {
                // Hover over each profile image
                hover.HoverOverProfileImage(i);

                // Check if caption is visible
                Assert.That(hover.IsProfileInfoDisplayed(i), Is.True);
            }
>>>>>>> 39d9ac82c94ebdaa9a086c8441be75d73dc53ddb
        }

        /// <summary>
        /// Hover over user1 and verify profile link is visible.
        /// </summary>
        [Test]
<<<<<<< HEAD
        public void ProfileLink_User1_Visible()
        {
            _hoversPage.HoverOverAvatar(0);
            Assert.IsTrue(_hoversPage.IsProfileLinkVisible(0));
=======
        public void Hover_ShouldShowCorrectUserNames()
        {
            int count = hover.GetProfileCount();

            for (int i = 0; i < count; i++)
            {
                // Get profile name after hover
                string name = hover.GetProfileName(i);

                // Check if name starts with "name: user"
                Assert.That(name, Does.StartWith("name: user"));
            }
>>>>>>> 39d9ac82c94ebdaa9a086c8441be75d73dc53ddb
        }

        /// <summary>
        /// Hover over user2 and verify profile link is visible.
        /// </summary>
        [Test]
<<<<<<< HEAD
        public void ProfileLink_User2_Visible()
        {
            _hoversPage.HoverOverAvatar(1);
            Assert.IsTrue(_hoversPage.IsProfileLinkVisible(1));
=======
        public void Hover_ShouldShowValidProfileLinks()
        {
            int count = hover.GetProfileCount();

            for (int i = 0; i < count; i++)
            {
                // Get profile link after hover
                string link = hover.GetProfileLink(i);

                // Check if link contains "/users/"
                Assert.That(link, Does.Contain("/users/"));
            }
>>>>>>> 39d9ac82c94ebdaa9a086c8441be75d73dc53ddb
        }

        /// <summary>
        /// Hover over user3 and verify profile link is visible.
        /// </summary>
        [Test]
        public void ProfileLink_User3_Visible()
        {
<<<<<<< HEAD
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
=======
            // Close the browser and cleanup
            driver.Quit();
            driver.Dispose();
>>>>>>> 39d9ac82c94ebdaa9a086c8441be75d73dc53ddb
        }
    }
}
