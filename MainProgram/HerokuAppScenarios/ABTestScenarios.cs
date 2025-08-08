
﻿/*using HerokuOperations;
=======
﻿using HerokuAppWeb;
using HerokuOperations;
>>>>>>> c842627f248d79ffe5c87be7bb4c215e90312610

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
    }
}
*/