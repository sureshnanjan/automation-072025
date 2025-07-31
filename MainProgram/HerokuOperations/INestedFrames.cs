using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Interface to interact with the Nested Frames page on herokuapp.
    /// Provides methods to navigate and retrieve text from different frames.
    /// </summary>
    public interface INestedFrames
    {
        /// <summary>
        /// Navigates to the Nested Frames page.
        /// </summary>
        void GoToPage();

        /// <summary>
        /// Retrieves the text content from the left frame inside the nested frames.
        /// </summary>
        /// <returns>Text inside the left frame.</returns>
        string GetLeftFrameText();

        /// <summary>
        /// Retrieves the text content from the middle frame inside the nested frames.
        /// </summary>
        /// <returns>Text inside the middle frame.</returns>
        string GetMiddleFrameText();

        /// <summary>
        /// Retrieves the text content from the right frame inside the nested frames.
        /// </summary>
        /// <returns>Text inside the right frame.</returns>
        string GetRightFrameText();

        /// <summary>
        /// Retrieves the text content from the bottom frame inside the nested frames.
        /// </summary>
        /// <returns>Text inside the bottom frame.</returns>
        string GetBottomFrameText();
    }
}
