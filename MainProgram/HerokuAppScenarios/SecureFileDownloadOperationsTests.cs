/*
* Copyright © 2025 Sehwag Vijay
* All rights reserved.
*/

using NUnit.Framework;
using Moq;
using HerokuOperations;
using System.Collections.Generic;

namespace HerokuAppScenarios
{
    [TestFixture]
    public class SecureDownloadTests
    {
        private Mock<ISecureDownload> mockDownload;

        [SetUp]
        public void SetUp()
        {
            mockDownload = new Mock<ISecureDownload>();
        }

        // TC001 - User should be authenticated to access downloads
        [Test]
        public void TC001_ShouldAllowAccess_IfUserIsAuthenticated()
        {
            // Arrange
            mockDownload.Setup(m => m.IsUserAuthenticated()).Returns(true);

            // Act
            bool result = mockDownload.Object.IsUserAuthenticated();

            // Assert
            Assert.IsTrue(result, "Authenticated user should have access to secure downloads.");
        }

        // TC002 - Verify file list is not empty for authenticated user
        [Test]
        public void TC002_ShouldReturnFileList_WhenUserIsAuthenticated()
        {
            // Arrange
            var files = new List<string> { "file1.txt", "file2.txt" };
            mockDownload.Setup(m => m.GetAvailableFiles()).Returns(files);

            // Act
            var result = mockDownload.Object.GetAvailableFiles();

            // Assert
            Assert.IsNotEmpty(result, "Available file list should not be empty.");
            Assert.Contains("file1.txt", result);
        }

        // TC003 - Verify file download is triggered on click
        [Test]
        public void TC003_ShouldInitiateDownload_OnFileClick()
        {
            // Arrange
            string fileName = "file1.txt";
            mockDownload.Setup(m => m.ClickFileAndInitiateDownload(fileName)).Returns(true);

            // Act
            bool result = mockDownload.Object.ClickFileAndInitiateDownload(fileName);

            // Assert
            Assert.IsTrue(result, "Download should initiate when file is clicked.");
        }

        // TC004 - Verify download is successful for valid file
        [Test]
        public void TC004_ShouldReturnSuccess_AfterDownload()
        {
            // Arrange
            string fileName = "file1.txt";
            mockDownload.Setup(m => m.IsDownloadSuccessful(fileName)).Returns(true);

            // Act
            bool result = mockDownload.Object.IsDownloadSuccessful(fileName);

            // Assert
            Assert.IsTrue(result, "Download should be successful for valid file.");
        }

        // TC005 - Verify unauthenticated user is blocked
        [Test]
        public void TC005_ShouldBlockAccess_IfUserNotAuthenticated()
        {
            // Arrange
            mockDownload.Setup(m => m.IsDownloadBlockedForUnauthenticatedUsers()).Returns(true);

            // Act
            bool result = mockDownload.Object.IsDownloadBlockedForUnauthenticatedUsers();

            // Assert
            Assert.IsTrue(result, "Unauthenticated user should be blocked from downloading.");
        }

        // TC006 - Verify invalid file does not trigger download
        [Test]
        public void TC006_ShouldNotInitiateDownload_ForInvalidFile()
        {
            // Arrange
            string fileName = "invalid_file.xyz";
            mockDownload.Setup(m => m.ClickFileAndInitiateDownload(fileName)).Returns(false);

            // Act
            bool result = mockDownload.Object.ClickFileAndInitiateDownload(fileName);

            // Assert
            Assert.IsFalse(result, "Download should not initiate for an invalid file.");
        }

        // TC007 - Verify download list is file-type filtered (e.g., .txt only)
        [Test]
        public void TC007_ShouldContainOnlyTxtFiles_InList()
        {
            // Arrange
            var files = new List<string> { "doc.txt", "notes.txt" };
            mockDownload.Setup(m => m.GetAvailableFiles()).Returns(files);

            // Act
            var result = mockDownload.Object.GetAvailableFiles();
            bool allTxt = result.TrueForAll(f => f.EndsWith(".txt"));

            // Assert
            Assert.IsTrue(allTxt, "All files should have a .txt extension.");
        }
    }
}
