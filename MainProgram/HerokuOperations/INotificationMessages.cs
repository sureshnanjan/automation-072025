using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    internal interface INotificationMessages
    {
    }/*
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
            /// Clicks the link that triggers a new notification message.
            /// </summary>
            void ClickTriggerLink();

            /// <summary>
            /// Retrieves the current notification message text displayed on the page.
            /// </summary>
            /// <returns>The visible notification message text (if any).</returns>
            string GetNotificationMessage();

            /// <summary>
            /// Retrieves the heading text from the Notification Message page.
            /// </summary>
            /// <returns>The heading text, e.g., "Notification Message".</returns>
            string GetPageHeading();
        }
    }
}
