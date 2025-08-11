using HerokuOperations;
<<<<<<< HEAD
=======
using HerokuAppWeb;
using MobileApp = HerokuAppMobile.HomePage;
>>>>>>> e61a7b07dfaee872f7c92bafa503b62494e5548e
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
<<<<<<< HEAD
            IHomePage homepage;
=======
           IHomePage homepage = new HomePage(); // Web
>>>>>>> e61a7b07dfaee872f7c92bafa503b62494e5548e
            string actual = homepage.GetTitle();
            Assert.AreEqual(expected, actual);
            
        }
    }
}