namespace HerokuOperations.Interfaces
{
    public interface IHomePage
    {
        string GetTitle();
        string GetSubTitle();
        string GetRepoUrl();

        string[] getAvailableExamples();

    }
}
