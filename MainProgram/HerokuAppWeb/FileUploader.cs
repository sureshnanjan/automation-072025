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
// This class implements the IFileUploader interface to automate the File Upload page at:
// https://the-internet.herokuapp.com/upload
// It uses Selenium WebDriver to interact with the UI components, supporting file selection,
// upload action, and post-upload verification.
// -------------------------------------------------------------------------------------------------

using System;
using System.IO;
using OpenQA.Selenium;
using HerokuOperations;

namespace HerokuAppWeb
{
    /// <summary>
    /// Implements the file upload functionality using Selenium WebDriver.
    /// Automates file selection, upload, and result verification.
    /// </summary>
    public class FileUploader : IFileUploader
    {
        private readonly IWebDriver _driver;
        private readonly string _uploadUrl = "https://the-internet.herokuapp.com/upload";

        // Element locators
        private readonly By titleLocator = By.TagName("h3");
        private readonly By contentLocator = By.ClassName("example");
        private readonly By fileInputLocator = By.Id("file-upload");
        private readonly By uploadButtonLocator = By.Id("file-submit");
        private readonly By uploadedFileNameLocator = By.Id("uploaded-files");
        private readonly By successMessageLocator = By.XPath("//h3[text()='File Uploaded!']");

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUploader"/> class and navigates to the upload page.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance.</param>
        public FileUploader(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _driver.Navigate().GoToUrl(_uploadUrl);
        }

        /// <summary>
        /// Gets the title of the upload page.
        /// </summary>
        /// <returns>The page title.</returns>
        public string GetPageTitle()
        {
            return _driver.Title;
        }

        /// <summary>
        /// Gets the instructional content or description from the page.
        /// </summary>
        /// <returns>Page content as a string.</returns>
        public string GetPageContent()
        {
            return _driver.FindElement(contentLocator).Text;
        }

        /// <summary>
        /// Selects a file to be uploaded.
        /// </summary>
        /// <param name="filePath">Absolute file path.</param>
        /// <exception cref="FileNotFoundException">Thrown if file is not found at the given path.</exception>
        public void ChooseFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file does not exist", filePath);

            var fileInput = _driver.FindElement(fileInputLocator);
            fileInput.SendKeys(filePath);
        }

        /// <summary>
        /// Selects multiple files to upload (if supported by the UI).
        /// </summary>
        /// <param name="filePaths">Array of absolute file paths.</param>
        /// <exception cref="FileNotFoundException">Thrown if any file path is invalid.</exception>
        public void ChooseMultipleFiles(string[] filePaths)
        {
            string combinedPaths = string.Join("\n", filePaths);

            foreach (var path in filePaths)
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException("One of the specified files does not exist", path);
            }

            var fileInput = _driver.FindElement(fileInputLocator);
            fileInput.SendKeys(combinedPaths);
        }

        /// <summary>
        /// Gets the uploaded file name as displayed on the page.
        /// </summary>
        /// <returns>Uploaded file name string.</returns>
        public string GetUploadedFileName()
        {
            return _driver.FindElement(uploadedFileNameLocator).Text;
        }

        /// <summary>
        /// Clicks the upload button on the page.
        /// </summary>
        public void ClickUploadButton()
        {
            _driver.FindElement(uploadButtonLocator).Click();
        }

        /// <summary>
        /// Verifies if the file upload was successful based on confirmation message.
        /// </summary>
        /// <returns><c>true</c> if upload was successful; otherwise, <c>false</c>.</returns>
        public bool IsUploadSuccessful()
        {
            try
            {
                return _driver.FindElement(successMessageLocator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
