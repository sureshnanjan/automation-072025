using HerokuAppWeb;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HerokuAppTests
{
    [TestFixture]
    public class TinyMCEEditorTests
    {
        private TinyMCEEditorPage _editorPage;

        [SetUp]
        public void SetUp()
        {
            _editorPage = new TinyMCEEditorPage();
            _editorPage.SwitchToEditorFrame();
        }

        [TearDown]
        public void TearDown()
        {
            _editorPage.SwitchToMainContent();
            // Since ChromeDriver is initialized inside TinyMCEEditorPage,
            // we dispose it using reflection or explicitly expose Dispose method if needed.
            // But in this example, we let the process kill handle it on exit.
        }

        [Test]
        public void EnterTextInEditor_ShouldDisplayCorrectText()
        {
            // Arrange
            string testText = "Hello from TinyMCE!";

            // Act
            _editorPage.ClearEditorContent();
            _editorPage.EnterTextInEditor(testText);
            string actualText = _editorPage.GetEditorContent();

            // Assert
            Assert.AreEqual(testText, actualText, "Editor text does not match input.");
        }

        [Test]
        public void ClearEditorContent_ShouldEmptyEditor()
        {
            // Arrange
            _editorPage.EnterTextInEditor("Some text to clear");

            // Act
            _editorPage.ClearEditorContent();
            string clearedText = _editorPage.GetEditorContent();

            // Assert
            Assert.IsEmpty(clearedText, "Editor should be empty after clearing.");
        }
    }
}
