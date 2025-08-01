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
            // Start Chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Open the Hovers page
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");

            // Create an object for hover operations
            hover = new HoverImplementation(driver);
        }

        [Test]
        public void Title_ShouldBe_Hovers()
        {
            // Get the title from the page
            string title = hover.GetTitle();

            // Check if the title is "Hovers"
            Assert.That(title, Is.EqualTo("Hovers"));
        }

        [Test]
        public void Description_ShouldNotBeEmpty()
        {
            // Get the description text
            string description = hover.Description();

            // Check if it's not null or empty
            Assert.That(description, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void ShouldHave_ThreeProfileImages()
        {
            // Get the number of profile images
            int count = hover.GetProfileCount();

            // Check if there are 3 images
            Assert.That(count, Is.EqualTo(3));
        }

        [Test]
        public void Hover_ShouldShowCaptions()
        {
            int count = hover.GetProfileCount();

            for (int i = 0; i < count; i++)
            {
                // Hover over each profile image
                hover.HoverOverProfileImage(i);

                // Check if caption is visible
                Assert.That(hover.IsProfileInfoDisplayed(i), Is.True);
            }
        }

        [Test]
        public void Hover_ShouldShowCorrectUserNames()
        {
            int count = hover.GetProfileCount();

            for (int i = 0; i < count; i++)
            {
                // Get profile name after hover
                string name = hover.GetProfileName(i);

                // Check if name starts with "name: user"
                Assert.That(name, Does.StartWith("name: user"));
            }
        }

        [Test]
        public void Hover_ShouldShowValidProfileLinks()
        {
            int count = hover.GetProfileCount();

            for (int i = 0; i < count; i++)
            {
                // Get profile link after hover
                string link = hover.GetProfileLink(i);

                // Check if link contains "/users/"
                Assert.That(link, Does.Contain("/users/"));
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser and cleanup
            driver.Quit();
            driver.Dispose();
        }
    }
}
