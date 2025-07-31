namespace HerokuOperations
{
    public interface IHomePage
    {
        string GetTitle();
        string GetSubTitle();
        string GetRepoUrl();

        string[] getAvailableExamples();

<<<<<<< HEAD
=======
        void GoToExample(string exampleName);

>>>>>>> 11ff258d974d9a198d365c82dd5d560619caf7e6
    }
}
