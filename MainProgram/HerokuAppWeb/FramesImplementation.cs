using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerokuOperations;
namespace HerokuAppWeb
{
    public class FramesImplementation : IFrames
    {
        private readonly IWebDriver _driver;
        public FramesImplementation(IWebDriver driver)
        {
            _driver = driver;
        }
        public void GoToPage()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        }
        public void ClickNestedFrames()
        {
            _driver.FindElement(By.LinkText("NestedFrames")).Click();
        }
        public void ClickIFrame()
        {
            _driver.FindElement(By.LinkText("iFrame")).Click();
        }

        public void GoToNestedFramesPage()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/nested_frames");
        }
        public string GetLeftFrameText()
        {
            _driver.SwitchTo().Frame("frame-top");
            _driver.SwitchTo().Frame("frame-left");
            string text = _driver.FindElement(By.TagName("body")).Text;
            _driver.SwitchTo().DefaultContent();
            return text;
        }

        public string GetMiddleFrameText()
        {
            _driver.SwitchTo().Frame("frame-top");
            _driver.SwitchTo().Frame("frame-middle");
            string text = _driver.FindElement(By.Id("content")).Text;
            _driver.SwitchTo().DefaultContent();
            return text;
        }

        public string GetRightFrameText()
        {
            _driver.SwitchTo().Frame("frame-top");
            _driver.SwitchTo().Frame("frame-right");
            string text = _driver.FindElement(By.TagName("body")).Text;
            _driver.SwitchTo().DefaultContent();
            return text;
        }

        public string GetBottomFrameText()
        {
            _driver.SwitchTo().Frame("frame-bottom");
            string text = _driver.FindElement(By.TagName("body")).Text;
            _driver.SwitchTo().DefaultContent();
            return text;
        }
        public void GoToIFramePage()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");
        }

        public void SwitchToIFrame()
        {
            _driver.SwitchTo().Frame("mce_0_ifr");
        }

        public void ClearEditor()
        {
            _driver.SwitchTo().Frame("mce_0_ifr");
            _driver.FindElement(By.Id("tinymce")).Clear();
            _driver.SwitchTo().DefaultContent();
        }

        public void EnterText(string text)
        {
            _driver.SwitchTo().Frame("mce_0_ifr");
            var editor = _driver.FindElement(By.Id("tinymce"));
            editor.Clear();
            editor.SendKeys(text);
            _driver.SwitchTo().DefaultContent();
        }

        public string GetEditorText()
        {
            _driver.SwitchTo().Frame("mce_0_ifr");
            string text = _driver.FindElement(By.Id("tinymce")).Text;
            _driver.SwitchTo().DefaultContent();
            return text;
        }

        public void SwitchToDefaultContent()
        {
            _driver.SwitchTo().DefaultContent();
        }
    }
}
