/*
* IABTest Interface
* 
* This interface defines the operations for verifying and controlling A/B Test content 
* on the HerokuApp site (https://the-internet.herokuapp.com/abtest).
* 
* Author: Teja Reddy
* Created: August 2025
* License: For educational or internal use only.
* 
* © 2025 Teja Reddy. All rights reserved.
*/

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the A/B Testing page on HerokuApp.
    /// </summary>
    public interface IABTest
    {
        /// <summary>
        /// Gets the main title of the A/B Test page.
        /// </summary>
        /// <returns>The title string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the description or body content shown under the title.
        /// </summary>
        /// <returns>The description string.</returns>
        string GetDescription();

        /// <summary>
        /// Disables the A/B test by navigating with a query parameter or custom logic.
        /// </summary>
        void DisableABTest();
    }
}
