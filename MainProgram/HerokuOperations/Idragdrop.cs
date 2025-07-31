using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    internal interface Idragdrop
    {
        
        /// Gets the title of the page.
        string GetTitle();


        /// Gets the label/text of Column A.
        string GetColumnAText();


        /// Gets the label/text of Column B.
        string GetColumnBText();

        /// Performs the drag-and-drop action from Column A to Column B.
        void DragAtoB();

        /// Performs the drag-and-drop action from Column B to Column A.
        void DragBtoA();
    }
}