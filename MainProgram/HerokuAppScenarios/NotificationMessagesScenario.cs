using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using HerokuAppWeb;

namespace HerokuAppScenarios
{
    [TestFixture]
    public class NotificationMessagesScenarios

    {
        private IWebDriver _driver;
        private INotificationMessages _notificationMessages;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/notification_message_rendered");
            _notificationMessages = new NotificationMessages(_driver); // Assuming class name is NotificationMessages
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void TestNotificationMessage_IsDisplayed()
        {
            string message = _notificationMessages.GetNotificationMessage();
            Assert.IsNotNull(message);
            Assert.IsNotEmpty(message);
        }

        [Test]
        public void TestPageHeading_IsCorrect()
        {
            string heading = _notificationMessages.GetHeading();
            Assert.AreEqual("Notification Message", heading);
        }

        [Test]
        public void TestClickHereLink_LoadsNewMessage()
        {
            string messageBefore = _notificationMessages.GetNotificationMessage();
            _notificationMessages.ClickLoadNewMessageLink();

            // Allow time for the page to reload
            System.Threading.Thread.Sleep(1000);

            string messageAfter = _notificationMessages.GetNotificationMessage();
            Assert.AreNotEqual(messageBefore, messageAfter);
        }

        [Test]
        public void TestClickHereLinkHref_IsValid()
        {
            string href = _notificationMessages.GetLinkHref();
            Assert.IsTrue(href.Contains("notification_message"));
        }
    }
}
