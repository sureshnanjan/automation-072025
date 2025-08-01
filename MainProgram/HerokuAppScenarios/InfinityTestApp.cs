using NUnit.Framework;
using HerokuOperations; // Interface namespace     
namespace HerokuAppScenarios
{
    [TestFixture]
    public class InfiniteScrollTests
    {
        private IinfiniteScroll page;

        // This runs before each test
        [SetUp]
        public void Setup()
        {
            // Create a new instance of the page class
            page = new InfiniteScrollPage(); // Replace with your actual class
            page.GotoPage(); // Open the infinite scroll page
        }

        // Test the title of the page
        [Test]
        public void GetTitle_ShouldReturnCorrectTitle()
        {
            // Act
            string title = page.GetTitle();

            // Assert
            Assert.IsNotNull(title, "Title should not be null");
            Assert.IsNotEmpty(title, "Title should not be empty");
        }

        // Test the subtitle of the page
        [Test]
        public void GetSubTitle_ShouldReturnCorrectSubtitle()
        {
            string subTitle = page.GetSubTitle();

            Assert.IsNotNull(subTitle, "Subtitle should not be null");
            Assert.IsNotEmpty(subTitle, "Subtitle should not be empty");
        }

        // Test if scrolling to bottom increases vertical scroll
        [Test]
        public void ScrollToBottom_ShouldIncreaseScrollY()
        {
            // Arrange
            int startY = page.GetScrollY(); // Get scroll position before

            // Act
            page.ScrollToBottom(); // Scroll down

            // Assert
            int endY = page.GetScrollY(); // Get scroll position after
            Assert.Greater(endY, startY, "ScrollY should increase after scrolling to bottom");
        }

        // Test if scrolling to top resets scrollY to zero
        [Test]
        public void ScrollToTop_ShouldResetScrollY()
        {
            page.ScrollToBottom(); // First scroll down
            page.ScrollToTop();    // Then scroll to top

            int scrollY = page.GetScrollY();
            Assert.AreEqual(0, scrollY, "ScrollY should be 0 after scrolling to top");
        }

        // Test if scrolling to right increases horizontal scroll
        [Test]
        public void ScrollToRight_ShouldIncreaseScrollX()
        {
            int startX = page.GetScrollX();

            page.ScrollToRight();

            int endX = page.GetScrollX();
            Assert.Greater(endX, startX, "ScrollX should increase after scrolling to right");
        }

        // Test if scrolling to left resets scrollX to 0
        [Test]
        public void ScrollToLeft_ShouldResetScrollX()
        {
            page.ScrollToRight(); // First scroll right
            page.ScrollToLeft();  // Then scroll left

            int scrollX = page.GetScrollX();
            Assert.AreEqual(0, scrollX, "ScrollX should be 0 after scrolling to left");
        }

        // Test scroll to a specific (x, y) point
        [Test]
        public void ScrollTo_SpecificXY_ShouldScrollExactly()
        {
            // Arrange
            int targetX = 100;
            int targetY = 200;

            // Act
            page.ScrollTo(targetX, targetY);

            // Assert
            int actualX = page.GetScrollX();
            int actualY = page.GetScrollY();

            Assert.AreEqual(targetX, actualX, "Should scroll to X=100");
            Assert.AreEqual(targetY, actualY, "Should scroll to Y=200");
        }

        // Test if height and width values are positive
        [Test]
        public void ScrollHeight_And_Width_ShouldBePositive()
        {
            int height = page.GetScrollHeight();
            int width = page.GetScrollWidth();

            Assert.Greater(height, 0, "Scroll height should be greater than 0");
            Assert.Greater(width, 0, "Scroll width should be greater than 0");
        }

        // This runs after each test
        [TearDown]
        public void Teardown()
        {
            // Dispose the object or close browser if needed
            if (page is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
