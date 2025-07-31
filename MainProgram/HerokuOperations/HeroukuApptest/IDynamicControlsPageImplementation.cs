using OpenQA.Selenium;

namespace HerokuOperations
{
    public class DynamicControlsPage : IDynamicControlsPage
    {
        private readonly IWebDriver _driver;

        public DynamicControlsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ClickRemoveOrAddButton()
        {
            _driver.FindElement(By.CssSelector("#checkbox-example button")).Click();
        }

        public bool IsCheckboxDisplayed()
        {
            try
            {
                return _driver.FindElement(By.Id("checkbox")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public string GetCheckboxMessage()
        {
            return _driver.FindElement(By.Id("message")).Text;
        }

        public void ClickEnableOrDisableButton()
        {
            _driver.FindElement(By.CssSelector("#input-example button")).Click();
        }

        public bool IsInputEnabled()
        {
            return _driver.FindElement(By.CssSelector("#input-example input")).Enabled;
        }

        public string GetInputMessage()
        {
            return _driver.FindElement(By.Id("message")).Text;
        }

        public void EnterText(string text)
        {
            var inputField = _driver.FindElement(By.CssSelector("#input-example input"));
            inputField.Clear();
            inputField.SendKeys(text);
        }
    }
}

// Ensure this instantiation is moved to a method or a proper context
// Example:
public class TestClass
{
    public void TestMethod(IWebDriver driver)
    {
        var page = new DynamicControlsPage(driver);
        // Use the page object here
    }
}