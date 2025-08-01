// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DragAndDropTest.cs" author="Jagadeeswar Reddy Arava">
//   © 2025 Jagadeeswar Reddy Arava. All rights reserved.
// </copyright>
//

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Test class to verify Drag and Drop functionality.
    /// </summary>
    public class DragAndDropTest
    {
        public IWebDriver _driver;
        private DragDrop _page;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");
            _page = new DragDrop(_driver); //Initializes your page object
 
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void DragAtoB_ChangesColumnText()
        {
            // Arrange
            string initialAText = _page.GetColumnAText();
            string initialBText = _page.GetColumnBText();

            // Act
            _page.DragAtoB();
            string afterDragAText = _page.GetColumnAText();
            string afterDragBText = _page.GetColumnBText();

            // Assert
            Assert.AreNotEqual(initialAText, afterDragAText, "Column A text should change after drag.");
            Assert.AreNotEqual(initialBText, afterDragBText, "Column B text should change after drag.");
        }

        [Test]
        public void DragBtoA_ChangesColumnText()
        {
            // Arrange
            _page.DragAtoB(); // First drag A to B to set state
            string draggedAText = _page.GetColumnAText();
            string draggedBText = _page.GetColumnBText();

            // Act
            _page.DragBtoA();
            string afterDragAText = _page.GetColumnAText();
            string afterDragBText = _page.GetColumnBText();

            // Assert
            Assert.AreNotEqual(draggedAText, afterDragAText, "Column A text should change after reverse drag.");
            Assert.AreNotEqual(draggedBText, afterDragBText, "Column B text should change after reverse drag.");
        }
    }
}
