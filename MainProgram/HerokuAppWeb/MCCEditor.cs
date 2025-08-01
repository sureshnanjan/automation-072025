using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HerokuOperations;

namespace HerokuAppWeb
{
    public class TinyMCEEditorPage : ITinyMCEEditorPage
    {
        private IWebDriver driver;

        private By iframeLocator;
        private By editorBodyLocator;

        public TinyMCEEditorPage()
        {
            this.driver = new ChromeDriver();
            this.iframeLocator = By.Id("mce_0_ifr");
            this.editorBodyLocator = By.Id("tinymce");
            this.driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tinymce");
        }

        public void SwitchToEditorFrame()
        {
            IWebElement iframe = this.driver.FindElement(this.iframeLocator);
            this.driver.SwitchTo().Frame(iframe);
        }

        public void SwitchToMainContent()
        {
            this.driver.SwitchTo().DefaultContent();
        }

        public void ClearEditorContent()
        {
            IWebElement editorBody = this.driver.FindElement(this.editorBodyLocator);
            editorBody.Clear();
        }

        public void EnterTextInEditor(string text)
        {
            IWebElement editorBody = this.driver.FindElement(this.editorBodyLocator);
            editorBody.Clear();
            editorBody.SendKeys(text);
        }

        public string GetEditorContent()
        {
            IWebElement editorBody = this.driver.FindElement(this.editorBodyLocator);
            return editorBody.Text;
        }
    }
}
