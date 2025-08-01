// -------------------------------------------------------------------------------------------------
// © 2025 Elangovan. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// This interface defines the contract for interacting with the Broken Images page functionality,
// including navigation, image validation, broken image detection, and additional verification 
// features for UI testing scenarios.
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the Broken Images page in the HerokuApp.
    /// Provides methods for navigation, image count, and identifying broken images.
    /// </summary>
    internal interface IBrokenImages
    {
        /// <summary>
        /// Navigates to the broken images test page.
        /// </summary>
        void NavigateToPage();

        /// <summary>
        /// Gets the page title after successful navigation.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        string GetPageTitle();

        /// <summary>
        /// Gets the total number of <img> elements on the page.
        /// </summary>
        /// <returns>The total number of image elements found.</returns>
        int GetImageCount();

        /// <summary>
        /// Gets the number of broken images (those that failed to load).
        /// </summary>
        /// <returns>The count of broken image elements.</returns>
        int GetBrokenImageCount();

        /// <summary>
        /// Gets a list of all broken image URLs (image sources that failed to load).
        /// </summary>
        /// <returns>List of broken image source URLs.</returns>
        List<string> GetBrokenImageUrls();

        /// <summary>
        /// Gets the number of images that loaded successfully.
        /// </summary>
        /// <returns>The count of valid images that rendered correctly.</returns>
        int GetValidImageCount();

        /// <summary>
        /// Checks if all images on the page are valid.
        /// </summary>
        /// <returns>True if no broken images are found; otherwise, false.</returns>
        bool AreAllImagesValid();

        /// <summary>
        /// Waits for all images to be fully loaded on the page.
        /// </summary>
        void WaitForImagesToLoad();

        /// <summary>
        /// Refreshes the Broken Images page.
        /// </summary>
        void RefreshPage();

        /// <summary>
        /// Gets alt attributes of all broken images for accessibility testing.
        /// </summary>
        /// <returns>List of alt text from broken images.</returns>
        List<string> GetAltTextOfBrokenImages();

        /// <summary>
        /// Verifies if the "Powered by Elemental Selenium" footer is present and visible.
        /// </summary>
        /// <returns>True if the footer is visible; otherwise, false.</returns>
        bool IsFooterPoweredByVisible();

        /// <summary>
        /// Checks if the "Fork me on GitHub" ribbon is visible and clickable.
        /// </summary>
        /// <returns>True if the ribbon is present and interactable; otherwise, false.</returns>
        bool IsGitHubRibbonVisible();
    }
}
