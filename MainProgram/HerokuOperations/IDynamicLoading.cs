/*
* Copyright © 2025 Sehwag Vijay
* All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    internal interface IDynamicLoading
    {
       
            // Navigates to a specific dynamic loading example (1 or 2)
            void NavigateToExample(int exampleNumber);

            // Starts the dynamic loading
            void ClickStartButton();

            // Waits until the loading is complete
            void WaitForLoadingToFinish();

            // Gets the result text after loading
            string GetResultText();

            // Checks if the loading spinner is displayed
            bool IsLoadingIndicatorVisible();
        }
    }


