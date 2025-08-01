// -----------------------------------------------------------------------
// <copyright>
//     Copyright (c) 2025 K Vamsi Krishna. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Provides methods to interact with the Nested Frames page.
    /// </summary>
    public interface INestedFrames
    {
        /// <summary>
        /// Navigates to the Nested Frames page.
        /// </summary>
        void GotoPage();

        /// <summary>
        /// Switches to the left frame and retrieves the text inside.
        /// </summary>
        /// <returns>The text inside the left frame.</returns>
        string GetLeftFrameText();

        /// <summary>
        /// Switches to the middle frame and retrieves the text inside.
        /// </summary>
        /// <returns>The text inside the middle frame.</returns>
        string GetMiddleFrameText();

        /// <summary>
        /// Switches to the right frame and retrieves the text inside.
        /// </summary>
        /// <returns>The text inside the right frame.</returns>
        string GetRightFrameText();

        /// <summary>
        /// Switches to the bottom frame and retrieves the text inside.
        /// </summary>
        /// <returns>The text inside the bottom frame.</returns>
        string GetBottomFrameText();
    }
}
