using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerokuOperations
{
    public interface IHorizontalSlider
    {
        string GetTitle();  // Check the Titles
        string GetDescription();    // Check the Description
        void FocusSlider();    // puts focus on slider
        int MoveSLiderLeft( int steps);   //moves left,return value
        int MoveSLiderRight(int steps);    //moves right,return values
        int GetSliderValue();  //return value





    }
}
