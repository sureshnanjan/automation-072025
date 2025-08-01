using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

namespace HerokuAppTests
{
    [TestFixture]
    public class HoverTest
    {
        private IWebDriver driver;
        private IHoverProfile hover;

        [SetUp]
        public void Setup()
        {
            // Arrange: Initialize WebDriver and navigate to the page
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");

            // Arrange: Initialize HoverImplementation with driver
            hover = new HoverImplementation(driver);
        }

        [Test]
        public void GetTitle_ShouldReturnCorrectTitle()
        {
            // Arrange - done in Setup()

            // Act
            var title = hover.GetTitle();

            // Assert
            Assert.That(title, Is.EqualTo("Hovers"));
        }

        [Test]
        public void Description_ShouldReturnNonEmptyText()
        {
            // Arrange - done in Setup()

            // Act
            var description = hover.Description();

            // Assert
            Assert.That(description, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void GetProfileCount_ShouldReturnThreeProfiles()
        {
            // Arrange - done in Setup()

            // Act
            var count = hover.GetProfileCount();

            // Assert
            Assert.That(count, Is.EqualTo(3));
        }

        [Test]
        public void HoverOverProfileImage_ShouldShowCaption()
        {
            // Arrange - done in Setup()
            int count = hover.GetProfileCount();

            for (int i = 0; i < count; i++)
            {
                // Act
                hover.HoverOverProfileImage(i);

                // Assert
                Assert.That(hover.IsProfileInfoDisplayed(i), Is.True, $"Caption for profile {i} should be displayed");
            }
        }

        [Test]
        public void GetProfileName_ShouldReturnCorrectName()
        {
            // Arrange - done in Setup()
            int count = hover.GetProfileCount();

            for (int i = 0; i < count; i++)
            {
                // Act
                string name = hover.GetProfileName(i);

                // Assert
                Assert.That(name, Does.StartWith("name: user"), $"Profile name at index {i} should start with 'name: user'");
            }
        }

        [Test]
        public void GetProfileLink_ShouldReturnUserLink()
        {
            // Arrange - done in Setup()
            int count = hover.GetProfileCount();

            for (int i = 0; i < count; i++)
            {
                // Act
                string link = hover.GetProfileLink(i);

                // Assert
                Assert.That(link, Does.Contain("/users/"), $"Profile link at index {i} should contain '/users/'");
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}

