using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public interface HorizontalSlider
    {
        string GetTitle();
        string GetDescription();
        void FocusSlider();
        void MoveSLiderLeft(int steps);
        void MoveSLiderRight(int steps);
        int GetSliderValue();





    }
}
