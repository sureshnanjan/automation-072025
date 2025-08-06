// -------------------------------------------------------------------------------------------------
// © 2025 Gayathri Thalapathi. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// Author: Gayathri Thalapathi
// Date Created: 2025-08-01
//
// Description:
// This class implements the IDownloader interface using Selenium WebDriver. It enables
// automation of file download functionality from HerokuApp's file download page,
// including retrieving available file links, clicking a file to download, and verifying
// if the download has started by checking the system's download directory.
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium;

using HerokuOperations;

namespace HerokuAppWeb
{
    /// <summary>
    /// Implements file download automation using Selenium WebDriver.
    /// </summary>
    public class Downloader : IDownloader
    {
        private readonly IWebDriver _driver;
        private readonly string _downloadUrl = "https://the-internet.herokuapp.com/download";
        private readonly string _downloadDirectory;

        // Locator for download links
        private readonly By fileLinksLocator = By.CssSelector(".example a");

        /// <summary>
        /// Initializes a new instance of the <see cref="Downloader"/> class.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="downloadDirectory">The path to the system's download folder.</param>
        public Downloader(IWebDriver driver, string downloadDirectory)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _downloadDirectory = downloadDirectory ?? throw new ArgumentNullException(nameof(downloadDirectory));
            _driver.Navigate().GoToUrl(_downloadUrl);
        }

        /// <summary>
        /// Gets the list of all file names displayed for download.
        /// </summary>
        /// <returns>List of downloadable file names.</returns>
        public List<string> GetAllFileNames()
        {
            var elements = _driver.FindElements(fileLinksLocator);
            return elements.Select(e => e.Text.Trim()).Where(name => !string.IsNullOrEmpty(name)).ToList();
        }

        /// <summary>
        /// Clicks on the given file name link to start the download.
        /// </summary>
        /// <param name="fileName">The name of the file to download.</param>
        public void DownloadFile(string fileName)
        {
            var elements = _driver.FindElements(fileLinksLocator);
            var fileElement = elements.FirstOrDefault(e => e.Text.Trim().Equals(fileName, StringComparison.OrdinalIgnoreCase));

            if (fileElement == null)
                throw new FileNotFoundException($"File '{fileName}' not found on the page.");

            fileElement.Click();
        }

        /// <summary>
        /// Checks if the file exists in the download directory, indicating download started.
        /// </summary>
        /// <param name="fileName">File name to check.</param>
        /// <returns>True if file exists in download directory, else false.</returns>
        public bool IsDownloadStarted(string fileName)
        {
            string fullPath = Path.Combine(_downloadDirectory, fileName);
            return File.Exists(fullPath);
        }
    }
}
