using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;
using HerokuAppWeb;

namespace HerokuAppScenarios
{
    public class NestedFramesScenarios
    {
        private IWebDriver _driver;
        private INestedFrames _nestedFrames;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _nestedFrames = new NestedFramesImplementation(_driver);
            _nestedFrames.GoToPage();
        }

        [Test]
        public void LeftFrame_Should_Display_Left_Text()
        {
            string leftText = _nestedFrames.GetLeftFrameText();
            Assert.AreEqual("LEFT", leftText.Trim());
        }

        [Test]
        public void MiddleFrame_Should_Display_Middle_Text()
        {
            string middleText = _nestedFrames.GetMiddleFrameText();
            Assert.AreEqual("MIDDLE", middleText.Trim());
        }

        [Test]
        public void RightFrame_Should_Display_Right_Text()
        {
            string rightText = _nestedFrames.GetRightFrameText();
            Assert.AreEqual("RIGHT", rightText.Trim());
        }

        [Test]
        public void BottomFrame_Should_Display_Bottom_Text()
        {
            string bottomText = _nestedFrames.GetBottomFrameText();
            Assert.AreEqual("BOTTOM", bottomText.Trim());
        }

        [TearDown]
        public void TearDown()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
            }
        }
    }
}
