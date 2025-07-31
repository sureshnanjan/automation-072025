/*******************************************************
* Copyright (c) 2025, Shreya S G
* All rights reserved.
* 
* File: SecureFileDownloadOperations.cs
* Purpose: Implements ISecureFileDownload for handling secure file downloads.
*******************************************************/
using System;
using System.Collections.Generic;

namespace HerokuOperations
{
    /// <summary>
    /// Concrete class to simulate secure file download functionality.
    /// </summary>
    public class SecureFileDownloadOperations : ISecureFileDownload
    {
        private bool isAuthenticated = false;
        private List<string> files = new List<string> { "file1.txt", "file2.pdf", "file3.docx" };

        public bool Authenticate(string username, string password)
        {
            if (username == "admin" && password == "password")
            {
                isAuthenticated = true;
                return true;
            }
            return false;
        }

        public List<string> GetAvailableFiles()
        {
            if (!isAuthenticated)
                throw new UnauthorizedAccessException("User not authenticated.");
            return files;
        }

        public string DownloadFile(string fileName)
        {
            if (!isAuthenticated)
                throw new UnauthorizedAccessException("User not authenticated.");

            if (files.Contains(fileName))
                return $"C:/Downloads/{fileName}";
            throw new FileNotFoundException("File not found.");
        }
    }
}
