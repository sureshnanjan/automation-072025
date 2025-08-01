using NUnit.Framework;
using HerokuOperations;

namespace HerokuAppScenarios
{
    public class ContextMenuTests
    {
        private SeleniumContextMenu contextMenu;

        [SetUp]
        public void SetUp()
        {
            contextMenu = new SeleniumContextMenu();
        }

        [Test]
        public void VerifyContextMenuAlert()
        {
            contextMenu.GoToPage();

            Assert.That(contextMenu.GetTitle(), Is.EqualTo("The Internet"));
            Assert.That(contextMenu.GetInformation(), Is.EqualTo("Context Menu"));

            contextMenu.RIghtClickOnBox();

            string alertText = contextMenu.GetAlertText();
            Assert.That(alertText, Is.EqualTo("You selected a context menu"));

            contextMenu.AcceptAlert();
        }

        [TearDown]
        public void TearDown()
        {
            contextMenu.Close();
        }
    }
}
