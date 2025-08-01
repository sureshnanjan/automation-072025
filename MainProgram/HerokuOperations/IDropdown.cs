namespace HerokuOperations
{
    public interface IDropdownPage
    {
        string GetTitle();

        string[] GetAllOptions();
        void SelectOptionByText(string optionText);
        string GetSelectedOption();
    }
}