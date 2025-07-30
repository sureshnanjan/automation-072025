using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public interface INestedFrames
    {
        void SwitchToTopFrame();               // Switch to the main top frame
        void SwitchToLeftFrame();              // Switch to left frame (inside top frame)
        void SwitchToMiddleFrame();            // Switch to middle frame (inside top frame)
        void SwitchToRightFrame();             // Switch to right frame (inside top frame)
        void SwitchToBottomFrame();            //Switch to Bottom frame
    }
}
