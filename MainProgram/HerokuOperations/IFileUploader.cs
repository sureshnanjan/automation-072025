// Author: Siva Sree  
// Date Created: 2025-08-01  
// Copyright (c) 2025 Siva Sree  
// All Rights Reserved.  
//
// Description:  
// This C# file defines the IFileUploader interface for automating interactions  
// with the File Upload page at https://the-internet.herokuapp.com/upload.  
// The interface supports retrieving the page title and content, selecting a file,  
// uploading it, and verifying upload success. It is structured to support functional  
// UI test automation using techniques like Equivalence Partitioning and Boundary Value Analysis.

namespace HerokuOperations
{
    /// <summary>
    /// Interface for interacting with the File Upload page on HerokuApp.
    /// </summary>
    public interface IFileUploader
    {
        /// <summary>
        /// Retrieves the title of the File Upload page.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        string GetPageTitle();

        /// <summary>
        /// Retrieves the instructional content or message from the page.
        /// </summary>
        /// <returns>Content string found on the page.</returns>
        string GetPageContent();

        /// <summary>
        /// Chooses a file to be uploaded.
        /// </summary>
        /// <param name="filePath">Absolute path to the file.</param>
        void ChooseFile(string filePath);

        /// <summary>
        /// Chooses multiple files (if supported by the UI).
        /// </summary>
        /// <param name="filePaths">Array of absolute file paths.</param>
        void ChooseMultipleFiles(string[] filePaths);

        /// <summary>
        /// Returns the name of the file selected for upload.
        /// </summary>
        /// <returns>File name as displayed in the UI.</returns>
        string GetUploadedFileName();

        /// <summary>
        /// Clicks the upload button on the page.
        /// </summary>
        void ClickUploadButton();

        /// <summary>
        /// Verifies whether the file upload was successful.
        /// </summary>
        /// <returns>True if upload is successful, otherwise false.</returns>
        bool IsUploadSuccessful();
    }
}
