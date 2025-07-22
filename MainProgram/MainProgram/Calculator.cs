using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    public class Calculator
    {
        int first;
        int second;
        float flfirst;
        float flsecond;
        public Calculator(int firstarg, int secondarg)
        {
            this.first = firstarg;
            this.second = secondarg;
        }
        public Calculator(float fl1, float fl2)
        {
            
        }

        int add() { return first + second; }

        //float add() {
        int sub() { return first - second; }

    }
}

