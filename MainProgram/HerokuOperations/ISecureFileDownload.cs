/*******************************************************
* Copyright (c) 2025, Shreya S G
* All rights reserved.
* 
* File: ISecureFileDownload.cs
* Purpose: Interface for operations related to Secure File Downloads.
*******************************************************/
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Interface defining operations for handling Secure File Downloads.
    /// </summary>
    public interface ISecureFileDownload
    {
        /// <summary>
        /// Authenticates the user for accessing the secure file download page.
        /// </summary>
        /// <param name="username">Username for basic auth.</param>
        /// <param name="password">Password for basic auth.</param>
        /// <returns>True if authentication is successful, otherwise false.</returns>
        bool Authenticate(string username, string password);

        /// <summary>
        /// Gets the list of available downloadable files.
        /// </summary>
        /// <returns>List of file names.</returns>
        List<string> GetAvailableFiles();

        /// <summary>
        /// Downloads a specified file from the secure directory.
        /// </summary>
        /// <param name="fileName">Name of the file to download.</param>
        /// <returns>Path where the file is downloaded.</returns>
        string DownloadFile(string fileName);
    }
}
