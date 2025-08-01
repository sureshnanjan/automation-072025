// Author: Siva Sree
// Date Created: 2025-07-31
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This class implements the IDownloader interface using Selenium WebDriver to
// automate file download operations from the Heroku download page.

using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;

namespace HerokuOperations
{
    public class Downloader : IDownloader
    {
        private readonly IWebDriver _driver;
        private readonly string _downloadPath;

        public Downloader(IWebDriver driver, string downloadPath)
        {
            _driver = driver;
            _downloadPath = downloadPath;
        }

        /// <summary>
        /// Gets the list of all downloadable file names shown on the page.
        /// </summary>
        /// <returns>A list of file names available for download.</returns>
        public List<string> GetAllFileNames()
        {
            var fileElements = _driver.FindElements(By.CssSelector(".example a"));
            return fileElements.Select(el => el.Text.Trim()).ToList();
        }

        /// <summary>
        /// Clicks on the specified file to initiate its download.
        /// </summary>
        /// <param name="fileName">The name of the file to be downloaded.</param>
        public void DownloadFile(string fileName)
        {
            var fileElements = _driver.FindElements(By.CssSelector(".example a"));
            foreach (var fileElement in fileElements)
            {
                if (fileElement.Text.Trim() == fileName)
                {
                    fileElement.Click();
                    break;
                }
            }
        }

        /// <summary>
        /// Checks whether the specified file has started downloading.
        /// </summary>
        /// <param name="fileName">The name of the file to check for download.</param>
        /// <returns>True if the download has started; otherwise, false.</returns>
        public bool IsDownloadStarted(string fileName)
        {
            string fullPath = Path.Combine(_downloadPath, fileName);
            int timeoutSeconds = 10;
            int elapsed = 0;

            while (elapsed < timeoutSeconds)
            {
                if (File.Exists(fullPath))
                {
                    return true;
                }
                Thread.Sleep(1000); // Wait 1 second
                elapsed++;
            }

            return false;
        }




        /// <summary>
        /// Gets the page title of the file download page.
        /// </summary>
        /// <returns>The title of the page.</returns>
        public string GetFileDownloadTitle()
        {
            return _driver.Title;
        }

        /// <summary>
        /// Gets the count of downloadable files shown on the page.
        /// </summary>
        /// <returns>The total number of downloadable files.</returns>
        public int GetCountOfFiles()
        {
            var fileElements = _driver.FindElements(By.CssSelector(".example a"));
            return fileElements.Count;
        }
    }
}
