namespace HerokuOperations
{
    public interface IShiftingContentPage
    {
        string GetTitle();
        string GetDescription();

        string[] GetAllLinkTexts();
        int GetLinkCount();
    }
}