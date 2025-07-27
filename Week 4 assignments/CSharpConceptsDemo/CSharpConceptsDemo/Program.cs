/************************************************************************************
*  © 2025 Your Name or Company Name. All rights reserved.
*  
*  File: Program.cs
*  Description: This program demonstrates key C# concepts:
*               - Generics: Creating type-safe reusable classes
*               - Delegates: Methods as parameters
*               - Lambda Functions: Short inline anonymous methods
*               - LINQ: Querying collections
*               - Enumerators: Iterating through collections
*  
*  Author: Your Name
*  Created On: 26-Jul-2025
************************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConceptsDemo
{
    /// <summary>
    /// A generic calculator class that works with any data type supporting basic arithmetic.
    /// </summary>
    /// <typeparam name="T">The type of values (e.g., int, float, double).</typeparam>
    public class GenericCalculator<T>
    {
        private T first;
        private T second;

        /// <summary>
        /// Initializes the calculator with two values.
        /// </summary>
        public GenericCalculator(T one, T two)
        {
            first = one;
            second = two;
        }

        /// <summary>
        /// Adds the two values and prints the result.
        /// </summary>
        public void Add()
        {
            dynamic a = first;
            dynamic b = second;
            Console.WriteLine($"Addition of {a} and {b} = {a + b}");
        }

        /// <summary>
        /// Subtracts the second value from the first and prints the result.
        /// </summary>
        public void Subtract()
        {
            dynamic a = first;
            dynamic b = second;
            Console.WriteLine($"Subtraction of {a} and {b} = {a - b}");
        }
    }

    /// <summary>
    /// A delegate representing any method that takes two integers and returns an integer.
    /// </summary>
    public delegate int MathOperation(int a, int b);

    /// <summary>
    /// Represents days of the week using an enum.
    /// </summary>
    public enum DaysOfWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    /// <summary>
    /// Program class demonstrating Generics, Delegates, Lambda, LINQ, and Enumerator.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== GENERICS DEMO ===");
            GenericCalculator<int> intCalc = new GenericCalculator<int>(10, 5);
            intCalc.Add();
            intCalc.Subtract();

            Console.WriteLine("\n=== DELEGATES & LAMBDA DEMO ===");
            // Assigning a named method to delegate
            MathOperation addOp = AddNumbers;
            Console.WriteLine($"Delegate Add: {addOp(5, 10)}");

            // Using Lambda for multiplication
            MathOperation multiplyOp = (x, y) => x * y;
            Console.WriteLine($"Lambda Multiply: {multiplyOp(5, 10)}");

            Console.WriteLine("\n=== ENUM DEMO ===");
            DaysOfWeek today = DaysOfWeek.Friday;
            Console.WriteLine($"Today is: {today}");

            Console.WriteLine("\n=== LINQ DEMO ===");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

            Console.WriteLine("\n=== ENUMERATOR DEMO ===");
            List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
            IEnumerator enumerator = names.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine($"Name: {enumerator.Current}");
            }

            Console.WriteLine("\n=== PROGRAM END ===");
            Console.ReadLine(); // Keeps console open
        }

        /// <summary>
        /// Adds two integers.
        /// </summary>
        static int AddNumbers(int a, int b) => a + b;
    }
}
