using NUnit.Framework;
using HerokuAppWeb;
using HerokuOperations;

namespace HerokuAppScenarios
{
    public class WindowTest
    {
        private IWindowPage page;

        [SetUp]
        public void Setup()
        {
            // Create object for WindowPage implementation
            page = new WindowPage();
            page.GotoPage(); // Open the target URL
        }

        [Test]
        public void GetTitle_ShouldReturnCorrectText()
        {
            // Act
            string title = page.GetTitle();

            // Assert
            Assert.That(title, Is.EqualTo("Opening a new window"));
        }

        [Test]
        public void ClickingLink_ShouldOpenNewWindow()
        {
            // Act
            page.ClickHereLink();         // Click the "Click Here" link
            page.SwitchToNewWindow();     // Switch to the new window
            string text = page.GetNewWindowText();

            // Assert
            Assert.That(text, Is.EqualTo("New Window"));

            page.SwitchToMainWindow();    // Return back to the original window
        }

        [TearDown]
        public void TearDown()
        {
            // Optionally close driver in actual implementation
            ((WindowPage)page).Close();  // Cast to access Close() if needed
        }
    }
}
