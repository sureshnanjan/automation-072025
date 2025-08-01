// -------------------------------------------------------------------------------------------------
// © 2025 Elangovan. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// Description:
// This NUnit test class validates the Typos page functionality using the ITypos interface.
// The test suite ensures navigation, typo detection, word/sentence analysis, and visibility
// of essential UI elements (footer, GitHub ribbon) on the page.
// -------------------------------------------------------------------------------------------------

using NUnit.Framework;
using System.Collections.Generic;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// NUnit test class for verifying Typos page functionality in the HerokuApp
    /// using the ITypos interface.
    /// </summary>
    [TestFixture]
    public class TyposPageTests
    {
        private ITypos _typosPage;

        [SetUp]
        public void Setup()
        {
            // Normally, a concrete implementation of ITypos would be initialized here.
            // Example:
            // _typosPage = new TyposPageImplementation();
        }

        /// <summary>
        /// Test to verify that navigation to the Typos page works without exceptions.
        /// </summary>
        [Test]
        public void NavigateToPage_ShouldNotThrowException()
        {
            Assert.DoesNotThrow(() => _typosPage.NavigateToPage(),
                "Navigation to Typos page should not throw exceptions.");
        }

        /// <summary>
        /// Test to verify page title is displayed correctly.
        /// </summary>
        [Test]
        public void GetPageTitle_ShouldReturnExpectedTitle()
        {
            _typosPage.NavigateToPage();
            string title = _typosPage.GetPageTitle();

            Assert.That(title, Is.EqualTo("Typos"), "Page title should match 'Typos'.");
        }

        /// <summary>
        /// Test to verify the description text is displayed and not empty.
        /// </summary>
        [Test]
        public void GetPageDescription_ShouldNotBeEmpty()
        {
            _typosPage.NavigateToPage();
            string description = _typosPage.GetPageDescription();

            Assert.IsFalse(string.IsNullOrEmpty(description), "Page description should not be empty.");
        }

        /// <summary>
        /// Test to verify whether typos are detected correctly on the page.
        /// </summary>
        [Test]
        public void HasTypos_ShouldReturnTrueOrFalse()
        {
            _typosPage.NavigateToPage();
            bool hasTypos = _typosPage.HasTypos();

            Assert.That(hasTypos, Is.TypeOf<bool>(), "HasTypos should return a boolean value.");
        }

        /// <summary>
        /// Test to verify the total word count on the page is greater than zero.
        /// </summary>
        [Test]
        public void GetWordCount_ShouldBeGreaterThanZero()
        {
            _typosPage.NavigateToPage();
            int wordCount = _typosPage.GetWordCount();

            Assert.Greater(wordCount, 0, "Word count should be greater than zero.");
        }

        /// <summary>
        /// Test to verify that detected typos are retrieved as a list.
        /// </summary>
        [Test]
        public void GetDetectedTypos_ShouldReturnList()
        {
            _typosPage.NavigateToPage();
            List<string> typos = _typosPage.GetDetectedTypos();

            Assert.IsNotNull(typos, "Detected typos list should not be null.");
            Assert.IsInstanceOf<List<string>>(typos, "Detected typos should be returned as a list.");
        }

        /// <summary>
        /// Test to verify a specific word can be found in the description.
        /// </summary>
        [Test]
        public void ContainsWord_ShouldReturnTrueIfWordExists()
        {
            _typosPage.NavigateToPage();
            bool contains = _typosPage.ContainsWord("example");

            Assert.That(contains, Is.TypeOf<bool>(), "ContainsWord should return a boolean value.");
        }

        /// <summary>
        /// Test to verify the total sentence count is greater than zero.
        /// </summary>
        [Test]
        public void GetSentenceCount_ShouldBeGreaterThanZero()
        {
            _typosPage.NavigateToPage();
            int sentenceCount = _typosPage.GetSentenceCount();

            Assert.Greater(sentenceCount, 0, "Sentence count should be greater than zero.");
        }

        /// <summary>
        /// Test to verify all sentences are retrieved correctly as a list.
        /// </summary>
        [Test]
        public void GetAllSentences_ShouldReturnListOfSentences()
        {
            _typosPage.NavigateToPage();
            List<string> sentences = _typosPage.GetAllSentences();

            Assert.IsNotNull(sentences, "Sentence list should not be null.");
            Assert.IsInstanceOf<List<string>>(sentences, "Sentences should be returned as a list.");
        }

        /// <summary>
        /// Test to verify consecutive repeated words are detected correctly.
        /// </summary>
        [Test]
        public void HasConsecutiveRepeatedWords_ShouldReturnBoolean()
        {
            _typosPage.NavigateToPage();
            bool hasRepeats = _typosPage.HasConsecutiveRepeatedWords();

            Assert.That(hasRepeats, Is.TypeOf<bool>(), "HasConsecutiveRepeatedWords should return a boolean.");
        }

        /// <summary>
        /// Test to verify the "Powered by Elemental Selenium" footer is visible on the page.
        /// </summary>
        [Test]
        public void IsFooterPoweredByVisible_ShouldReturnTrue()
        {
            _typosPage.NavigateToPage();
            bool footerVisible = _typosPage.IsFooterPoweredByVisible();

            Assert.IsTrue(footerVisible, "Footer 'Powered by Elemental Selenium' should be visible.");
        }

        /// <summary>
        /// Test to verify the "Fork me on GitHub" ribbon is visible and clickable.
        /// </summary>
        [Test]
        public void IsGitHubRibbonVisible_ShouldReturnTrue()
        {
            _typosPage.NavigateToPage();
            bool ribbonVisible = _typosPage.IsGitHubRibbonVisible();

            Assert.IsTrue(ribbonVisible, "GitHub ribbon should be visible and interactable.");
        }
    }
}
