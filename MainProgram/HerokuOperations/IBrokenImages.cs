// -------------------------------------------------------------------------------------------------
// © 2025 Your Company or Name. All rights reserved.
// This file is part of the HerokuApp automation framework interfaces.
// It defines the contract for interacting with the Broken Images test page.
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
        /// Gets the total number of images on the page.
        /// </summary>
        /// <returns>The total number of image elements found.</returns>
        int GetImageCount();

        /// <summary>
        /// Returns the number of broken images (images that failed to load).
        /// </summary>
        /// <returns>The count of broken image elements.</returns>
        int GetBrokenImageCount();

        /// <summary>
        /// Returns a list of all image source URLs that failed to load.
        /// </summary>
        /// <returns>List of URLs pointing to broken image sources.</returns>
        List<string> GetBrokenImageUrls();
    }
}
