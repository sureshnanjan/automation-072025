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
using System.IO;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of the IFileUploader interface for interacting with the File Upload page.
    /// Provides methods for choosing files, uploading, and verifying the results.
    /// </summary>
    public class FileUploaderPage : IFileUploader
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://the-internet.herokuapp.com/upload";

        // Locators
        private readonly By fileInput = By.Id("file-upload");
        private readonly By uploadButton = By.Id("file-submit");
        private readonly By uploadedFiles = By.Id("uploaded-files");
        private readonly By successMessage = By.TagName("h3");

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUploaderPage"/> class and navigates to the upload page.
        /// </summary>
        /// <param name="driver">Instance of the Selenium WebDriver.</param>
        /// <exception cref="ArgumentNullException">Thrown when driver is null.</exception>
        public FileUploaderPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _driver.Navigate().GoToUrl(_url);
        }

        /// <summary>
        /// Retrieves the title of the file upload page.
        /// </summary>
        /// <returns>The page title as a string.</returns>
        public string GetPageTitle()
        {
            return _driver.Title;
        }

        /// <summary>
        /// Retrieves the main header content of the file upload page.
        /// </summary>
        /// <returns>The text content of the main header.</returns>
        public string GetPageContent()
        {
            return _driver.FindElement(By.TagName("h3")).Text;
        }

        /// <summary>
        /// Uploads a file by selecting it from the specified path.
        /// </summary>
        /// <param name="filePath">The absolute path to the file to be uploaded.</param>
        /// <exception cref="FileNotFoundException">Thrown when the specified file does not exist.</exception>
        public void ChooseFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found at: " + filePath);

            _driver.FindElement(fileInput).SendKeys(filePath);
        }

        /// <summary>
        /// Uploads multiple files by selecting them from the specified paths.
        /// Note: May not work in all browsers as HTML input type="file" often does not support multiple via SendKeys.
        /// </summary>
        /// <param name="filePaths">An array of file paths to be uploaded.</param>
        public void ChooseMultipleFiles(string[] filePaths)
        {
            string combinedPaths = string.Join("\n", filePaths);
            _driver.FindElement(fileInput).SendKeys(combinedPaths);
        }

        /// <summary>
        /// Clicks the "Upload" button to submit the selected file(s).
        /// </summary>
        public void ClickUploadButton()
        {
            _driver.FindElement(uploadButton).Click();
        }

        /// <summary>
        /// Retrieves the name of the file that was uploaded, as displayed on the confirmation page.
        /// </summary>
        /// <returns>The name of the uploaded file as a string.</returns>
        public string GetUploadedFileName()
        {
            return _driver.FindElement(uploadedFiles).Text.Trim();
        }

        /// <summary>
        /// Checks whether the upload was successful by verifying the confirmation message.
        /// </summary>
        /// <returns>True if the message "File Uploaded!" is displayed, false otherwise.</returns>
        public bool IsUploadSuccessful()
        {
            string result = _driver.FindElement(successMessage).Text.Trim();
            return result.Equals("File Uploaded!", StringComparison.OrdinalIgnoreCase);
        }
    }
}
