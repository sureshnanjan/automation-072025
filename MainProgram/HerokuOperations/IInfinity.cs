namespace HerokuOperations
{
    public interface IInfinity
    {
        void GotoPage();
        int GetScrollY();
        void ScrollToBottom();
        void ScrollToTop();
    }
}
