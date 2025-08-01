// --------------------------------------------------------------------------------------------------
// © 2025 Teja Reddy. All rights reserved.
// This file is part of the HerokuApp automated test suite.
// Unauthorized copying of this file, via any medium is strictly prohibited.
// Proprietary and confidential.
// --------------------------------------------------------------------------------------------------

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

namespace HerokuAppScenarios
{
    /// <summary>
    /// Contains NUnit test cases for validating the functionality of the 
    /// Horizontal Slider page on the HerokuApp website.
    /// URL: https://the-internet.herokuapp.com/horizontal_slider
    /// </summary>
    [TestFixture]
    public class SliderTests
    {
        private IHorizontalSlider _slider;

        /// <summary>
        /// Initializes a fresh instance of the HorizontalSliderPage before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _slider = new HorizontalSliderPage();
        }

        /// <summary>
        /// Test Case: Verify that the page title is correctly displayed as "Horizontal Slider".
        /// </summary>
        [Test]
        public void Title_Check()
        {
            Assert.AreEqual("Horizontal Slider", _slider.GetTitle());
        }

        /// <summary>
        /// Test Case: Verify that the slider instruction text is displayed correctly below the title.
        /// </summary>
        [Test]
        public void Desc_Check()
        {
            string expected = "Set the focus on the slider (click and hold) and use the arrow keys to move left/right.";
            Assert.AreEqual(expected, _slider.GetDescription());
        }

        /// <summary>
        /// Test Case: Verify that the default value of the slider on page load is 0.
        /// </summary>
        [Test]
        public void Default_Val()
        {
            Assert.AreEqual("0", _slider.GetValue());
        }

        /// <summary>
        /// Test Case: Move the slider from 0 to 5.0 and validate the value is updated accordingly.
        /// </summary>
        [Test]
        public void Move_0_To_5()
        {
            _slider.MoveTo(5.0);
            Assert.AreEqual("5", _slider.GetValue());
        }

        /// <summary>
        /// Test Case: Move the slider to 5.0 and then back to 0.0, verifying each step.
        /// </summary>
        [Test]
        public void Move_5_To_0()
        {
            _slider.MoveTo(5.0);
            _slider.MoveTo(0.0);
            Assert.AreEqual("0", _slider.GetValue());
        }

        /// <summary>
        /// Test Case: Move the slider to 2.5 and verify the decimal value is supported and accurate.
        /// </summary>
        [Test]
        public void Move_2Point5()
        {
            _slider.MoveTo(2.5);
            Assert.AreEqual("2.5", _slider.GetValue());
        }
        /// <summary>
        /// Verifies that the "Powered by Elemental Selenium" footer is visible.
        /// </summary>
        [Test]
        public void Footer_PoweredBy_IsVisible()
        {
            Assert.IsTrue(_hoversPage.IsFooterPoweredByVisible());
        }

        /// <summary>
        /// Verifies that the "Fork me on GitHub" ribbon is visible and interactable.
        /// </summary>
        [Test]
        public void GitHubRibbon_IsVisible()
        {
            Assert.IsTrue(_hoversPage.IsGitHubRibbonVisible());
        }
    }
}
