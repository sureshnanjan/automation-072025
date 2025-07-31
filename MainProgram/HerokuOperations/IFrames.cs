using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Interface to interact with Frames main page,
    /// Nested Frames page, and iFrame editor page on the herokuapp site.
    /// </summary>
    public interface IFrames
    {
        /// <summary>
        /// Navigates to the Frames main page.
        /// </summary>
        void GoToPage();

        /// <summary>
        /// Clicks the "Nested Frames" link on the Frames main page.
        /// </summary>
        void ClickNestedFrames();

        /// <summary>
        /// Clicks the "iFrame" link on the Frames main page.
        /// </summary>
        void ClickIFrame();

        /// <summary>
        /// Navigates directly to the Nested Frames page.
        /// </summary>
        void GoToNestedFramesPage();

        /// <summary>
        /// Gets the text content from the left frame inside the Nested Frames page.
        /// </summary>
        /// <returns>Text inside the left frame</returns>
        string GetLeftFrameText();

        /// <summary>
        /// Gets the text content from the middle frame inside the Nested Frames page.
        /// </summary>
        /// <returns>Text inside the middle frame</returns>
        string GetMiddleFrameText();

        /// <summary>
        /// Gets the text content from the right frame inside the Nested Frames page.
        /// </summary>
        /// <returns>Text inside the right frame</returns>
        string GetRightFrameText();

        /// <summary>
        /// Gets the text content from the bottom frame inside the Nested Frames page.
        /// </summary>
        /// <returns>Text inside the bottom frame</returns>
        string GetBottomFrameText();

        /// <summary>
        /// Navigates directly to the iFrame editor page.
        /// </summary>
        void GoToIFramePage();

        /// <summary>
        /// Switches the WebDriver context to the iFrame.
        /// </summary>
        void SwitchToIFrame();

        /// <summary>
        /// Clears any existing text inside the iFrame editor.
        /// </summary>
        void ClearEditor();

        /// <summary>
        /// Enters the specified text into the iFrame editor.
        /// </summary>
        /// <param name="text">Text to enter into the editor</param>
        void EnterText(string text);

        /// <summary>
        /// Retrieves the current text content from the iFrame editor.
        /// </summary>
        /// <returns>Text inside the editor</returns>
        string GetEditorText();

        /// <summary>
        /// Switches the WebDriver context back to the default content (main page).
        /// </summary>
        void SwitchToDefaultContent();
    }
}
