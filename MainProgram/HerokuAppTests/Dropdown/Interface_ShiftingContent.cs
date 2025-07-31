using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace ShiftingContentTests
{
    [TestClass]
    public class ShiftingContentMainTest
    {
        private IWebDriver driver;
        private string baseUrl = "https://the-internet.herokuapp.com/shifting_content";

        [TestInitialize]
        public void Setup()
        {}

        [TestMethod]
        public void VerifyMainPageAndMenuShifting()
        { }
  

        [TestCleanup]
        public void TearDown()
        { }
        
    }
}
