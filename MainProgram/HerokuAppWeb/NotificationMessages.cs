/* --------------------------------------------------------------------------------------------------------------------
 <copyright file="NotificationMessage.cs" author="Jagadeeswar Reddy Arava">
 © 2025 Jagadeeswar Reddy Arava. All rights reserved.

 This file is part of the HerokuOperations project.
 It provides the implementation for the Notification Message interactions.
 Redistribution is allowed for educational or internal use only.
 </copyright>
 --------------*/

using HerokuOperations;
using OpenQA.Selenium;

namespace HerokuAppWeb
{
    /// <summary>
    /// Implementation of the INotificationMessagePage interface.
    /// Handles interactions with the Notification Message page using Selenium WebDriver.
    /// </summary>
    public class NotificationMessages : INotificationMessages
    {
        private readonly IWebDriver _driver;
        private readonly By _triggerLink = By.LinkText("Click here");
        private readonly By _notification = By.Id("flash");
        private readonly By _heading = By.TagName("h3");

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationMessagePage"/> class.
        /// </summary>
        /// <param name="driver">The Selenium WebDriver instance to use.</param>
        public NotificationMessages(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <inheritdoc/>
        public void ClickTriggerLink()
        {
            _driver.FindElement(_triggerLink).Click();
        }

        /// <inheritdoc/>
        public string GetNotificationMessage()
        {
            try
            {
                return _driver.FindElement(_notification).Text.Trim();
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }

        /// <inheritdoc/>
        public string GetPageHeading()
        {
            return _driver.FindElement(_heading).Text.Trim();
        }
    }
}
