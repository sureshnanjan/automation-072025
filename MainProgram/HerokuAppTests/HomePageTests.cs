<<<<<<< HEAD
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
=======
﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
>>>>>>> 10e667814f0e67d7065ec9e42fceb6d191319c20
namespace HerokuAppTests
{
    [TestClass]
    public sealed class HomePageTests
    {
<<<<<<< HEAD
=======
        [TestInitialize]
        public void Init() {
            // Read from app.config
            //AppContext appContext = Confi
           
        }
>>>>>>> 10e667814f0e67d7065ec9e42fceb6d191319c20
        [TestMethod]
        public void TitleisOK()
        {
            // Arrange
<<<<<<< HEAD
            var expectedTitle = "Welcome to the-internet";
            // Launch the browser and navigae to 
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
=======
            var expectedTitle = "Welcome to the-internet1";
            // Launch the browser and navigae to 
            ISearchContext driver = new ChromeDriver();
            driver = new FirefoxDriver();
            ((IWebDriver)driver).Navigate().GoToUrl("https://the-internet.herokuapp.com/");
>>>>>>> 10e667814f0e67d7065ec9e42fceb6d191319c20
            IWebElement pageheading = driver.FindElement(By.TagName("h1"));
            // 
            // Act
            var actualTitle = pageheading.Text;
            // Assert
            Assert.AreEqual(expectedTitle, actualTitle);
        }
        [TestMethod]
        public void SubTitleisOK()
        {
<<<<<<< HEAD
		// Arrange
         var expectedSubTitle = "Available Examples";

        // Launch the browser and navigate to the URL
        ChromeDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

        // Find the subtitle element (h2)
        IWebElement subtitleElement = driver.FindElement(By.TagName("h2"));

        // Act
        var actualSubTitle = subtitleElement.Text;

        // Assert
        Assert.AreEqual(expectedSubTitle, actualSubTitle);

        // Cleanup
        driver.Quit();
=======
>>>>>>> 10e667814f0e67d7065ec9e42fceb6d191319c20
        }

        [TestMethod]
        public void ExamplesCountis44()
        {
<<<<<<< HEAD
		 // Arrange
    var expectedCount = 44;

    // Launch browser using 'using' to ensure cleanup
    using (ChromeDriver driver = new ChromeDriver())
    {
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");

        // The examples are inside the <ul> under <div id="content">
        var exampleLinks = driver.FindElements(By.CssSelector("#content ul li"));

        // Act
        int actualCount = exampleLinks.Count;

        // Assert
        Assert.AreEqual(expectedCount, actualCount);
    }
        }
    }
}
=======
        }
    }
}
>>>>>>> 10e667814f0e67d7065ec9e42fceb6d191319c20
