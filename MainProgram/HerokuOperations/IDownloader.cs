// Author: Siva Sree
// Date Created: 2025-07-30
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# file defines the IDownloader interface, which provides methods 
// to interact with the file download functionality on the HerokuApp page
// (https://the-internet.herokuapp.com/download). The interface includes 
// methods for retrieving all available file names, initiating a download, 
// and verifying if a file download has started. This is useful for automated 
// UI testing of file downloads using tools like Selenium.

using System;
using System.Collections.Generic;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for handling file downloads from the Heroku download page.
    /// </summary>
    internal interface IDownloader
    {
        /// <summary>
        /// Gets the list of all downloadable file names shown on the page.
        /// </summary>
        /// <returns>A list of file names available for download.</returns>
        List<string> GetAllFileNames();

        /// <summary>
        /// Clicks on the specified file to initiate its download.
        /// </summary>
        /// <param name="fileName">The name of the file to be downloaded.</param>
        void DownloadFile(string fileName);

        /// <summary>
        /// Checks whether the specified file has started downloading.
        /// </summary>
        /// <param name="fileName">The name of the file to check for download.</param>
        /// <returns>True if the download has started; otherwise, false.</returns>
        bool IsDownloadStarted(string fileName);
    }
}
