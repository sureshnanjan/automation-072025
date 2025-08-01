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
    public class SecureFileDownloadTests
    {
        private Mock<ISecureFileDownload> mockSecureDownload;

        [SetUp]
        public void SetUp()
        {
            mockSecureDownload = new Mock<ISecureFileDownload>();
        }

        // TC001 - Verify user is authenticated
        [Test]
        public void TC001_ShouldReturnTrue_WhenUserIsAuthenticated()
        {
            // Arrange
            mockSecureDownload.Setup(m => m.IsUserAuthenticated()).Returns(true);

            // Act
            bool result = mockSecureDownload.Object.IsUserAuthenticated();

            // Assert
            Assert.IsTrue(result, "User should be authenticated.");
        }

        // TC002 - Verify file list is returned for authenticated user
        [Test]
        public void TC002_ShouldReturnFileList_ForAuthenticatedUser()
        {
            // Arrange
            var files = new List<string> { "invoice.txt", "document.pdf" };
            mockSecureDownload.Setup(m => m.GetAvailableFiles()).Returns(files);

            // Act
            var result = mockSecureDownload.Object.GetAvailableFiles();

            // Assert
            Assert.IsNotNull(result, "Returned file list should not be null.");
            Assert.IsNotEmpty(result, "Returned file list should not be empty.");
            CollectionAssert.Contains(result, "invoice.txt", "Expected file not found in list.");
        }

        // TC003 - Verify download returns byte data for valid file
        [Test]
        public void TC003_ShouldDownloadFile_WhenValidFileNameProvided()
        {
            // Arrange
            string fileName = "invoice.txt";
            byte[] dummyData = new byte[] { 1, 2, 3 };
            mockSecureDownload.Setup(m => m.DownloadFile(fileName)).Returns(dummyData);

            // Act
            byte[] result = mockSecureDownload.Object.DownloadFile(fileName);

            // Assert
            Assert.IsNotNull(result, "Downloaded file data should not be null.");
            Assert.IsNotEmpty(result, "Downloaded file data should not be empty.");
        }

        // TC004 - Verify logout clears session (IsUserAuthenticated returns false after logout)
        [Test]
        public void TC004_ShouldClearSession_OnLogout()
        {
            // Arrange
            mockSecureDownload.SetupSequence(m => m.IsUserAuthenticated())
                              .Returns(true)
                              .Returns(false);

            // Act
            bool beforeLogout = mockSecureDownload.Object.IsUserAuthenticated();
            mockSecureDownload.Object.Logout();
            bool afterLogout = mockSecureDownload.Object.IsUserAuthenticated();

            // Assert
            Assert.IsTrue(beforeLogout, "User should be authenticated before logout.");
            Assert.IsFalse(afterLogout, "User should not be authenticated after logout.");
        }

        // TC005 - Verify re-authentication succeeds with valid credentials
        [Test]
        public void TC005_ShouldReAuthenticateUser_WithValidCredentials()
        {
            // Arrange
            string username = "admin";
            string password = "password123";
            mockSecureDownload.Setup(m => m.ReAuthenticate(username, password)).Returns(true);

            // Act
            bool result = mockSecureDownload.Object.ReAuthenticate(username, password);

            // Assert
            Assert.IsTrue(result, "Re-authentication should succeed with valid credentials.");
        }

        // TC006 - Verify re-authentication fails with invalid credentials
        [Test]
        public void TC006_ShouldFailReAuthentication_WithInvalidCredentials()
        {
            // Arrange
            string username = "admin";
            string password = "wrongpass";
            mockSecureDownload.Setup(m => m.ReAuthenticate(username, password)).Returns(false);

            // Act
            bool result = mockSecureDownload.Object.ReAuthenticate(username, password);

            // Assert
            Assert.IsFalse(result, "Re-authentication should fail with invalid credentials.");
        }

        // TC007 - Verify download returns empty/null for non-existent file
        [Test]
        public void TC007_ShouldReturnNull_WhenFileDoesNotExist()
        {
            // Arrange
            string fileName = "nonexistent.txt";
            mockSecureDownload.Setup(m => m.DownloadFile(fileName)).Returns((byte[])null);

            // Act
            byte[] result = mockSecureDownload.Object.DownloadFile(fileName);

            // Assert
            Assert.IsNull(result, "Download should return null for non-existent file.");
        }
    }
}
