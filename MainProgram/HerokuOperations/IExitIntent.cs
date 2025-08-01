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
    /// Interface defining operations for handling Exit Intent popups.
    /// </summary>
    public interface IExitIntent
    {
        /// <summary>
        /// Triggers the Exit Intent popup (simulates cursor leaving the viewport).
        /// </summary>
        void TriggerExitIntent();

        /// <summary>
        /// Gets the title of the Exit Intent popup.
        /// </summary>
        /// <returns>Title text of the Exit Intent popup..</returns>
        string GetPopupTitle();

        /// <summary>
        /// Gets the message/content of the Exit Intent popup.
        /// </summary>
        /// <returns>Content text of the Exit Intent popup.</returns>
        string GetPopupContent();

        /// <summary>
        /// Closes the Exit Intent popup.
        /// </summary>
        void ClosePopup();
    }
}
