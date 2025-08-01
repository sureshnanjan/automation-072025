using HerokuAppWeb.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Tests to verify the behavior of the Add/Remove Elements page.
    /// </summary>
    public class AddRemoveElementsTest
    {
        private IWebDriver _driver;
        private AddRemoveElementsPage _page;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");
            _page = new AddRemoveElementsPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void AddElementButton_ShouldAddDeleteButton()
        {
            // Arrange
            int initialCount = _page.GetDeleteButtonCount();

            // Act
            _page.ClickAddElementButton();
            int updatedCount = _page.GetDeleteButtonCount();

            // Assert
            Assert.AreEqual(initialCount + 1, updatedCount, "Clicking 'Add Element' should increase delete buttons by 1.");
        }

        [Test]
        public void DeleteButton_ShouldRemoveElement()
        {
            // Arrange
            _page.ClickAddElementButton(); // Add one
            int countAfterAdd = _page.GetDeleteButtonCount();

            // Act
            _page.ClickDeleteButton();
            int countAfterDelete = _page.GetDeleteButtonCount();

            // Assert
            Assert.AreEqual(countAfterAdd - 1, countAfterDelete, "Clicking 'Delete' should remove the element.");
        }

        [Test]
        public void IsDeleteButtonDisplayed_ShouldBeTrueAfterAdd()
        {
            // Arrange
            _page.ClickAddElementButton();

            // Act
            bool result = _page.IsDeleteButtonDisplayed();

            // Assert
            Assert.IsTrue(result, "'Delete' button should be visible after adding.");
        }

        [Test]
        public void IsDeleteButtonDisplayed_ShouldBeFalseInitially()
        {
            // Act
            bool result = _page.IsDeleteButtonDisplayed();

            // Assert
            Assert.IsFalse(result, "'Delete' button should not be visible initially.");
        }
    }
}
