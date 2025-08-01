/*
* Copyright © 2025 Sehwag Vijay
* All rights reserved.
*/

using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Unit tests for the EntryAdOperations class.
    /// Validates behavior of Entry Ad popup title, content, visibility, and relaunch functionality.
    /// </summary>
    [TestFixture]
    public class EntryAdOperationsTests
    {
        private IEntryAd entryAd;

        /// <summary>
        /// Sets up a fresh instance before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            entryAd = new EntryAdOperations();
        }

        /// <summary>
        /// Tests that the title is returned when the ad is visible.
        /// </summary>
        [Test]
        public void GetAdTitle_ShouldReturnTitle_WhenAdIsVisible()
        {
            string title = entryAd.GetAdTitle();
            Assert.AreEqual("Entry Ad", title);
        }

        /// <summary>
        /// Tests that the content is returned when the ad is visible.
        /// </summary>
        [Test]
        public void GetAdContent_ShouldReturnContent_WhenAdIsVisible()
        {
            //this is an example only
            string content = entryAd.GetAdContent();
            Assert.AreEqual("Buy our product and enjoy amazing benefits!", content);
        }

        /// <summary>
        /// Tests that closing the ad makes title and content empty.
        /// </summary>
        [Test]
        public void CloseAd_ShouldMakeAdInvisible()
        {
            entryAd.CloseAd();
            Assert.AreEqual(string.Empty, entryAd.GetAdTitle());
            Assert.AreEqual(string.Empty, entryAd.GetAdContent());
        }

        /// <summary>
        /// Tests that relaunching the ad restores its visibility.
        /// </summary>
        [Test]
        public void RelaunchAd_ShouldMakeAdVisibleAfterClosing()
        {
            entryAd.CloseAd();
            entryAd.RelaunchAd();
            Assert.AreEqual("Entry Ad", entryAd.GetAdTitle());
            Assert.AreEqual("Buy our product and enjoy amazing benefits!", entryAd.GetAdContent());
        }
    }
}

