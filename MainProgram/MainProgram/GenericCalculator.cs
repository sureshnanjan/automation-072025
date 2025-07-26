/************************************************************************************
*  © 2025 AscendionQA. All rights reserved.
*  
*  File: GenericCalculator.cs
*  Description: This file contains the implementation of a generic calculator class 
*               that can perform basic arithmetic operations on two values of the 
*               same type using generics in C#.
*  
*  Author: SHREYA S G
*  Created On: 26-Jul-2025
*  
*  NOTE:
*  - This is a simple demonstration of how generics work in C#.
*  - The arithmetic operations assume that T is a type that supports basic 
*    arithmetic (like int, double, etc.).
************************************************************************************/

using System;

namespace MainProgram
{
    /// <summary>
    /// A generic calculator class that can hold two values of any type and perform basic operations.
    /// </summary>
    /// <typeparam name="T">
    /// The type of values the calculator will operate on (e.g., int, double, decimal).
    /// </typeparam>
    public class GenericCalculator<T>
    {
        /// <summary>
        /// The first value for calculation.
        /// </summary>
        private T first;

        /// <summary>
        /// The second value for calculation.
        /// </summary>
        private T second;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericCalculator{T}"/> class 
        /// with two values of type T.
        /// </summary>
        /// <param name="one">The first value.</param>
        /// <param name="two">The second value.</param>
        public GenericCalculator(T one, T two)
        {
            this.first = one;
            this.second = two;
        }

        /// <summary>
        /// Adds the two values and prints the result to the console.
        /// </summary>
        public void Add()
        {
            // The dynamic keyword allows performing arithmetic at runtime for generic types.
            dynamic a = this.first;
            dynamic b = this.second;
            Console.WriteLine($"Adding {this.first} and {this.second} gives: {a + b}");
        }

        /// <summary>
        /// Subtracts the second value from the first and prints the result to the console.
        /// </summary>
        public void Subtract()
        {
            dynamic a = this.first;
            dynamic b = this.second;
            Console.WriteLine($"Subtracting {this.second} from {this.first} gives: {a - b}");
        }
    }

    /// <summary>
    /// A sample program to demonstrate the use of the GenericCalculator class.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Create a GenericCalculator for integers
            GenericCalculator<int> intCalc = new GenericCalculator<int>(10, 5);
            intCalc.Add();
            intCalc.Subtract();

            // Create a GenericCalculator for doubles
            GenericCalculator<double> doubleCalc = new GenericCalculator<double>(12.5, 3.2);
            doubleCalc.Add();
            doubleCalc.Subtract();

            Console.ReadLine(); // Keeps the console open until user presses Enter
        }
    }
}
