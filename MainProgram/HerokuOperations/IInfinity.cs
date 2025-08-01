namespace HerokuOperations
{
    // Interface for Infinite Scroll Page interactions
    public interface IInfinity
    {
        // Navigates to the Infinite Scroll page
        void GotoPage();

        // Scrolls down the page by a given number of times
        void ScrollDown(int times);

        // Returns the number of paragraph blocks loaded on the page
        int GetParagraphCount();

        // Gets the current vertical scroll position (Y-axis)
        int GetScrollY();

        // Scrolls to the bottom of the page
        void ScrollToBottom();

        // Scrolls to the top of the page
        void ScrollToTop();

        // Closes the browser session
        void Close();
    }
}
