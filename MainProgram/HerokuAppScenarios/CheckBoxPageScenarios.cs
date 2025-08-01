using HerokuOperations;
using HerokuAppWeb;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace HerokuAppScenarios;

public class CheckBoxPageScenarios
{
    private IWebDriver driver; // Use IWebDriver for flexibility
    private ICheckBoxes checkBoxesPage;

    [SetUp]
    public void Setup()
    {
        /*var options = new ChromeOptions();
        options.AddArgument("--headless");
        options.AddArgument("--disable-gpu");

        driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");

        checkBoxesPage = new CheckBoxesClassApp(driver); // Use the class that implements ICheckBoxes*/
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
    }

    [Test]
    public void PageTitle_AreCorrect()
    {
        string title = checkBoxesPage.GetPageTitle();
        Assert.AreEqual("Checkboxes", title);
    }

    [Test]
    public void CheckFirstBox_WhenUnchecked_ShouldBeChecked()
    {
        checkBoxesPage.CheckFirstBox();
        Assert.IsTrue(checkBoxesPage.IsFirstBoxChecked(), "First checkbox should be checked.");
    }
    [Test]
    public void UncheckSecondBox_WhenChecked_ShouldBeUnchecked()
    {
        checkBoxesPage.UncheckSecondBox();
        Assert.IsFalse(checkBoxesPage.IsSecondBoxChecked(), "Second checkbox should be unchecked.");
    }
    [Test]
    public void GetAllCheckboxStates_ShouldReturnCorrectStates()
    {
        List<bool> states = checkBoxesPage.GetAllCheckboxStates();
        Assert.AreEqual(2, states.Count, "There should be two checkboxes.");
        Assert.IsTrue(states[0] || states[1], "First checkbox state should be true or second checkbox state should be false.");
    }

    [Test]
    public void CheckFirstBox_WhenAlreadyChecked_ShouldRemainChecked()
    {
        checkBoxesPage.CheckFirstBox(); // Ensure it's checked first
        checkBoxesPage.CheckFirstBox(); // Call again to check idempotency
        Assert.IsTrue(checkBoxesPage.IsFirstBoxChecked(), "First checkbox should remain checked.");
    }

    [Test]
    public void UncheckSecondBox_WhenAlreadyUnchecked_ShouldRemainUnchecked()
    {
        checkBoxesPage.UncheckSecondBox(); // Ensure it's unchecked first
        checkBoxesPage.UncheckSecondBox(); // Call again to check idempotency
        Assert.IsFalse(checkBoxesPage.IsSecondBoxChecked(), "Second checkbox should remain unchecked.");
    }
}
