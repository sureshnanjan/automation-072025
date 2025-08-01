using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using HerokuAppWeb;
// Assuming IFloatingMenu is implemented by class `FloatingMenu`

namespace HerokuAppScenarios
{
    [TestFixture]
    public class FloatingMenuTests
    {
        private IWebDriver driver;
        private IFloatingMenu floatingMenu;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/floating_menu");
            driver.Manage().Window.Maximize();
            floatingMenu = new FloatingMenu(driver); // Assuming this class implements IFloatingMenu
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose(); // Recommended
            }
        }


        [Test]
        public void Menu_Should_Be_Visible()
        {
            Assert.IsTrue(floatingMenu.IsMenuVisible(), "Floating menu should be visible on page load.");
        }

        [Test]
        public void Click_Home_Link_Should_Not_Throw_Exception()
        {
            Assert.DoesNotThrow(() => floatingMenu.ClickHome(), "Clicking Home should not throw any exception.");
        }

        [Test]
        public void Click_News_Link_Should_Not_Throw_Exception()
        {
            Assert.DoesNotThrow(() => floatingMenu.ClickNews(), "Clicking News should not throw any exception.");
        }

        [Test]
        public void Click_Contact_Link_Should_Not_Throw_Exception()
        {
            Assert.DoesNotThrow(() => floatingMenu.ClickContact(), "Clicking Contact should not throw any exception.");
        }

        [Test]
        public void Click_About_Link_Should_Not_Throw_Exception()
        {
            Assert.DoesNotThrow(() => floatingMenu.ClickAbout(), "Clicking About should not throw any exception.");
        }

        [Test]
        public void Menu_Should_Remain_Visible_After_Scrolling()
        {
            floatingMenu.ScrollToBottom();
            Assert.IsTrue(floatingMenu.IsMenuVisible(), "Floating menu should still be visible after scrolling.");
        }

        [Test]
        public void Menu_Y_Position_Should_Not_Change_After_Scrolling()
        {
            int yBeforeScroll = floatingMenu.GetMenuYPosition();
            floatingMenu.ScrollToBottom();
            int yAfterScroll = floatingMenu.GetMenuYPosition();
            Assert.AreEqual(yBeforeScroll, yAfterScroll, "Y position of menu should remain the same (fixed menu).");
        }
    }
}
