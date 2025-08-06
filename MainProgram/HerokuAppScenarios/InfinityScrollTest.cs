// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputPageTest.cs" company="K Vamsi Krishna">
//   Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
// </copyright>
// <summary>
//   NUnit test cases for validating the Inputs page behavior at https://the-internet.herokuapp.com.
//   Tests follow the AAA (Arrange, Act, Assert) format and use mocked interface interactions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace HerokuAppScenarios
{
    [TestFixture]
    public class InfiniteScrollTests
    {


        [SetUp]
        public void SetUp()
        {

        }
        /*
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        */
        // ───────────── BASIC UI VALIDATION ─────────────

        [Test]
        public void PageTitle_ShouldBeCorrect()
        {
            // Arrange
            string expected = "The Internet";

            // Act
            string actual = driver.Title;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PageHeader_ShouldBeInfiniteScroll()
        {
            // Arrange
            string expected = "Infinite Scroll";

            // Act
            string actual = driver.FindElement(By.TagName("h3")).Text;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // ───────────── SCROLLING TESTS ─────────────

        [Test]
        public void ShouldLoadMoreParagraphs_OnScroll()
        {
            // Arrange
            int beforeScroll = driver.FindElements(By.ClassName("jscroll-added")).Count;

            // Act
            ScrollToBottom();
            Thread.Sleep(2000); // wait for content load
            int afterScroll = driver.FindElements(By.ClassName("jscroll-added")).Count;

            // Assert
            Assert.That(afterScroll, Is.GreaterThan(beforeScroll));
        }

        [Test]
        public void InitialParagraphs_ShouldBeAtLeastTwo()
        {
            // Act
            int count = driver.FindElements(By.ClassName("jscroll-added")).Count;

            // Assert
            Assert.GreaterOrEqual(count, 2);
        }

        // ───────────── FOOTER TESTS ─────────────

        [Test]
        public void Footer_ShouldContainPoweredByElementalSelenium()
        {
            // Arrange
            string expected = "Powered by Elemental Selenium";

            // Act
            string footerText = driver.FindElement(By.Id("page-footer")).Text;

            // Assert
            StringAssert.Contains(expected, footerText);
        }

        [Test]
        public void GitHubRibbon_ShouldBeVisible()
        {
            // Arrange
            string expected = "Fork me on GitHub";

            // Act
            string ribbonText = driver.FindElement(By.CssSelector("a[href*='github.com']")).Text;

            // Assert
            Assert.AreEqual(expected, ribbonText);
        }

        // ───────────── HELPER ─────────────

        private void ScrollToBottom()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }
    }
}
