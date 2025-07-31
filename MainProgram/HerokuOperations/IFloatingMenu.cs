/*
* ------------------------------------------------------------------------------
* © 2025 SOWMYA SRIDHAR. All rights reserved.
* 
* This file is part of the HerokuOperations project.
* It defines the interface for interacting with the Floating Menu page.
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
    /// Defines operations for interacting with the Floating Menu page.
    /// </summary>
    internal interface IFloatingMenu
    {
        /// <summary>
        /// Checks if the floating menu is visible on the screen.
        /// </summary>
        /// <returns>True if the menu is visible; otherwise, false.</returns>
        bool IsMenuVisible();

        /// <summary>
        /// Clicks on the "Home" link in the floating menu.
        /// </summary>
        void ClickHome();

        /// <summary>
        /// Clicks on the "News" link in the floating menu.
        /// </summary>
        void ClickNews();

        /// <summary>
        /// Clicks on the "Contact" link in the floating menu.
        /// </summary>
        void ClickContact();

        /// <summary>
        /// Clicks on the "About" link in the floating menu.
        /// </summary>
        void ClickAbout();

        /// <summary>
        /// Scrolls the page to the bottom (to test if the menu still floats).
        /// </summary>
        void ScrollToBottom();

        /// <summary>
        /// Gets the current Y position of the floating menu (to verify if it's fixed).
        /// </summary>
        /// <returns>The vertical (Y-axis) pixel position of the menu.</returns>
        int GetMenuYPosition();
    }
}
