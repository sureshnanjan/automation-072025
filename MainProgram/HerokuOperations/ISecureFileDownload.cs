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
    /// Interface defining operations for handling secure file downloads.
    /// Adheres to the Single Responsibility Principle (SRP) by focusing only on secure file retrieval and access control.
    /// </summary>
    public interface ISecureFileDownload
    {
        /// <summary>
        /// Checks if the current user is authenticated for secure download access.
        /// </summary>
        /// <returns>True if the user is authenticated; otherwise, false.</returns>
        bool IsUserAuthenticated();

        /// <summary>
        /// Gets the list of available files for download.
        /// </summary>
        /// <returns>A collection of file names accessible to the authenticated user.</returns>
        IEnumerable<string> GetAvailableFiles();

        /// <summary>
        /// Downloads the specified file securely.
        /// </summary>
        /// <param name="fileName">Name of the file to download.</param>
        /// <returns>Byte array representing the file contents.</returns>
        byte[] DownloadFile(string fileName);

        /// <summary>
        /// Logs out the current user and clears secure session.
        /// </summary>
        void Logout();

        /// <summary>
        /// Attempts to re-authenticate the user using credentials (for session expiration cases).
        /// </summary>
        /// <param name="username">Username for login.</param>
        /// <param name="password">Password for login.</param>
        /// <returns>True if re-authentication is successful; otherwise, false.</returns>
        bool ReAuthenticate(string username, string password);
    }
}
