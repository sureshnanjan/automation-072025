/*******************************************************
* Copyright (c) 2025, Shreya S G
* All rights reserved.
* 
* File: IEntryAd.cs
* Purpose: Interface for operations related to the Entry Ad feature.
*******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Interface defining operations for handling the Entry Ad modal
    /// at https://the-internet.herokuapp.com/entry_ad.
    /// Follows SOLID principles for clean separation of responsibilities.
    /// </summary>
    public interface IEntryAd
    {
        /// <summary>
        /// Checks if the Entry Ad modal is currently visible.
        /// </summary>
        /// <returns>True if the modal is displayed, false otherwise.</returns>
        bool IsModalVisible();

        /// <summary>
        /// Closes the Entry Ad modal if it is open.
        /// </summary>
        void CloseModal();

        /// <summary>
        /// Clicks the "click here" link to re-enable and show the modal.
        /// </summary>
        void ReEnableModal();

        /// <summary>
        /// Gets the title text of the Entry Ad modal.
        /// </summary>
        /// <returns>The modal title string.</returns>
        string GetModalTitle();

        /// <summary>
        /// Gets the body content text of the Entry Ad modal.
        /// </summary>
        /// <returns>The modal body string.</returns>
        string GetModalContent();

        /// <summary>
        /// Determines whether the ad should appear based on session/state 
        /// (e.g., after closing vs. new session).
        /// </summary>
        /// <returns>True if the ad should appear, false otherwise.</returns>
        bool ShouldModalAppearOnLoad();
    }
}   }
}
