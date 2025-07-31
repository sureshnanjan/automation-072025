namespace HerokuOperations
{
    public interface IDropdownPage
    {
        string GetTitle();

<<<<<<< HEAD
namespace Dropdown
{
    // Parameters required for dropdown testing using Selenium
    public class DropdownHandler
    {
        private IWebDriver driver;          // Controls the browser instance (Chrome, Firefox, etc.)
        private WebDriverWait wait;         // Provides explicit wait functionality for specific elements or conditions
        private IWebElement dropdown;       // Represents the <select> HTML element on the page
        private SelectElement select;       // Wrapper around the <select> element to simplify dropdown interactions

        // Constructor to initialize the fields
        public DropdownHandler(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
=======
        string[] GetAllOptions();
        void SelectOptionByText(string optionText);
        string GetSelectedOption();
    }
}
>>>>>>> d14d35d6339ba6935c04c01ab128e5aede9c44f0
