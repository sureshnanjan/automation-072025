﻿/*
 * Copyright © 2025 Sehwag Vijay
 * All rights reserved.
 */

using System;

namespace HerokuOperations
{
    /// <summary>
    /// Interface defining operations for interacting with elements inside Shadow DOMs.
    /// Used for retrieving text from open and nested shadow hosts.
    /// </summary>
    public interface IShadowDOM
    {
        /// <summary>
        /// Gets the text content of the first shadow host's paragraph element.
        /// For example: "My default text"
        /// </summary>
        /// <returns>The text within the first shadow host.</returns>
        string GetFirstShadowHostText();

        /// <summary>
        /// Gets the text content of the second shadow host's paragraph element.
        /// For example: "Let's have some different text!"
        /// </summary>
        /// <returns>The text within the second shadow host.</returns>
        string GetSecondShadowHostText();

        /// <summary>
        /// Gets the text content from a deeply nested shadow DOM element.
        /// </summary>
        /// <returns>The text inside the nested shadow element.</returns>
        string GetNestedShadowText();
    }
}

    
