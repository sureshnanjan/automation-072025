using OpenQA.Selenium;
using System;
using System.IO;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of the IFileUploader interface for interacting with the File Upload page.
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
        /// Constructor for FileUploaderPage.
        /// </summary>
        /// <param name="driver">Instance of WebDriver.</param>
        public FileUploaderPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _driver.Navigate().GoToUrl(_url);
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }

        public string GetPageContent()
        {
            return _driver.FindElement(By.TagName("h3")).Text;
        }

        public void ChooseFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found at: " + filePath);

            _driver.FindElement(fileInput).SendKeys(filePath);
        }

        public void ChooseMultipleFiles(string[] filePaths)
        {
            string combinedPaths = string.Join("\n", filePaths);
            _driver.FindElement(fileInput).SendKeys(combinedPaths);
        }

        public void ClickUploadButton()
        {
            _driver.FindElement(uploadButton).Click();
        }

        public string GetUploadedFileName()
        {
            return _driver.FindElement(uploadedFiles).Text.Trim();
        }

        public bool IsUploadSuccessful()
        {
            string result = _driver.FindElement(successMessage).Text.Trim();
            return result.Equals("File Uploaded!", StringComparison.OrdinalIgnoreCase);
        }
    }
}
