/*
* ------------------------------------------------------------------------------
* © 2025 SOWMYA SRIDHAR. All rights reserved.
* 
* This file is part of the HerokuOperations project.
* It defines the interface for interacting with the Notifications Messages page.
* Redistribution is allowed for educational or internal use only.
* ------------------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Defines the operations available on the Notification Message page.
    /// </summary>
    public interface INotificationMessages
    {
        /// <summary>
        /// Gets the alert/notification message shown at the top (e.g., "Action unsuccessful, please try again").
        /// </summary>
        /// <returns>The notification message text.</returns>
        string GetNotificationMessage();

        /// <summary>
        /// Gets the static heading of the page (e.g., "Notification Message").
        /// </summary>
        /// <returns>The heading text.</returns>
        string GetHeading();

        /// <summary>
        /// Clicks the "Click here" link to load a new message.
        /// </summary>
        void ClickLoadNewMessageLink();

        /// <summary>
        /// Gets the URL the "Click here" link points to.
        /// </summary>
        /// <returns>The hyperlink's URL as a string.</returns>
        string GetLinkHref();
    }
}
