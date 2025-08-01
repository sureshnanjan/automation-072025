// --------------------------------------------------------------------------------------
// Copyright (c) 2025 Arpita Neogi
// Date: August 1, 2025
//
// Licensed under the MIT License.
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// --------------------------------------------------------------------------------------
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace HerokuOperations
{
    /// <summary>
    /// Implementation of IBrokenImagesPage interface for interacting with the Broken Images test page
    /// on https://the-internet.herokuapp.com/broken_images
    /// </summary>
    public class BrokenImagesPage : IBrokenImagesPage
    {
        private readonly IWebDriver _driver;
        private readonly string _baseUrl = "https://the-internet.herokuapp.com/broken_images";

        /// <summary>
        /// Constructor to initialize WebDriver instance.
        /// </summary>
        /// <param name="driver">Selenium WebDriver instance</param>
        public BrokenImagesPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        /// <summary>
        /// Navigates to the Broken Images page.
        /// </summary>
        public void NavigateToPage()
        {
            _driver.Navigate().GoToUrl(_baseUrl);
        }

        /// <summary>
        /// Gets the page title after successful navigation.
        /// </summary>
        /// <returns>Page title as string.</returns>
        public string GetPageTitle()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.TagName("h3")));
            return _driver.FindElement(By.TagName("h3")).Text;
        }

        /// <summary>
        /// Gets the total number of images on the page.
        /// </summary>
        /// <returns>Total image count as integer.</returns>
        public int GetImageCount()
        {
            var images = _driver.FindElements(By.TagName("img"));
            return images.Count;
        }

        /// <summary>
        /// Returns the number of broken images on the page.
        /// An image is considered broken if its naturalWidth property is 0.
        /// </summary>
        /// <returns>Number of broken images.</returns>
        public int GetBrokenImageCount()
        {
            var images = _driver.FindElements(By.TagName("img"));
            int brokenCount = 0;

            foreach (var img in images)
            {
                bool isBroken = (bool)((IJavaScriptExecutor)_driver)
                    .ExecuteScript("return arguments[0].naturalWidth == 0;", img);

                if (isBroken)
                    brokenCount++;
            }

            return brokenCount;
        }

        /// <summary>
        /// Returns a list of URLs for images that failed to load.
        /// </summary>
        /// <returns>List of broken image source URLs.</returns>
        public List<string> GetBrokenImageUrls()
        {
            var images = _driver.FindElements(By.TagName("img"));
            List<string> brokenUrls = new List<string>();

            foreach (var img in images)
            {
                bool isBroken = (bool)((IJavaScriptExecutor)_driver)
                    .ExecuteScript("return arguments[0].naturalWidth == 0;", img);

                if (isBroken)
                {
                    string src = img.GetAttribute("src");
                    brokenUrls.Add(src);
                }
            }

            return brokenUrls;
        }
    }
}
