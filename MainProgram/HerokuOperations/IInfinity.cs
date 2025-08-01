using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public interface IinfiniteScroll
    {
        // Navigates to the Infinite Scroll page
        void GotoPage();

        // Returns the title of the page
        string GetTitle();

        // Returns the subtitle of the page
        string GetSubTitle();

        // Scrolls all the way to the bottom of the page
        void ScrollToBottom();

        // Returns the total scrollable height of the page
        int GetScrollHeight();

        // Returns the total scrollable width of the page
        int GetScrollWidth();

        // Scrolls back to the top of the page
        void ScrollToTop();

        // Scrolls all the way to the left side of the page
        void ScrollToLeft();

        // Scrolls all the way to the right side of the page
        void ScrollToRight();

        // Returns the current horizontal scroll position
        int GetScrollX();

        // Returns the current vertical scroll position
        int GetScrollY();

        // Scrolls to a specific X and Y coordinate on the page
        void ScrollTo(int x, int y);
    }
}