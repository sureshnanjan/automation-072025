// -------------------------------------------------------------------------------------------------
// © 2025 Elangovan R. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// Author: Elangovan R
// Created On: [Insert Date Here, e.g., 2025-08-05]
//
// Description:
// [Briefly describe the purpose of this file, e.g.]
// This class implements the RedirectPage functionality to verify HTTP redirection behavior
// using Selenium WebDriver.
// -------------------------------------------------------------------------------------------------


using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of the <see cref="IDownloader"/> interface for automating file download verification.
    /// Provides methods to list available files, download a file, and verify if a download has started.
    /// </summary>
    public class DownloaderPage : IDownloader
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://the-internet.herokuapp.com/download";
        private readonly string _downloadDirectory;

        // Locator for all downloadable file links
        private readonly By fileLinks = By.CssSelector(".example a");

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloaderPage"/> class and navigates to the download page.
        /// </summary>
        /// <param name="driver">Instance of Selenium WebDriver.</param>
        /// <param name="downloadDirectory">Directory path where downloaded files will be saved.</param>
        /// <exception cref="ArgumentNullException">Thrown if driver or downloadDirectory is null.</exception>
        public DownloaderPage(IWebDriver driver, string downloadDirectory)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _downloadDirectory = downloadDirectory ?? throw new ArgumentNullException(nameof(downloadDirectory));

            _driver.Navigate().GoToUrl(_url);
        }

        /// <summary>
        /// Retrieves all file names listed on the download page.
        /// </summary>
        /// <returns>A list of file names as strings.</returns>
        public List<string> GetAllFileNames()
        {
            var elements = _driver.FindElements(fileLinks);
            return elements.Select(e => e.Text.Trim()).Where(name => !string.IsNullOrWhiteSpace(name)).ToList();
        }

        /// <summary>
        /// Initiates the download of a file with the specified name by clicking the link on the page.
        /// </summary>
        /// <param name="fileName">The name of the file to download (as shown on the page).</param>
        /// <exception cref="FileNotFoundException">Thrown if the file link is not found on the page.</exception>
        public void DownloadFile(string fileName)
        {
            var elements = _driver.FindElements(fileLinks);
            var target = elements.FirstOrDefault(e => e.Text.Trim().Equals(fileName, StringComparison.OrdinalIgnoreCase));

            if (target == null)
                throw new FileNotFoundException($"File link with name '{fileName}' not found on the page.");

            target.Click();
        }

        /// <summary>
        /// Checks whether the file download has started and the file exists in the specified download directory.
        /// </summary>
        /// <param name="fileName">The name of the file to check for.</param>
        /// <returns>True if the file exists in the download directory within the timeout period; otherwise, false.</returns>
        public bool IsDownloadStarted(string fileName)
        {
            string expectedPath = Path.Combine(_downloadDirectory, fileName);

            const int timeoutSeconds = 10;
            int elapsed = 0;
            while (elapsed < timeoutSeconds)
            {
                if (File.Exists(expectedPath))
                    return true;

                Thread.Sleep(500); // Wait 0.5 second
                elapsed += 1;
            }

            return false;
        }
    }
}
