using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of IDownloader interface for automating file download verification.
    /// </summary>
    public class DownloaderPage : IDownloader
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://the-internet.herokuapp.com/download";
        private readonly string _downloadDirectory;

        // Locator for all download links
        private readonly By fileLinks = By.CssSelector(".example a");

        public DownloaderPage(IWebDriver driver, string downloadDirectory)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _downloadDirectory = downloadDirectory ?? throw new ArgumentNullException(nameof(downloadDirectory));

            _driver.Navigate().GoToUrl(_url);
        }

        public List<string> GetAllFileNames()
        {
            var elements = _driver.FindElements(fileLinks);
            return elements.Select(e => e.Text.Trim()).Where(name => !string.IsNullOrWhiteSpace(name)).ToList();
        }

        public void DownloadFile(string fileName)
        {
            var elements = _driver.FindElements(fileLinks);
            var target = elements.FirstOrDefault(e => e.Text.Trim().Equals(fileName, StringComparison.OrdinalIgnoreCase));

            if (target == null)
                throw new FileNotFoundException($"File link with name '{fileName}' not found on the page.");

            target.Click();
        }

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
