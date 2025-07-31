using HerokuOperations.PageClassApps;
using HerokuOperations.PageInterfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace HerokuAppScenarios.PageTests;

public class ChallengingDOMPageScenarios
{
    private ChromeDriver driver; // More specific type
    private IChallengingDOM challengingDOMPage;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless"); // Optional: run in headless mode
        options.AddArgument("--disable-gpu"); // Optional: helpful for CI pipelines

        driver = new ChromeDriver(options); // Use options for stability
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/challenging_dom");

        challengingDOMPage = new ChallengingDOMClassApp(driver);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose(); // Properly dispose to clean up resources
    }

    [Test]
    public void PageTitleAndDescription_AreCorrect()
    {
        string title = challengingDOMPage.GetPageTitle();
        string description = challengingDOMPage.GetDescriptionText();

        Assert.AreEqual("Challenging DOM", title);
        Assert.IsTrue(description.Contains("The hardest part in automated web testing is finding the best locators (e.g., ones that well named, unique, and unlikely to change). It's more often than not that the application you're testing was not built with this concept in mind. This example demonstrates that with unique IDs, a table with no helpful locators, and a canvas element."));
    }

    [Test]
    public void ClickButtons_NoExceptionThrown()
    {
        Assert.DoesNotThrow(() => challengingDOMPage.ClickBlueButton());
        Assert.DoesNotThrow(() => challengingDOMPage.ClickRedButton());
        Assert.DoesNotThrow(() => challengingDOMPage.ClickGreenButton());
    }

    [Test]
    public void TableHeaders_AreCorrect()
    {
        List<string> headers = challengingDOMPage.GetTableHeaders();
        Assert.IsTrue(headers.Count > 0);
        Assert.Contains("Lorem", headers); // Known header
    }

    [Test]
    public void TableRows_Exist()
    {
        List<List<string>> rows = challengingDOMPage.GetTableRows();
        Assert.IsTrue(rows.Count > 0);
        Assert.AreEqual(rows[0].Count, challengingDOMPage.GetTableHeaders().Count);
    }

    [Test]
    public void EditAndDeleteRow_NoExceptionThrown()
    {
        Assert.DoesNotThrow(() => challengingDOMPage.ClickEdit(0));
        Assert.DoesNotThrow(() => challengingDOMPage.ClickDelete(0));
    }
}
