// Author: Siva Sree
// Date Created: 2025-07-27
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# file demonstrates the use of the Array.BinarySearch() method,
// including its behavior when elements are found or not found, and how it
// throws different exceptions (ArgumentNullException, ArgumentException,
// InvalidOperationException) in invalid scenarios. It provides a practical
// walkthrough of working with binary search in arrays with custom ranges.

using System;

namespace BinarySearchDemo
{
    /// <summary>
    /// Demonstrates various use cases of Array.BinarySearch with exception handling.
    /// </summary>
    public class BinarySearchExample
    {
        /// <summary>
        /// Main method that executes binary search operations and handles exceptions.
        /// </summary>
        public static void Main()
        {
            try
            {
                // 1. Define a sorted integer array
                int[] numbers = { 1, 3, 5, 7, 9, 11 };

                // 2. Binary search for an element that exists (should return index)
                int index = Array.BinarySearch(numbers, 0, numbers.Length, 7);
                Console.WriteLine("Element 7 found at index: " + index);

                // 3. Binary search for an element that does NOT exist
                // It returns a negative number which is the bitwise complement of the insert position
                int notFoundIndex = Array.BinarySearch(numbers, 0, numbers.Length, 6);
                Console.WriteLine("Element 6 not found. Insert position (bitwise complement): " + notFoundIndex);

                // 4. Attempting search on a null array throws ArgumentNullException
                int[]? nullArray = null;
                try
                {
                    Array.BinarySearch(nullArray!, 0, 1, 5); // Null-forgiving operator used intentionally
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }

                // 5. Using a multi-dimensional array throws ArgumentException
                int[,] multiDimensional = new int[2, 2] { { 1, 2 }, { 3, 4 } };
                try
                {
                    Array.BinarySearch(multiDimensional, 0, 1, 3);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }

                // 6. Binary search on a mixed object array with no IComparable implementation
                object[] mixedArray = new object[] { new object(), new object() };
                try
                {
                    Array.BinarySearch(mixedArray, 0, 2, new object());
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                // Catch-all for any unexpected runtime exception
                Console.WriteLine("General Exception: " + ex.Message);
            }
        }
    }
}
