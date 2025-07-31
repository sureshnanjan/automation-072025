
namespace HerokuAppScenarios;


public class ForgotPasswordScenarios
{

    private IForgotPassword forgotPassword;
    [SetUp]
    public void Setup()
    {
        forgotPassword = new ForgotPasswordScenarios();

    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
