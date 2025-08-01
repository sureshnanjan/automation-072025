using OpenQA.Selenium;
using System;
using System.Threading;

namespace HerokuOperations
{
    public class Infinity : IInfinity
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "https://the-internet.herokuapp.com/infinite_scroll";

        public Infinity(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GotoPage()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public int GetScrollY()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            return Convert.ToInt32(js.ExecuteScript("return window.scrollY;"));
        }

        public void ScrollToBottom()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            Thread.Sleep(2000); // Allow content to load
        }

        public void ScrollToTop()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 0);");
            Thread.Sleep(1000); // Allow scroll animation
        }
    }
}
