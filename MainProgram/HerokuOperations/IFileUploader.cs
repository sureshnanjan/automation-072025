// Author: Siva Sree
// Date Created: 2025-07-30
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# file defines the IFileUploader interface, which provides method 
// declarations for interacting with the file upload functionality on the 
// HerokuApp page (https://the-internet.herokuapp.com/upload). The interface 
// includes methods to select a file, perform the upload, verify success, 
// and retrieve the name of the uploaded file. It is designed for use in 
// UI automation scenarios with tools such as Selenium.

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface for handling file upload functionality on the Heroku upload page.
    /// </summary>
    internal interface IFileUploader
    {
        /// <summary>
        /// Selects a file to upload by setting the file input path.
        /// </summary>
        /// <param name="filePath">The full path of the file to be uploaded.</param>
        void ChooseFile(string filePath);

        /// <summary>
        /// Clicks the "Upload" button to submit the selected file.
        /// </summary>
        void ClickUploadButton();

        /// <summary>
        /// Checks whether the file upload was successful.
        /// </summary>
        /// <returns>True if the upload succeeded; otherwise, false.</returns>
        bool IsUploadSuccessful();

        /// <summary>
        /// Retrieves the name of the uploaded file as shown on the confirmation page.
        /// </summary>
        /// <returns>The name of the uploaded file.</returns>
        string GetUploadedFileName();
    }
}
