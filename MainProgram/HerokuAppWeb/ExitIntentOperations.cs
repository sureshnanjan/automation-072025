/*******************************************************
* Copyright (c) 2025, Shreya S G
* All rights reserved.
* 
* File: ExitIntentOperations.cs
* Purpose: Implements IExitIntent to simulate Exit Intent popup interactions.
*******************************************************/
using System;

namespace HerokuOperations
{
    /// <summary>
    /// Concrete class to handle Exit Intent functionality.
    /// </summary>
    public class ExitIntentOperations : IExitIntent
    {
        private bool popupVisible = false;
        private string popupTitle = "This is a modal window";
        private string popupContent = "It's commonly used to show exit intent messages.";

        public void TriggerExitIntent()
        {
            popupVisible = true;
        }

        public string GetPopupTitle()
        {
            return popupVisible ? popupTitle : string.Empty;
        }

        public string GetPopupContent()
        {
            return popupVisible ? popupContent : string.Empty;
        }

        public void ClosePopup()
        {
            popupVisible = false;
        }
    }
}
