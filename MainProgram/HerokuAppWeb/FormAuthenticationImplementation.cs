using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerokuOperations;
namespace HerokuAppWeb
{
    public class FormAuthenticationImplementation : IFormAuthentication
    {
        private readonly IWebDriver _driver;
        public FormAuthenticationImplementation(IWebDriver driver)
        {
            _driver = driver;
        }
        public void GoToPage()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        }
        public void EnterUserName(string UserName)
        {
            _driver.FindElement(By.Id(UserName)).Clear();
            _driver.FindElement(By.Id(UserName)).SendKeys(UserName);
        }
        public void EnterPassWord(string PassWord)
        {
            _driver.FindElement(By.Id(PassWord)).Clear();
            _driver.FindElement(By.Id(PassWord)).SendKeys(PassWord);
        }
        public void ClickLogin()
        {
            _driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        }
        public string GetTitle()
        {
            return _driver.FindElement(By.TagName("h2")).Text;
        }
        public string GetDescription()
        {
            return _driver.FindElement(By.ClassName("subheader")).Text;
        } 
        public string GetErrorMessage()
        {
            return _driver.FindElement(By.Id("flash")).Text;
        }
        public void ClickLogout()
        {
            _driver.FindElement(By.CssSelector(".icon-2x.icon-signout")).Click();
        }
        public bool IsLoginSuccessful()
        {
            try
            {
                return _driver.Url.Contains("/secure");
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }

    }
}
