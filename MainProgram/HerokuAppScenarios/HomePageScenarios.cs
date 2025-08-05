<<<<<<< HEAD
/*using HerokuOperations;
namespace HerokuAppScenarios.Tests

public class Tests
{
    [SetUp]
    public void Setup()
    {
=======
using HerokuOperations;
using HerokuAppWeb;
using MobileApp = HerokuAppMobile.HomePage;
namespace HerokuAppScenarios
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HerokuTitleisOK()
        {
            // Arrange
            string expected = "Welcome to Internet";
           IHomePage homepage = new HomePage(); // Web
            string actual = homepage.GetTitle();
            Assert.AreEqual(expected, actual);
            
        }
>>>>>>> c842627f248d79ffe5c87be7bb4c215e90312610
    }

    [Test]
    public void HerokuTitleisOK()
    {
        // Arrange
        string expected = "Welcome to Internet";
        IHomePage homepage;
        string actual = homepage.GetTitle();
        Assert.AreEqual(expected, actual);
        
    }
}*/