/*
* Copyright © 2025 Sehwag Vijay
* All rights reserved.
*/

using NUnit.Framework;
using HerokuOperations;
using System;
using System.Collections.Generic;
using System.IO;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Unit tests for SecureFileDownloadOperations.
    /// Verifies authentication, file listing, and secure downloading behavior.
    /// </summary>
    [TestFixture]
    public class SecureFileDownloadOperationsTests
    {
        private ISecureFileDownload fileDownloader;

        /// <summary>
        /// Creates a new instance before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            fileDownloader = new SecureFileDownloadOperations();
        }

        /// <summary>
        /// Valid credentials should authenticate successfully.
        /// </summary>
        [Test]
        public void Authenticate_ShouldReturnTrue_WhenCredentialsAreValid()
        {
            bool result = fileDownloader.Authenticate("admin", "password");
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Invalid credentials should fail authentication.
        /// </summary>
        [Test]
        public void Authenticate_ShouldReturnFalse_WhenCredentialsAreInvalid()
        {
            bool result = fileDownloader.Authenticate("user", "1234");
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Authenticated users should see the list of available files.
        /// </summary>
        [Test]
        public void GetAvailableFiles_ShouldReturnFiles_WhenAuthenticated()
        {
            fileDownloader.Authenticate("admin", "password");
            var files = fileDownloader.GetAvailableFiles();
            CollectionAssert.AreEquivalent(new List<string> { "file1.txt", "file2.pdf", "file3.docx" }, files);
        }

        /// <summary>
        /// Unauthenticated access to file list should throw exception.
        /// </summary>
        [Test]
        public void GetAvailableFiles_ShouldThrowException_WhenNotAuthenticated()
        {
            Assert.Throws<UnauthorizedAccessException>(() => fileDownloader.GetAvailableFiles());
        }

        /// <summary>
        /// Downloading an existing file should return the expected path.
        /// </summary>
        [Test]
        public void DownloadFile_ShouldReturnPath_WhenAuthenticatedAndFileExists()
        {
            fileDownloader.Authenticate("admin", "password");
            string path = fileDownloader.DownloadFile("file1.txt");
            Assert.AreEqual("C:/Downloads/file1.txt", path);
        }

        /// <summary>
        /// Unauthenticated download attempt should throw an exception.
        /// </summary>
        [Test]
        public void DownloadFile_ShouldThrowException_WhenNotAuthenticated()
        {
            Assert.Throws<UnauthorizedAccessException>(() => fileDownloader.DownloadFile("file1.txt"));
        }

        /// <summary>
        /// Attempt to download a non-existent file should throw FileNotFoundException.
        /// </summary>
        [Test]
        public void DownloadFile_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
        {
            fileDownloader.Authenticate("admin", "password");
            Assert.Throws<FileNotFoundException>(() => fileDownloader.DownloadFile("nonexistent.zip"));
        }
    }
}

