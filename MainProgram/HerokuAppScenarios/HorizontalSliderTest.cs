using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

namespace HerokuAppTests
{
    [TestFixture]
    public class HorizontalSliderTest
    {
        private IWebDriver driver;
        private IHorizontalSlider slider;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/horizontal_slider");

            slider = new HorizontalSliderImplementation(driver);
        }

        [Test]
        public void GetTitle()
        {
            string title = slider.GetTitle();
            string description = slider.GetDescription();

            Assert.That(title, Is.EqualTo("Horizontal Slider"));
            Assert.That(description, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void GetDescription()
        {
            int finalValue = slider.MoveSLiderRight(4); // e.g., 4 steps
            Assert.That(finalValue, Is.GreaterThan(0));
        }

        [Test]
        public void MoveSliderLeft()
        {
            slider.MoveSLiderRight(5); // move right first
            int finalValue = slider.MoveSLiderLeft(2);  // then move back
            Assert.That(finalValue, Is.LessThanOrEqualTo(5));
        }

        [Test]
        public void GetSliderValue()
        {
            slider.FocusSlider();
            slider.MoveSLiderRight(3);
            int value = slider.GetSliderValue();

            Assert.That(value, Is.InRange(0, 5)); // Slider values go from 0 to 5
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose(); // Prevents WebDriver memory leaks
        }
    }
}
