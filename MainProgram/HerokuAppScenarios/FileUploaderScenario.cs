//
// Copyright (c) 2025 Shreya S G (tester)
// All rights reserved.
//
// This file contains NUnit test cases for verifying file upload functionality
// on the Heroku upload page. These tests are structured using the Arrange-Act-Assert pattern
// and are based on functional test design techniques such as Equivalence Partitioning
// and Boundary Value Analysis.
//

using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test suite for validating the file upload functionality using the IFileUploader interface.
    /// </summary>
    [TestFixture]
    public class FileUploaderScenario
    {
        private IFileUploader _fileUploader;

        /// <summary>
        /// Test case: Verify that the page title is correct.
        /// </summary>
        [Test]
        public void PageTitle_ShouldBeCorrect()
        {
            // Arrange
            string expectedTitle = "File Uploader";

            // Act
            string actualTitle = _fileUploader.GetPageTitle();

            // Assert
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Page title does not match expected value.");
        }

        /// <summary>
        /// Test case: Verify that the page contains expected instructional text/content.
        /// </summary>
        [Test]
        public void PageContent_ShouldContainInstructionText()
        {
            // Arrange
            string expectedText = "Choose a file and click upload";

            // Act
            string pageContent = _fileUploader.GetPageContent();

            // Assert
            Assert.That(pageContent, Does.Contain(expectedText), "Page content does not contain expected instructions.");
        }

        /// <summary>
        /// Test case: Verify that a file can be selected for upload.
        /// </summary>
        [Test]
        public void ChooseFile_ShouldDisplaySelectedFileName()
        {
            // Arrange
            string filePath = @"C:\TestFiles\sample.txt";
            string expectedFileName = "sample.txt";

            // Act
            _fileUploader.ChooseFile(filePath);
            string actualFileName = _fileUploader.GetUploadedFileName();

            // Assert
            Assert.That(actualFileName, Is.EqualTo(expectedFileName), "Selected file name is not displayed correctly.");
        }

        /// <summary>
        /// Test case: Verify that uploading a valid file is successful.
        /// (Equivalence Partitioning)
        /// </summary>
        [Test]
        public void Upload_ValidFile_ShouldBeSuccessful()
        {
            // Arrange
            string filePath = @"C:\TestFiles\validfile.txt";
            _fileUploader.ChooseFile(filePath);

            // Act
            _fileUploader.ClickUploadButton();
            bool isUploaded = _fileUploader.IsUploadSuccessful();

            // Assert
            Assert.That(isUploaded, Is.True, "Valid file upload did not succeed.");
        }

        /// <summary>
        /// Test case: Verify that uploading with no file selected fails.
        /// (Negative Testing)
        /// </summary>
        [Test]
        public void Upload_NoFileSelected_ShouldFail()
        {
            // Arrange
            // No file chosen.

            // Act
            _fileUploader.ClickUploadButton();
            bool isUploaded = _fileUploader.IsUploadSuccessful();

            // Assert
            Assert.That(isUploaded, Is.False, "Upload succeeded without selecting a file.");
        }

        /// <summary>
        /// Test case: Verify that multiple files cannot be chosen (or handled correctly if allowed).
        /// </summary>
        [Test]
        public void ChooseFile_MultipleFiles_ShouldHandleAccordingly()
        {
            // Arrange
            string[] files = { @"C:\TestFiles\file1.txt", @"C:\TestFiles\file2.txt" };

            // Act
            _fileUploader.ChooseMultipleFiles(files); // Hypothetical method for multiple selection
            string actualFileName = _fileUploader.GetUploadedFileName();

            // Assert
            Assert.That(actualFileName, Is.EqualTo("file2.txt"), "File uploader did not handle multiple file selection as expected.");
        }

        /// <summary>
        /// Test case: Verify that replacing a selected file updates the file to be uploaded.
        /// </summary>
        [Test]
        public void ChooseFile_ReplaceSelectedFile_ShouldUpdateSelection()
        {
            // Arrange
            string initialFile = @"C:\TestFiles\file1.txt";
            string replacementFile = @"C:\TestFiles\file2.txt";
            _fileUploader.ChooseFile(initialFile);

            // Act
            _fileUploader.ChooseFile(replacementFile);
            string actualFileName = _fileUploader.GetUploadedFileName();

            // Assert
            Assert.That(actualFileName, Is.EqualTo("file2.txt"), "Replacing the selected file did not update the file name.");
        }
    }
}
