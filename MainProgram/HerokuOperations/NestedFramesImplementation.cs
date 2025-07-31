using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public class NestedFramesImplementation : INestedFrames
    {
        private readonly IWebDriver web_driver;
        public NestedFramesImplementation(IWebDriver driver)
        {
            web_driver = driver;
        }
        public void GoToPage()
        {
            web_driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        }
        public string GetLeftFrameText()
        {
            web_driver.SwitchTo().Frame("frame-top");         // Switch to outer top frame
            web_driver.SwitchTo().Frame("frame-left");        // Then switch to inner left frame
            string text = web_driver.FindElement(By.TagName("body")).Text; // Get text inside body tag
            web_driver.SwitchTo().DefaultContent();           // Return to main (default) content
            return text;
        }
        // Retrieves text from the middle frame inside the top frame
        public string GetMiddleFrameText()
        {
            web_driver.SwitchTo().Frame("frame-top");         // Switch to outer top frame
            web_driver.SwitchTo().Frame("frame-middle");      // Then switch to inner middle frame
            string text = web_driver.FindElement(By.Id("content")).Text; // Middle frame has an element with id 'content'
            web_driver.SwitchTo().DefaultContent();           // Return to main content
            return text;
        }

        // Retrieves text from the right frame inside the top frame
        public string GetRightFrameText()
        {
            web_driver.SwitchTo().Frame("frame-top");         // Switch to top frame
            web_driver.SwitchTo().Frame("frame-right");       // Then to right frame
            string text = web_driver.FindElement(By.TagName("body")).Text; // Get text in body
            web_driver.SwitchTo().DefaultContent();           // Reset context
            return text;
        }

        // Retrieves text from the bottom frame (not inside frame-top)
        public string GetBottomFrameText()
        {
            web_driver.SwitchTo().Frame("frame-bottom");      // Switch directly to bottom frame
            string text = web_driver.FindElement(By.TagName("body")).Text; // Get text in body
            web_driver.SwitchTo().DefaultContent();           // Return to main document
            return text;
        }
    }
}

