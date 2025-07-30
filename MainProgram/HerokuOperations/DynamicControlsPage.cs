namespace HerokuOperations
{
    public interface IDynamicControlsPage
    {
        // Checkbox section
        void ClickRemoveOrAddButton();
        bool IsCheckboxDisplayed();
        string GetCheckboxMessage();

        // Input field section
        void ClickEnableOrDisableButton();
        bool IsInputEnabled();
        void EnterText(string text);
        string GetInputMessage();
    }
}
