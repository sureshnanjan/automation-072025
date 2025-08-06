/*******************************************************
* Copyright (c) 2025, Arpita Neogi
* All rights reserved.
* 
* File: SecureFileDownloadPage.cs
* Purpose: Implements ISecureFileDownload interface for
*          interacting with secure file downloads using Selenium and HttpClient.
*******************************************************/
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of ISecureFileDownload interface to manage
    /// authentication, file listing, and secure download functionality.
    /// Uses HttpClient instead of obsolete WebClient.
    /// </summary>
    public class SecureFileDownloadPage : ISecureFileDownload
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly string _downloadUrl = "https://the-internet.herokuapp.com/download_secure";
        private readonly string _baseUrl = "https://the-internet.herokuapp.com";

        public SecureFileDownloadPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        /// <inheritdoc/>
        public bool IsUserAuthenticated()
        {
            return !_driver.PageSource.Contains("Not authorized")
                && _driver.Url.Contains("download_secure");
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetAvailableFiles()
        {
            _driver.Navigate().GoToUrl(_downloadUrl);
            _wait.Until(d => d.FindElements(By.CssSelector("div.example a")).Count > 0);

            var fileLinks = _driver.FindElements(By.CssSelector("div.example a"));
            return fileLinks.Select(link => link.Text).ToList();
        }

        /// <inheritdoc/>
        public byte[] DownloadFile(string fileName)
        {
            string fileUrl = $"{_baseUrl}/download_secure/{fileName}";

            using (var httpClient = new HttpClient())
            {
                // Attach session cookies from browser to HttpClient
                var cookies = _driver.Manage().Cookies.AllCookies;
                string cookieHeader = string.Join("; ", cookies.Select(c => $"{c.Name}={c.Value}"));
                httpClient.DefaultRequestHeaders.Add("Cookie", cookieHeader);

                var response = httpClient.GetAsync(fileUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsByteArrayAsync().Result;
                }
                else
                {
                    throw new InvalidOperationException($"Failed to download {fileName}. Status: {response.StatusCode}");
                }
            }
        }

        /// <inheritdoc/>
        public void Logout()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().GoToUrl(_baseUrl);
        }

        /// <inheritdoc/>
        public bool ReAuthenticate(string username, string password)
        {
            try
            {
                string authUrl = $"https://{username}:{password}@the-internet.herokuapp.com/download_secure";
                _driver.Navigate().GoToUrl(authUrl);
                return IsUserAuthenticated();
            }
            catch
            {
                return false;
            }
        }
    }
}
