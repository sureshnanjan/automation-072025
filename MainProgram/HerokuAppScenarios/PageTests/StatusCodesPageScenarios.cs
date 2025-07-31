using HerokuOperations.PageClassApps;
using HerokuOperations.PageInterfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

public class StatusCodesPageScenarios
{
    private IWebDriver driver; // More specific type

    private IStatusCodes statusCodesPage;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless"); // Optional: run in headless mode
        options.AddArgument("--disable-gpu"); // Optional: helpful for CI pipelines
        driver = new ChromeDriver(options); // Use options for stability
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/status_codes");
        statusCodesPage = new StatusCodesClassApp(driver);
    }

    [Test]
    public void ClickStatusCode_200_ReturnsCorrectMessage()
    {
        statusCodesPage.ClickStatusCode("200");
        string message = statusCodesPage.GetStatusMessage();
        Assert.AreEqual("This page returned a 200 status code.", message);
    }

    public void ClickStatusCode_301_ReturnsCorrectMessage()
    {
        statusCodesPage.ClickStatusCode("301");
        string message = statusCodesPage.GetStatusMessage();
        Assert.AreEqual("This page returned a 301 status code.", message);
    }

    public void ClickStatusCode_404_ReturnsCorrectMessage()
    {
        statusCodesPage.ClickStatusCode("404");
        string message = statusCodesPage.GetStatusMessage();
        Assert.AreEqual("This page returned a 404 status code.", message);
    }
}
