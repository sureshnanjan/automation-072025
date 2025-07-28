using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    public class  GenericCalculator<T>
    {
        T first;
        T second;

        public GenericCalculator(T one , T two)
        {
            this.first = one;
            this.second = two;
        }

        void add() 
        {
            Console.WriteLine($"Subtracting {this.first}  and {this.second}");
        }

        void  sub() { Console.WriteLine($"Subtracting {this.first}  and {this.second}"); }
    }
}