/*
 * -----------------------------------------------------------------------------
 * Project     : HerokuAppTests
 * File        : IShiftingContentPage.cs
 * Description : Interface defining methods to interact with the Shifting Content page.
 * Author      : Keyur Nagvekar
 * Created     : 2025-08-01
 * License     : MIT License
 * -----------------------------------------------------------------------------
 */

namespace HerokuOperations
{
    /// <summary>
    /// Defines contract for interacting with the Shifting Content page at /shifting_content.
    /// Provides access to title, subtitle, and dynamic navigation link information.
    /// </summary>
    public interface IShiftingContentPage
    {
        /// <summary>
        /// Gets the main title of the shifting content page (e.g., "Shifting Content").
        /// </summary>
        /// <returns>Page title as a string.</returns>
        string GetTitle();

        /// <summary>
        /// Gets the subtitle or description displayed under the title.
        /// </summary>
        /// <returns>Subtitle text as a string.</returns>
        string GetDescription();

        /// <summary>
        /// Gets the total number of navigation links present on the page.
        /// </summary>
        /// <returns>Integer representing the link count.</returns>
        int GetLinkCount();

        /// <summary>
        /// Retrieves the visible texts of all navigation links on the page.
        /// </summary>
        /// <returns>Array of link text strings.</returns>
        string[] GetAllLinkTexts();
    }
}
