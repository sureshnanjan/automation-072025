namespace HerokuOperations
{
    public interface IDynamicContentPage
    {
        string GetTitle();
        string GetSubTitle();
        int GetRowCount();

        string GetTextFromRow(int rowIndex);
        string GetImageSourceFromRow(int rowIndex);
    }
}
