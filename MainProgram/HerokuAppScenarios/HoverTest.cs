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
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");

            hover = new HoverImplementation(driver);
        }

        [Test]
        public void GetTitle_ShouldReturnCorrectTitle()
        {
            // Asserts that the page title is "Hovers"
            Assert.That(hover.GetTitle(), Is.EqualTo("Hovers"));
        }

        [Test]
        public void Description_ShouldReturnNonEmptyText()
        {
            // Asserts that the page description is not null or empty
            Assert.That(hover.Description(), Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void GetProfileCount_ShouldReturnThreeProfiles()
        {
            // Asserts that there are 3 profile figures on the page
            Assert.That(hover.GetProfileCount(), Is.EqualTo(3));
        }

        [Test]
        public void HoverOverProfileImage_ShouldShowCaption()
        {
            // Hovers over each profile and checks if caption becomes visible
            int count = hover.GetProfileCount();
            for (int i = 0; i < count; i++)
            {
                hover.HoverOverProfileImage(i);
                Assert.That(hover.IsProfileInfoDisplayed(i), Is.True, $"Caption for profile {i} should be displayed");
            }
        }

        [Test]
        public void GetProfileName_ShouldReturnCorrectName()
        {
            // After hover, the profile name should start with "name: user"
            int count = hover.GetProfileCount();
            for (int i = 0; i < count; i++)
            {
                string name = hover.GetProfileName(i);
                Assert.That(name, Does.StartWith("name: user"), $"Profile name at index {i} should start with 'name: user'");
            }
        }

        [Test]
        public void GetProfileLink_ShouldReturnUserLink()
        {
            // After hover, the profile link should contain "/users/"
            int count = hover.GetProfileCount();
            for (int i = 0; i < count; i++)
            {
                string link = hover.GetProfileLink(i);
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
