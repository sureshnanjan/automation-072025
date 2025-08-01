using HerokuOperations.PageInterface;
using OpenQA.Selenium;

namespace HerokuAppWeb.PageObjects
{
    public class AddRemoveElementsPage : IAddRemoveElementsPage
    {
        private readonly IWebDriver driver;
        private readonly By addElementButton = By.XPath("//button[text()='Add Element']");
        private readonly By deleteButtons = By.ClassName("added-manually");

        // ✅ Constructor that takes an IWebDriver argument
        public AddRemoveElementsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickAddElementButton()
        {
            driver.FindElement(addElementButton).Click();
        }

        public void ClickDeleteButton()
        {
            var deleteBtns = driver.FindElements(deleteButtons);
            if (deleteBtns.Count > 0)
            {
                deleteBtns[0].Click();
            }
        }

        public bool IsDeleteButtonDisplayed()
        {
            return driver.FindElements(deleteButtons).Count > 0;
        }

        public int GetDeleteButtonCount()
        {
            return driver.FindElements(deleteButtons).Count;
        }
    }
}
