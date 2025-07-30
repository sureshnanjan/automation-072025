/*******************************************************
* Copyright (c) 2025, Shreya S G
* All rights reserved.
* 
* File: IEntryAd.cs
* Purpose: Interface for operations related to the Entry Ad feature.
*******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    /// <summary>
    /// Interface defining operations for handling Entry Ads.
    /// </summary>
    public interface IEntryAd
    {
        /// <summary>
        /// Gets the title of the Entry Ad popup.
        /// </summary>
        /// <returns>Title text of the Entry Ad.</returns>
        string GetAdTitle();

        /// <summary>
        /// Gets the description/content of the Entry Ad popup.
        /// </summary>
        /// <returns>Description text of the Entry Ad..</returns>
        string GetAdContent();

        /// <summary>
        /// Closes the Entry Ad popup.
        /// </summary>
        void CloseAd();

        /// <summary>
        /// Relaunches the Entry Ad (if dismissed).
        /// </summary>
        void RelaunchAd();
    }
}
