using HerokuOperations;
using HerokuAppWeb;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace HerokuAppScenarios;

public class ChallengingDOMPageScenarios
{
    private ChromeDriver driver; // More specific type
    private IChallengingDOM challengingDOMPage;

    [SetUp]
    public void Setup()
    {
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
        Assert.Contains("Lorem", headers); 
        Assert.Contains("Ipsum", headers);
        Assert.Contains("Dolor", headers); 
        Assert.Contains("Sit", headers); 
        Assert.Contains("Amet", headers); 
        Assert.Contains("Diceret", headers); 
        Assert.Contains("Action", headers); 
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
