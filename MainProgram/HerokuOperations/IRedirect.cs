// Author: Siva Sree
// Date Created: 2025-07-30
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# file defines the IRedirect interface for automating interaction 
// with the redirection page at https://the-internet.herokuapp.com/redirector.
// The interface includes methods to get the page title, click the redirection 
// link, and retrieve the informational paragraph text. It is designed for use 
// in UI test automation scenarios using tools like Selenium.

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the Heroku redirection page.
    /// </summary>
    public interface IRedirect
    {
        /// <summary>
        /// Retrieves the title text from the redirection page (e.g., from the <h3> tag).
        /// </summary>
        /// <returns>The title string.</returns>
        string GetTitle();

        /// <summary>
        /// Clicks the "here" link on the redirection page to initiate navigation.
        /// </summary>
        void ClickhereLink();

        /// <summary>
        /// Retrieves the paragraph text displayed below the title.
        /// </summary>
        /// <returns>The descriptive paragraph string.</returns>
        string GetParagraphText();
    }
}
