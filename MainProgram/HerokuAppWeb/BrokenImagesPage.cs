﻿// -------------------------------------------------------------------------------------------------
// © 2025 Elangovan. All rights reserved.
//
// This file is part of the HerokuApp Automation Framework.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Proprietary and confidential.
//
// This class provides the implementation for the IBrokenImages interface,
// enabling interaction with the HerokuApp Broken Images page.
// -------------------------------------------------------------------------------------------------

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace HerokuOperations
{
    /// <summary>
    /// Simple implementation of the <see cref="IBrokenImages"/> interface for the HerokuApp Broken Images page.
    /// </summary>
    public class BrokenImagesPage : IBrokenImages
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://the-internet.herokuapp.com/broken_images";

        /// <summary>
        /// Initializes a new instance of the <see cref="BrokenImagesPage"/> class.
        /// </summary>
        public BrokenImagesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Navigates to the Broken Images page.
        /// </summary>
        public void NavigateToPage()
        {
            _driver.Navigate().GoToUrl(_url);
            WaitForImagesToLoad();
        }

        /// <summary>
        /// Gets the title of the Broken Images page.
        /// </summary>
        public string GetPageTitle()
        {
            return _driver.Title;
        }

        /// <summary>
        /// Gets the total number of images on the page.
        /// </summary>
        public int GetImageCount()
        {
            return _driver.FindElements(By.TagName("img")).Count;
        }

        /// <summary>
        /// Gets the count of broken images.
        /// </summary>
        public int GetBrokenImageCount()
        {
            return GetBrokenImageUrls().Count;
        }

        /// <summary>
        /// Gets the URLs of broken images.
        /// </summary>
        public List<string> GetBrokenImageUrls()
        {
            var images = _driver.FindElements(By.TagName("img"));
            var brokenUrls = new List<string>();

            foreach (var img in images)
            {
                var naturalWidth = (long)((IJavaScriptExecutor)_driver).ExecuteScript("return arguments[0].naturalWidth;", img);

                if (naturalWidth == 0)
                {
                    brokenUrls.Add(img.GetAttribute("src"));
                }
            }
            return brokenUrls;
        }

        /// <summary>
        /// Gets the count of valid (working) images.
        /// </summary>
        public int GetValidImageCount()
        {
            return GetImageCount() - GetBrokenImageCount();
        }

        /// <summary>
        /// Determines whether all images are valid.
        /// </summary>
        public bool AreAllImagesValid()
        {
            return GetBrokenImageCount() == 0;
        }

        /// <summary>
        /// Waits for the images on the page to load. (Simplified: uses Thread.Sleep)
        /// </summary>
        public void WaitForImagesToLoad()
        {
            Thread.Sleep(2000); // Wait for 2 seconds
        }

        /// <summary>
        /// Refreshes the Broken Images page.
        /// </summary>
        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
        }

        /// <summary>
        /// Gets the alt text of all broken images.
        /// </summary>
        public List<string> GetAltTextOfBrokenImages()
        {
            var images = _driver.FindElements(By.TagName("img"));
            var brokenAltTexts = new List<string>();

            foreach (var img in images)
            {
                var naturalWidth = (long)((IJavaScriptExecutor)_driver)
                    .ExecuteScript("return arguments[0].naturalWidth;", img);

                if (naturalWidth == 0)
                {
                    brokenAltTexts.Add(img.GetAttribute("alt"));
                }
            }
            return brokenAltTexts;
        }

        /// <summary>
        /// Determines whether the "Powered by Elemental Selenium" footer is visible.
        /// </summary>
        public bool IsFooterPoweredByVisible()
        {
            return _driver.FindElement(By.CssSelector("#page-footer a")).Displayed;
        }

        /// <summary>
        /// Determines whether the GitHub ribbon is visible on the page.
        /// </summary>
        public bool IsGitHubRibbonVisible()
        {
            return _driver.FindElement(By.CssSelector(".github-fork-ribbon")).Displayed;
        }
    }
}
