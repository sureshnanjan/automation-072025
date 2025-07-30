using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    internal interface Iinput
    {

        void GotoPage(); // Navigates to the Input page
        string GetTitle(); // Returns the title of the page
        
        int GetInputCount(); // Returns the number of input fields on the page
        string GetInputValue();// Returns the current value of the input field
        void incrementInput();// Increments the value of the input field by 1
        void decrementInput();// Decrements the value of the input field by 1

        void clearInput();//Clears the value of the input field



    }
}
