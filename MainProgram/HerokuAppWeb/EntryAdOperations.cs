/*******************************************************
* Copyright (c) 2025, Shreya S G
* All rights reserved.
* 
* File: EntryAdOperations.cs
* Purpose: Implements IEntryAd to simulate Entry Ad popup interactions.
*******************************************************/
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Concrete class to handle Entry Ad popup functionality.
    /// </summary>
    public class EntryAdOperations : IEntryAd
    {
        private bool adVisible = true;
        private string adTitle = "This is an Entry Ad";
        private string adContent = "Buy our product and enjoy amazing benefits!";

        public string GetAdTitle()
        {
            return adVisible ? adTitle : string.Empty;
        }

        public string GetAdContent()
        {
            return adVisible ? adContent : string.Empty;
        }

        public void CloseAd()
        {
            adVisible = false;
        }

        public void RelaunchAd()
        {
            adVisible = true;
        }
    }
}