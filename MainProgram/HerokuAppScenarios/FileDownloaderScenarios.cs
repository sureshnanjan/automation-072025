/*******************************************************
* Copyright (c) 2025, Shreya S G
* All rights reserved.
* 
* File: FileDownloaderScenarios.cs
* Purpose: Test scenarios for verifying file download functionality 
*          in the HerokuApp "File Downloader" page.
* 
* Description:
* This file contains NUnit test cases for the `IDownloader` interface 
* in the `HerokuOperations` namespace. It tests page title retrieval, 
* file count retrieval, and the list of available file names.
*******************************************************/

using System;
using System.Linq;
using HerokuOperations;
using NUnit.Framework;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test scenarios for verifying file download functionality 
    /// on the HerokuApp File Downloader page.
    /// </summary>
    public class FileDownloaderScenarios
    {
        private IDownloader downloader;

        /// <summary>
        /// Initializes resources before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // TODO: Initialize a concrete or mocked implementation of IDownloader
            // Example: downloader = new FileDownloader(driver);
        }

        /// <summary>
        /// Verifies that the page title for the File Downloader page is correct.
        /// </summary>
        [Test]
        public void FileDownLoadIsTitleOk()
        {
            string expected = "File Downloader";
            string actual = downloader.GetFileDownloadTitle();
            Assert.AreEqual(expected, actual, "The page title does not match the expected value.");
        }

        /// <summary>
        /// Verifies that the number of downloadable files returned is correct.
        /// </summary>
        [Test]
        public void GetCountOfFiles_ReturnsCorrectCount()
        {
            int expectedCount = 1;
            int actualCount = downloader.GetCountOfFiles();
            Assert.AreEqual(expectedCount, actualCount, "The count of downloadable files is incorrect.");
        }

        /// <summary>
        /// Verifies that the list of file names returned is correct.
        /// </summary>
        [Test]
        public void GetAllFileNames_ReturnsFileNames()
        {
            var fileNames = downloader.GetAllFileNames();
            Assert.IsNotNull(fileNames, "The list of file names should not be null.");
            Assert.AreEqual(1, fileNames.Count, "Unexpected number of file names returned.");
            Assert.AreEqual("testfile.txt", fileNames.First(), "The first file name does not match the expected value.");
        }
    }
}
