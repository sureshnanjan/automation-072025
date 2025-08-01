//using HerokuOperations;

//namespace HerokuAppScenarios;

//public class Tests
//{
//    IHomePage homepage;

//    [SetUp]
//        public void Setup()
//        {
//        }

//        [Test]
//        public void HerokuTitleisOK()
//        {
//        //IHomePage homepage;
//            string actual = homepage.GetTitle();
//            Assert.AreEqual("Welcome to Internet", actual);

//        }
//    }

using HerokuOperations;
using HerokuAppWeb;
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
            IHomePage homepage = new HomePage();
            string actual = homepage.GetTitle();
            Assert.AreEqual(expected, actual);
            
        }
    }
}
