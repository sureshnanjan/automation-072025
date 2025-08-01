// -------------------------------------------------------------------------------------------------
// © 2025 Elangovan. All rights reserved.
// 
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// This interface defines the contract for interacting with the Typos page functionality,
// including navigation, text content retrieval, typo detection, and validation utilities.
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the Typos page in the HerokuApp.
    /// Provides methods for navigation, text content retrieval, and typo detection.
    /// </summary>
    internal interface ITypos
    {
        /// <summary>
        /// Navigates to the Typos page.
        /// </summary>
        void NavigateToPage();

        /// <summary>
        /// Gets the page title after successful navigation.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        string GetPageTitle();

        /// <summary>
        /// Gets the description text displayed on the page.
        /// </summary>
        /// <returns>The page description as a string.</returns>
        string GetPageDescription();

        /// <summary>
        /// Returns a boolean indicating whether any typos were found on the page.
        /// </summary>
        /// <returns>True if typos are present; otherwise, false.</returns>
        bool HasTypos();

        /// <summary>
        /// Returns the total number of words on the page.
        /// </summary>
        /// <returns>Integer representing the word count.</returns>
        int GetWordCount();

        /// <summary>
        /// Returns a list of detected typos in the text.
        /// </summary>
        /// <returns>List of typo words.</returns>
        List<string> GetDetectedTypos();

        /// <summary>
        /// Checks if a specific word exists in the description text.
        /// </summary>
        /// <param name="word">The word to search for.</param>
        /// <returns>True if found; otherwise, false.</returns>
        bool ContainsWord(string word);

        /// <summary>
        /// Returns the total number of sentences on the page.
        /// </summary>
        /// <returns>Integer representing the number of sentences.</returns>
        int GetSentenceCount();

        /// <summary>
        /// Returns all the sentences present on the Typos page.
        /// </summary>
        /// <returns>List of sentence strings.</returns>
        List<string> GetAllSentences();

        /// <summary>
        /// Validates if the description contains any repeated words consecutively.
        /// </summary>
        /// <returns>True if repeated words are found; otherwise, false.</returns>
        bool HasConsecutiveRepeatedWords();
    }
}
