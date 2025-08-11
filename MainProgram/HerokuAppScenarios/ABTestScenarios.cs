<<<<<<< HEAD
﻿using HerokuOperations;
=======
﻿using HerokuAppWeb;
using HerokuOperations;
>>>>>>> e61a7b07dfaee872f7c92bafa503b62494e5548e

namespace HerokuAppScenarios;

public class ABTestScenarios
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ABTestEnabelWorks()
    {
        // Arrange
        IHomePage page;
        IABTest abpage;
<<<<<<< HEAD
        page.GoToExample("A/B Testing");
        string actual = abpage.GetTitle();
=======
        //page.GoToExample("A/B Testing");
        //string actual = abpage.GetTitle();
    }

    [Test]
    public void ABTestEnabedWorks()
    {
        // Arrange
        IHomePage page = new HomePage();
        IABTest abpage = new ABTesting();
        //abpage.DisableABTest();
        page.GoToExample("A/B Testing");
        string expected = "NO A/B Test";
        string actual = abpage.GetTitle();
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ABTestDisabledWorks()
    {
        // Arrange
        IHomePage page = new HomePage();
        IABTest abpage = new ABTesting();
        //abpage.DisableABTest();
        page.GoToExample("A/B Testing");
        string expected = "NO A/B Test";
        string actual = abpage.GetTitle();
        Assert.AreEqual(expected, actual);
>>>>>>> e61a7b07dfaee872f7c92bafa503b62494e5548e
    }
}
