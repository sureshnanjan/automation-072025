// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultipleWindowsTests.cs">
//     Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
//     This file contains manually written NUnit tests to validate UI behavior of
//     the Multiple Windows page at https://the-internet.herokuapp.com/windows.
//     Tests are structured using the AAA pattern and interface abstraction (IWindows).
// --------------------------------------------------------------------------------------------------------------------
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using System;

namespace HerokuAppScenarios
{
    [TestFixture]
    public class WindowsTest
    {
        private IWebDriver driver;
        private IWindow windowsPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            driver.Manage().Window.Maximize();
            windowsPage = new Windows(driver);
        }

        [Test]
        public void Should_Display_MainWindow_Heading_Correctly()
        {
            // Arrange
            string expected = "Opening a new window";

            // Act
            string actual = windowsPage.GetMainWindowHeading();

            // Assert
            Assert.AreEqual(expected, actual, "Main window heading mismatch.");
        }

        [Test]
        public void Should_Open_New_Window_And_Display_Expected_Heading()
        {
            // Arrange
            string expectedNewHeading = "New Window";

            // Act
            windowsPage.OpenNewWindow();
            string actualNewHeading = windowsPage.GetNewWindowHeading();

            // Assert
            Assert.AreEqual(expectedNewHeading, actualNewHeading, "New window heading mismatch.");
        }

        [Test]
        public void Should_Have_One_Window_Before_Click()
        {
            // Arrange & Act
            int numberOfWindows = windowsPage.GetNumberOfWindows();

            // Assert
            Assert.AreEqual(1, numberOfWindows, "Unexpected number of windows before clicking.");
        }

        [Test]
        public void Should_Have_Two_Windows_After_Click()
        {
            // Arrange
            windowsPage.OpenNewWindow();

            // Act
            bool isOpened = windowsPage.IsNewWindowOpened();

            // Assert
            Assert.IsTrue(isOpened, "New window was not opened.");
        }

        [Test]
        public void Should_Close_New_Window_And_Return_To_Main()
        {
            // Arrange
            string expectedMain = "Opening a new window";
            windowsPage.OpenNewWindow();
            string newWindowHeading = windowsPage.GetNewWindowHeading();

            // Act
            string mainHeadingAfterReturn = windowsPage.GetMainWindowHeading();

            // Assert
            Assert.AreEqual("New Window", newWindowHeading, "New window heading mismatch.");
            Assert.AreEqual(expectedMain, mainHeadingAfterReturn, "Did not return to main window correctly.");
        }

        [Test]
        public void Should_Throw_Exception_If_New_Window_Not_Opened()
        {
            // Arrange
            var originalHandle = driver.CurrentWindowHandle;
            var handlesBefore = driver.WindowHandles.Count;

            // Act & Assert
            Assert.Throws<Exception>(() =>
            {
                // Trying to fetch new window without clicking
                windowsPage.GetNewWindowHeading();
            }, "Expected exception not thrown when new window is not opened.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
