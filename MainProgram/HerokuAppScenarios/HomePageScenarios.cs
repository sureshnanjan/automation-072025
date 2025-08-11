<<<<<<< HEAD
/*using HerokuOperations;
=======
using HerokuOperations;
using HerokuAppWeb;
<<<<<<< HEAD
>>>>>>> 8773420fc6cc29e183334d2d4275828caaab1a6a
=======
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
           IHomePage homepage = new HomePage(); // Web
            string actual = homepage.GetTitle();
            //Assert.AreEqual(expected, actual);
            
        }
    }
}*/