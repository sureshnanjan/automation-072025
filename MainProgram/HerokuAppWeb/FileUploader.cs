// Author: Siva Sree
// Date Created: 2025-07-31
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// Implements the IFileUploader interface using Selenium WebDriver to automate
// file upload testing on https://the-internet.herokuapp.com/upload.

using OpenQA.Selenium;

namespace HerokuOperations
{
    /// <summary>
    /// Implements file upload operations for the Heroku upload page.
    /// </summary>
    internal class FileUploader : IFileUploader
    {
        private readonly IWebDriver _driver;

        /// <summary>
        /// Initializes a new instance of the FileUploader class.
        /// </summary>
        /// <param name="driver">Selenium WebDriver instance.</param>
        public FileUploader(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Sets the file path in the file input element.
        /// </summary>
        /// <param name="filePath">The full path of the file to be uploaded.</param>
        public void ChooseFile(string filePath)
        {
            var fileInput = _driver.FindElement(By.Id("file-upload"));
            fileInput.SendKeys(filePath);
        }

        /// <summary>
        /// Clicks the "Upload" button.
        /// </summary>
        public void ClickUploadButton()
        {
            var uploadButton = _driver.FindElement(By.Id("file-submit"));
            uploadButton.Click();
        }

        /// <summary>
        /// Checks if the upload was successful by looking for the "File Uploaded!" heading.
        /// </summary>
        /// <returns>True if the upload was successful; otherwise, false.</returns>
        public bool IsUploadSuccessful()
        {
            try
            {
                var successMessage = _driver.FindElement(By.TagName("h3")).Text;
                return successMessage.Contains("File Uploaded!");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves the uploaded file name from the confirmation message.
        /// </summary>
        /// <returns>The name of the uploaded file.</returns>
        public string GetUploadedFileName()
        {
            try
            {
                return _driver.FindElement(By.Id("uploaded-files")).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
    }
}
