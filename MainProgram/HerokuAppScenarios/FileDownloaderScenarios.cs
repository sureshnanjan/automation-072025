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
* file count retrieval, the list of available file names, and basic 
* file download initiation.
*******************************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using HerokuOperations;
using NUnit.Framework;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test scenarios for verifying file download functionality 
    /// on the HerokuApp File Downloader page.
    /// </summary>
    [TestFixture]
    public class FileDownloaderScenarios
    {
        [Test]
        public void GetFileDownloadTitle_ShouldReturnCorrectTitle()
        {
            // Arrange
            IDownloader downloader = TestDependencyResolver.Resolve<IDownloader>();
            string expectedTitle = "File Downloader";

            // Act
            string actualTitle = downloader.GetFileDownloadTitle();

            // Assert
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "The page title does not match the expected value.");
        }

        [Test]
        public void GetCountOfFiles_ShouldReturnPositiveNumber()
        {
            // Arrange
            IDownloader downloader = TestDependencyResolver.Resolve<IDownloader>();

            // Act
            int fileCount = downloader.GetCountOfFiles();

            // Assert
            Assert.That(fileCount, Is.GreaterThan(0), "The file count should be greater than zero.");
        }

        [Test]
        public void GetAllFileNames_ShouldReturnNonEmptyList()
        {
            // Arrange
            IDownloader downloader = TestDependencyResolver.Resolve<IDownloader>();

            // Act
            List<string> fileNames = downloader.GetAllFileNames();

            // Assert
            Assert.That(fileNames, Is.Not.Null.And.Not.Empty, "The list of file names should not be empty.");
        }

        [Test]
        public void DownloadFile_ShouldInitiateDownloadForValidFile()
        {
            // Arrange
            IDownloader downloader = TestDependencyResolver.Resolve<IDownloader>();
            string fileName = downloader.GetAllFileNames().FirstOrDefault();
            Assume.That(fileName, Is.Not.Null.And.Not.Empty, "No file found to initiate download.");

            // Act
            downloader.DownloadFile(fileName);

            // Assert
            bool isStarted = downloader.IsDownloadStarted(fileName);
            Assert.That(isStarted, Is.True, $"The download for file '{fileName}' did not start as expected.");
        }

        [Test]
        public void DownloadFile_ShouldNotInitiateForInvalidFile()
        {
            // Arrange
            IDownloader downloader = TestDependencyResolver.Resolve<IDownloader>();
            string invalidFileName = "non_existent_file.txt";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => downloader.DownloadFile(invalidFileName),
                "Downloading an invalid file name should throw an ArgumentException.");
        }
    }
}
