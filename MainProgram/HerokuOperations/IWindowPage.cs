namespace HerokuOperations
{
    public interface IWindowPage
    {
        void GotoPage();                 // Navigate to the Multiple Windows page
        string GetTitle();              // Get the title text from the main page
        void ClickHereLink();           // Click the "Click Here" link to open a new window
        void SwitchToNewWindow();       // Switch to the newly opened window
        void SwitchToMainWindow();      // Switch back to the original window
        string GetNewWindowText();      // Get the text from the new window
    }
}
