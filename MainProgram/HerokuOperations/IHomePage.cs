namespace HerokuOperations
{
    public interface IHomePage
    {
        string GetTitle();
        string GetSubTitle();
        string GetRepoUrl();

        string[] getAvailableExamples();


        void GoToExample(string exampleName);


    }
}
