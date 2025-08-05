﻿// -------------------------------------------------------------------------------------------------
// © 2025 Elangovan. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// This class provides the implementation for the ITypos interface,
// enabling interaction with the HerokuApp Typos page.
// -------------------------------------------------------------------------------------------------

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HerokuOperations
{
    /// <summary>
    /// Simple implementation of the <see cref="ITypos"/> interface for the HerokuApp Typos page.
    /// </summary>
    public class TyposPage : ITypos
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://the-internet.herokuapp.com/typos";

        /// <summary>
        /// Initializes a new instance of the <see cref="TyposPage"/> class.
        /// </summary>
        public TyposPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Navigates to the Typos page.
        /// </summary>
        public void NavigateToPage()
        {
            _driver.Navigate().GoToUrl(_url);
            Thread.Sleep(2000); // Wait for page to load
        }

        /// <summary>
        /// Gets the title of the Typos page.
        /// </summary>
        public string GetPageTitle()
        {
            return _driver.Title;
        }

        /// <summary>
        /// Gets the main description text from the page.
        /// </summary>
        public string GetPageDescription()
        {
            return _driver.FindElement(By.CssSelector("div.example p")).Text;
        }

        /// <summary>
        /// Detects if there are any typos in the page text. (Very basic check for "won,t" etc.)
        /// </summary>
        public bool HasTypos()
        {
            string text = GetPageDescription();
            return text.Contains("won,t") || text.Contains("teh"); // simple typo examples
        }

        /// <summary>
        /// Gets the total number of words in the page text.
        /// </summary>
        public int GetWordCount()
        {
            return GetPageDescription().Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Gets a list of detected typos (simple pattern-based detection).
        /// </summary>
        public List<string> GetDetectedTypos()
        {
            var typos = new List<string>();
            string text = GetPageDescription();
            if (text.Contains("won,t")) typos.Add("won,t");
            if (text.Contains("teh")) typos.Add("teh");
            return typos;
        }

        /// <summary>
        /// Checks if a specific word exists in the page text.
        /// </summary>
        public bool ContainsWord(string word)
        {
            return GetPageDescription().Split(' ').Any(w => w.Equals(word, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets the total number of sentences in the page text.
        /// </summary>
        public int GetSentenceCount()
        {
            return GetAllSentences().Count;
        }

        /// <summary>
        /// Gets all sentences from the page text.
        /// </summary>
        public List<string> GetAllSentences()
        {
            return GetPageDescription()
                .Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .ToList();
        }

        /// <summary>
        /// Checks for consecutive repeated words in the page text.
        /// </summary>
        public bool HasConsecutiveRepeatedWords()
        {
            var words = GetPageDescription().Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (words[i].Equals(words[i + 1], StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the "Powered by Elemental Selenium" footer is visible.
        /// </summary>
        public bool IsFooterPoweredByVisible()
        {
            return _driver.FindElement(By.CssSelector("#page-footer a")).Displayed;
        }

        /// <summary>
        /// Determines whether the GitHub ribbon is visible on the page.
        /// </summary>
        public bool IsGitHubRibbonVisible()
        {
            return _driver.FindElement(By.CssSelector(".github-fork-ribbon")).Displayed;
        }
    }
}
