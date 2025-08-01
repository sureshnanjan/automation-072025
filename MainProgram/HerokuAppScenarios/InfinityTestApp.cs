using HerokuOperations;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace HerokuAppScenarios
{
    [TestFixture]
    public class InfinityTestApp
    {
        private ChromeDriver driver;
        private IInfinity page;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            page = new Infinity(driver); // Use correct reference from HerokuOperations
        }

        [TearDown]
        public void Teardown()
        {
            driver.Dispose(); // Properly dispose the ChromeDriver
        }

        [Test]
        public void ScrollToBottom_ShouldScrollDown()
        {
            // Arrange
            page.GotoPage();
            int startY = page.GetScrollY();

            // Act
            page.ScrollToBottom();
            int endY = page.GetScrollY();

            // Assert
            Assert.That(endY, Is.GreaterThan(startY), "ScrollY should increase after scrolling down.");
        }

        [Test]
        public void ScrollToTop_ShouldScrollUp()
        {
            // Arrange
            page.GotoPage();
            page.ScrollToBottom();
            int scrolledY = page.GetScrollY();

            // Act
            page.ScrollToTop();
            int topY = page.GetScrollY();

            // Assert
            Assert.That(topY, Is.LessThan(scrolledY), "ScrollY should decrease when scrolled up.");
            Assert.That(topY, Is.Zero, "ScrollY should be zero at the top of the page.");
        }
    }
}
