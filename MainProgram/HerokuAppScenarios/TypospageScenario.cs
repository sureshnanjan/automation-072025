<<<<<<< HEAD
﻿// -------------------------------------------------------------------------------------------------
// © 2025 Arpita Neogi. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// Description:
// This test class validates the Typos page functionality by covering navigation,
// text content retrieval, typo detection, word/sentence count verification,
// and other content-based assertions.
// -------------------------------------------------------------------------------------------------

=======
// --------------------------------------------------------------------------------------
// Copyright (c) 2025 Arpita Neogi
//
// Licensed under the MIT License.
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// --------------------------------------------------------------------------------------

using HerokuOperations;
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
using NUnit.Framework;
using System.Collections.Generic;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// NUnit test class for verifying Typos page behavior using ITypos interface.
    /// Ensures all contract methods are tested with positive, negative, and edge case scenarios.
    /// </summary>
    [TestFixture]
    public class TyposPageTests
    {
        private ITypos _typosPage;

<<<<<<< HEAD
        [SetUp]
        public void Setup()
        {
            // Normally, you'd initialize a concrete implementation of ITyposPage here.
            // Example:
            // _typosPage = new TyposPageImplementation();
        }
=======
        /// <summary>
        /// Setup method that executes before each test case.
        /// This is where the TyposPage implementation instance would normally be initialized.
        /// Example:
        /// <code>_typosPage = new TyposPageImplementation();</code>
        /// </summary>
        
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3

        /// <summary>
        /// Validates successful navigation to the Typos page.
        /// </summary>
        [Test]
<<<<<<< HEAD
        public void NavigateToPage_ShouldLoadSuccessfully()
=======
        public void NavigateToPageShouldReturnExpectedTitle()
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
        {
            Assert.DoesNotThrow(() => _typosPage.NavigateToPage(),
                "Navigation to Typos page should not throw any exception.");
        }

        /// <summary>
        /// Validates the page title is correctly displayed.
        /// </summary>
        
        [Test]
<<<<<<< HEAD
        public void GetPageTitle_ShouldReturnTyposTitle()
=======
        public void NavigateToPageShouldReturnExpectedDescription()
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
        {
            _typosPage.NavigateToPage();
            string title = _typosPage.GetPageTitle();

            Assert.That(title, Is.EqualTo("Typos"), "Page title does not match expected value.");
        }

        /// <summary>
        /// Verifies the page description is not empty and is correctly retrieved.
        /// </summary>
        
        [Test]
<<<<<<< HEAD
        public void GetPageDescription_ShouldReturnNonEmptyText()
=======
        public void PageShouldNotContainAnyTypos()
>>>>>>> 44b458e5e4ad580bac994356ba61e2e30c7a19c3
        {
            _typosPage.NavigateToPage();
            string description = _typosPage.GetPageDescription();

            Assert.That(description, Is.Not.Null.And.Not.Empty, "Description text should not be empty.");
        }

        /// <summary>
        /// Ensures no known typos are present on the page.
        /// </summary>
        [Test]
        public void HasTypos_ShouldReturnFalseIfNoTyposDetected()
        {
            _typosPage.NavigateToPage();
            bool result = _typosPage.HasTypos();

            Assert.IsFalse(result, "Page should not contain typos in ideal conditions.");
        }

        /// <summary>
        /// Verifies that the word count on the page is greater than zero.
        /// </summary>
        [Test]
        public void GetWordCount_ShouldReturnPositiveValue()
        {
            _typosPage.NavigateToPage();
            int wordCount = _typosPage.GetWordCount();

            Assert.That(wordCount, Is.GreaterThan(0), "Word count should be greater than zero.");
        }

        /// <summary>
        /// Ensures detected typos are returned as a list if they exist.
        /// </summary>
        [Test]
        public void GetDetectedTypos_ShouldReturnListIfTyposExist()
        {
            _typosPage.NavigateToPage();
            List<string> typos = _typosPage.GetDetectedTypos();

            Assert.That(typos, Is.Not.Null, "Detected typos list should not be null.");
            Assert.That(typos, Is.InstanceOf<List<string>>(), "Returned object should be a list.");
        }

        /// <summary>
        /// Verifies that a specific known word is found on the page.
        /// </summary>
        [Test]
        public void ContainsWord_ShouldReturnTrueForExistingWord()
        {
            _typosPage.NavigateToPage();
            bool exists = _typosPage.ContainsWord("example");

            Assert.IsTrue(exists, "Expected word 'example' was not found in the page text.");
        }

        /// <summary>
        /// Validates that the page contains at least one sentence.
        /// </summary>
        [Test]
        public void GetSentenceCount_ShouldReturnPositiveNumber()
        {
            _typosPage.NavigateToPage();
            int count = _typosPage.GetSentenceCount();

            Assert.That(count, Is.GreaterThan(0), "Sentence count should be greater than zero.");
        }

        /// <summary>
        /// Ensures all sentences are returned as a list.
        /// </summary>
        [Test]
        public void GetAllSentences_ShouldReturnListOfSentences()
        {
            _typosPage.NavigateToPage();
            List<string> sentences = _typosPage.GetAllSentences();

            Assert.That(sentences, Is.Not.Null.And.Not.Empty, "Sentences list should not be null or empty.");
            Assert.That(sentences, Is.InstanceOf<List<string>>(), "Returned object should be a list of sentences.");
        }

        /// <summary>
        /// Validates that there are no consecutive repeated words on the page.
        /// </summary>
        [Test]
        public void HasConsecutiveRepeatedWords_ShouldReturnFalseForValidText()
        {
            _typosPage.NavigateToPage();
            bool hasRepeatedWords = _typosPage.HasConsecutiveRepeatedWords();

            Assert.IsFalse(hasRepeatedWords, "Page text contains consecutive repeated words, which is unexpected.");
        }
    }
}
