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

/// <summary>
/// Simple test case definitions for verifying the methods 
/// of the IDownloader interface in a file download scenario.
/// </summary>
public class FileDownloaderScenarios
{
    /// <summary>
    /// Test to verify that GetAllFileNames returns a non-empty list.
    /// This ensures that downloadable files are listed on the page.
    /// </summary>
    [Test]
    public void GetAllFileNames_ShouldReturnNonEmptyList()
    {
        IDownloader downloader;
        List<string> fileNames = downloader.GetAllFileNames();
        Assert.That(fileNames, Is.Not.Null.And.Not.Empty, "Expected at least one file to be available for download.");
    }

    /// <summary>
    /// Test to verify that downloading a valid file initiates a download.
    /// </summary>
    [Test]
    public void DownloadFile_ValidFile_ShouldStartDownload()
    {
        IDownloader downloader;
        string fileName = downloader.GetAllFileNames().FirstOrDefault();
        Assert.That(fileName, Is.Not.Null.And.Not.Empty, "No file available to download.");

        downloader.DownloadFile(fileName);
        bool isStarted = downloader.IsDownloadStarted(fileName);
        Assert.That(isStarted, Is.True, "Download did not start for the selected file.");
    }

    /// <summary>
    /// Test to verify that downloading an invalid file throws an exception.
    /// This checks the system's handling of incorrect input.
    /// </summary>
    [Test]
    public void DownloadFile_InvalidFile_ShouldThrowException()
    {
        IDownloader downloader;
        string invalidFile = "invalid_file_123.txt";

        bool exceptionThrown = false;
        try
        {
            downloader.DownloadFile(invalidFile);
        }
        catch (ArgumentException)
        {
            exceptionThrown = true;
        }

        Assert.That(exceptionThrown, Is.True, "Expected ArgumentException when downloading an invalid file.");
    }

    /// <summary>
    /// Test to verify that IsDownloadStarted returns false before a file is downloaded.
    /// Ensures download state tracking works as expected.
    /// </summary>
    [Test]
    public void IsDownloadStarted_WithoutDownloading_ShouldReturnFalse()
    {
        IDownloader downloader;
        string fileName = "somefile.txt";
        bool isStarted = downloader.IsDownloadStarted(fileName);
        Assert.That(isStarted, Is.False, "Expected false when checking download status before starting.");
    }
}
