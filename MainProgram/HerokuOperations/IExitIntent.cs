/*******************************************************
* Copyright (c) 2025, Shreya S G
* All rights reserved.
* 
* File: IExitIntent.cs
* Purpose: Interface for operations related to the Exit Intent popup.
*******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Interface defining operations for handling the Exit Intent modal
    /// at https://the-internet.herokuapp.com/exit_intent.
    /// This follows SOLID principles, keeping responsibilities well-defined.
    /// </summary>
    public interface IExitIntent
    {
        /// <summary>
        /// Simulates a mouse exit (towards the top of the viewport) to trigger the modal.
        /// </summary>
        void TriggerExitIntent();

        /// <summary>
        /// Checks whether the Exit Intent modal is currently displayed.
        /// </summary>
        /// <returns>True if modal is visible, otherwise false.</returns>
        bool IsModalDisplayed();

        /// <summary>
        /// Closes the Exit Intent modal.
        /// </summary>
        void CloseModal();

        /// <summary>
        /// Gets the content text displayed inside the modal.
        /// </summary>
        /// <returns>The modal content text.</returns>
        string GetModalContent();

        /// <summary>
        /// Verifies if the modal appears only after a full page load.
        /// </summary>
        /// <returns>True if modal appears post-load, otherwise false.</returns>
        bool VerifyModalAppearsAfterPageLoad();

        /// <summary>
        /// Verifies if the modal triggers only when the mouse exits at the top edge.
        /// </summary>
        /// <param name="exitDirection">Direction of the exit (e.g., "top", "side").</param>
        /// <returns>True if modal triggers for top exit only, false otherwise.</returns>
        bool VerifyExitDirection(string exitDirection);
    }
}
