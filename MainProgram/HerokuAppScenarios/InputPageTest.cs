using NUnit.Framework;
using HerokuAppWeb;
using HerokuOperations;

namespace HerokuAppScenarios
{
    public class InputPageTest
    {
        private IInputPage page;

        [SetUp]
        public void Setup()
        {
            // Create object for Inputs page
            this.page = new InputPage();
        }

        [Test]
        public void EnterNumber_ShouldSetInputValue()
        {
            // Act
            page.EnterNumber("123");

            // Assert
            Assert.That(page.GetInputValue(), Is.EqualTo("123"));
        }

        [Test]
        public void IncreaseValue_ShouldIncreaseTheNumber()
        {
            page.EnterNumber("10");
            page.IncreaseValue(2);

            string result = page.GetInputValue();
            Assert.That(int.Parse(result), Is.GreaterThan(10));
        }

        [Test]
        public void DecreaseValue_ShouldDecreaseTheNumber()
        {
            page.EnterNumber("10");
            page.DecreaseValue(3);

            string result = page.GetInputValue();
            Assert.That(int.Parse(result), Is.LessThan(10));
        }
    }
}
