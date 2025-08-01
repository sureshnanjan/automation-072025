using HerokuAppWeb;
using HerokuOperations;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace HerokuAppScenarios;

public class ABTest
{
    private IWebDriver driver;

    private IABTest abTest;
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        abTest = new ABTestImplementation(driver);
    }

    [Test]
    public void GetTitle()
    {
        string title = abTest.GetTitle();
        Assert.That(title, Is.Not.Null, "Title should not be null");
        Assert.That(title, Is.Not.Empty, "Title should not be empty");
    }
    [Test]
    public void GetDescription()
    {
        string description = abTest.GetDescription();
        Assert.That(description, Is.Not.Null, "Description should not be null");
        Assert.That(description, Is.Not.Empty, "Description should not be empty");
    }
    [Test]
    public void DisableABTest()
    {
        abTest.DisableABTest();
        Assert.That(driver.Url, Does.Contain("show=no"));
    }
    [TearDown]
    public void TearDown()
    {
        driver.Quit();   // Close the browser and clean up resources
        driver.Dispose();
    }
}
