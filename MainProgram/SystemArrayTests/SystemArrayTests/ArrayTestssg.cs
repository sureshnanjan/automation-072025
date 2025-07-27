/**************************************************************************************
 *  File: ArrayTestssg.cs
 *  Project: SystemArrayTests
 *  Author: Shreya S G
 *  Created: 27 - 07 - 2025
 *  
 *  Description:
 *  This file contains test cases for various overloads of the Array.BinarySearch method.
 *  It includes examples for both numeric arrays and string arrays, demonstrating usage
 *  of custom comparers (IComparer) and built-in comparers (StringComparer).
 *  
 *  Copyright (c) 2025 AscendionQA
 *  All rights reserved.
 **************************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace SystemArrayTests
{
    /// <summary>
    /// A custom comparer for integers that performs ascending order comparison.
    /// Implements the IComparer interface.
    /// </summary>
    public class AscendingIntegerComparer : IComparer
    {
        /// <summary>
        /// Compares two objects as integers in ascending order.
        /// </summary>
        /// <param name="x">First object (expected to be an integer).</param>
        /// <param name="y">Second object (expected to be an integer).</param>
        /// <returns>
        /// Less than zero if x &lt; y.
        /// Zero if x == y.
        /// Greater than zero if x &gt; y.
        /// </returns>
        public int Compare(object x, object y)
        {
            int a = (int)x; // Cast the first object to int
            int b = (int)y; // Cast the second object to int
            return a.CompareTo(b); // Use built-in CompareTo for ascending comparison
        }
    }

    /// <summary>
    /// Test class containing MSTest test cases for Array.BinarySearch method overloads.
    /// </summary>
    [TestClass]
    public class ArrayTestssg
    {
        /// <summary>
        /// Tests BinarySearch(Array, Int32, Int32, Object, IComparer) 
        /// using a custom ascending comparer, verifying a value is found at the correct index.
        /// </summary>
        [TestMethod]
        public void BinarySearch_AscendingComparer_FindsCorrectIndex()
        {
            // Arrange: Create an array of integers
            int[] numbers = { 10, 20, 30, 40, 50, 60 };

            // Action: Sort the array using the custom ascending comparer
            Array.Sort(numbers, new AscendingIntegerComparer());

            // Action: Perform a binary search for the number 40
            int index = Array.BinarySearch(numbers, 0, numbers.Length, 40, new AscendingIntegerComparer());

            // Assert: Verify that 40 is found at index 3
            Assert.AreEqual(3, index);
        }

        /// <summary>
        /// Tests BinarySearch(Array, Int32, Int32, Object, IComparer)
        /// using a custom ascending comparer, verifying the return value when the element is not found.
        /// </summary>
        [TestMethod]
        public void BinarySearch_AscendingComparer_ReturnsNegativeIfNotFound()
        {
            // Arrange: Create an array of integers
            int[] numbers = { 10, 20, 30, 40, 50, 60 };

            // Action: Sort the array using the custom ascending comparer
            Array.Sort(numbers, new AscendingIntegerComparer());

            // Action: Perform a binary search for the number 25 (not in the array)
            int index = Array.BinarySearch(numbers, 0, numbers.Length, 25, new AscendingIntegerComparer());

            // Assert: Verify that the index is negative (element not found)
            Assert.IsTrue(index < 0);
        }
        //String example
        /// <summary>
        /// Tests BinarySearch(Array, Int32, Int32, Object, IComparer)
        /// using a built-in case-insensitive string comparer, verifying a value is found.
        /// </summary>
        [TestMethod]
        public void BinarySearch_WithCustomComparer_FindsCorrectIndex()
        {
            // Arrange: Create an array of strings
            string[] words = { "Apple", "Banana", "Cherry", "Date", "Fig", "Grape" };

            // Action: Use built-in case-insensitive string comparer
            IComparer caseInsensitiveComparer = StringComparer.OrdinalIgnoreCase;

            // Action: Search for "banana" in the full array
            int index = Array.BinarySearch(words, 0, words.Length, "banana", caseInsensitiveComparer);

            // Assert: Verify that "Banana" is found at index 1
            Assert.AreEqual(1, index);
        }

        /// <summary>
        /// Tests BinarySearch(Array, Int32, Int32, Object, IComparer)
        /// using a built-in case-insensitive string comparer, verifying behavior when element not found.
        /// </summary>
        [TestMethod]
        public void BinarySearch_WithCustomComparer_ReturnsNegativeIfNotFound()
        {
            // Arrange: Create an array of strings
            string[] words = { "Apple", "Banana", "Cherry", "Date", "Fig", "Grape" };
            IComparer caseInsensitiveComparer = StringComparer.OrdinalIgnoreCase;

            // Action: Search for "Orange" (not in array)
            int index = Array.BinarySearch(words, 0, words.Length, "Orange", caseInsensitiveComparer);

            // Assert: Verify that the index is negative (element not found)
            Assert.IsTrue(index < 0);
        }


        //Method 2 BinarySearch(Array, Int32, Int32, Object)
        /// <summary>
        /// Tests BinarySearch(Array, Int32, Int32, Object)
        /// to verify that it successfully finds an existing element within a specified range.
        /// </summary>
        /// <remarks>
        /// This test searches for the number 30 in the subarray from index 1 to index 3.
        /// It verifies that the method returns the correct index where the value is found.
        /// </remarks>
        [TestMethod]
        public void BinarySearch_Range_NoComparer_FindsNumber()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };
            int index = Array.BinarySearch(numbers, 1, 3, 30); // Search between index 1-3
            Assert.AreEqual(2, index); // 30 is at index 2
        }

        /// <summary>
        /// Tests BinarySearch(Array, Int32, Int32, Object)
        /// to verify its behavior when the searched value does not exist in the specified range.
        /// </summary>
        /// <remarks>
        /// This test searches for the number 100 in the subarray from index 1 to index 3.
        /// It verifies that the method returns a negative index, indicating the value was not found.
        /// </remarks>
        [TestMethod]
        public void BinarySearch_Range_NoComparer_NumberNotFound()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };
            int index = Array.BinarySearch(numbers, 1, 3, 100);
            Assert.IsTrue(index < 0); // 100 not in range
        }


        //Method 3
        //BinarySearch(Array, Object, IComparer)
        public class DescendingComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return ((IComparable)y).CompareTo(x); // Reverse comparison
            }
        }

        [TestMethod]
        public void BinarySearch_CustomComparer_FindsNumber()
        {
            int[] numbers = { 100, 80, 60, 40, 20 };
            int index = Array.BinarySearch(numbers, 60, new DescendingComparer());
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void BinarySearch_CustomComparer_NumberNotFound()
        {
            int[] numbers = { 100, 80, 60, 40, 20 };
            int index = Array.BinarySearch(numbers, 75, new DescendingComparer());
            Assert.IsTrue(index < 0);
        }

        //Method 4
        //BinarySearch(Array, Object)
        [TestMethod]
        public void BinarySearch_WholeArray_FindsString()
        {
            string[] fruits = { "Apple", "Banana", "Cherry" };
            int index = Array.BinarySearch(fruits, "Banana");
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void BinarySearch_WholeArray_StringNotFound()
        {
            string[] fruits = { "Apple", "Banana", "Cherry" };
            int index = Array.BinarySearch(fruits, "Fig");
            Assert.IsTrue(index < 0);
        }

        //Method 5
        // BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>)
        public class ReverseComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y) => y.CompareTo(x);
        }

        [TestMethod]
        public void BinarySearch_GenericRange_CustomComparer_FindsNumber()
        {
            int[] numbers = { 100, 80, 60, 40, 20 };
            int index = Array.BinarySearch(numbers, 0, numbers.Length, 40, new ReverseComparer<int>());
            Assert.AreEqual(3, index);
        }

        [TestMethod]
        public void BinarySearch_GenericRange_CustomComparer_NumberNotFound()
        {
            int[] numbers = { 100, 80, 60, 40, 20 };
            int index = Array.BinarySearch(numbers, 0, numbers.Length, 75, new ReverseComparer<int>());
            Assert.IsTrue(index < 0);
        }

        /// <summary>
        /// String example
        /// </summary>
        
        [TestMethod]
        public void BinarySearch_GenericRange_CustomComparer_FindsString()
        {
            string[] words = { "Zebra", "Monkey", "Apple" };
            Array.Sort(words, StringComparer.OrdinalIgnoreCase);
            int index = Array.BinarySearch(words, 0, words.Length, "Monkey", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index >= 0);
        }

        [TestMethod]
        public void BinarySearch_GenericRange_CustomComparer_StringNotFound()
        {
            string[] words = { "Zebra", "Monkey", "Apple" };
            Array.Sort(words, StringComparer.OrdinalIgnoreCase);
            int index = Array.BinarySearch(words, 0, words.Length, "Banana", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index < 0);
        }

        //Method 6
        //BinarySearch<T>(T[], Int32, Int32, T)

        [TestMethod]
        public void BinarySearch_GenericRange_NoComparer_FindsNumber()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };
            int index = Array.BinarySearch(numbers, 1, 3, 30);
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void BinarySearch_GenericRange_NoComparer_NumberNotFound()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };
            int index = Array.BinarySearch(numbers, 1, 3, 75);
            Assert.IsTrue(index < 0);
        }

        //Method 7
        //BinarySearch<T>(T[], T, IComparer<T>)
        [TestMethod]
        public void BinarySearch_GenericWholeArray_CustomComparer_FindsNumber()
        {
            int[] numbers = { 100, 80, 60, 40, 20 };
            int index = Array.BinarySearch(numbers, 40, new ReverseComparer<int>());
            Assert.AreEqual(3, index);
        }

        [TestMethod]
        public void BinarySearch_GenericWholeArray_CustomComparer_NumberNotFound()
        {
            int[] numbers = { 100, 80, 60, 40, 20 };
            int index = Array.BinarySearch(numbers, 75, new ReverseComparer<int>());
            Assert.IsTrue(index < 0);
        }


        //Method 8
        //BinarySearch<T>(T[], T)
        [TestMethod]
        public void BinarySearch_GenericWholeArray_NoComparer_FindsNumber()
        {
            int[] numbers = { 5, 10, 15, 20 };
            int index = Array.BinarySearch(numbers, 15);
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void BinarySearch_GenericWholeArray_NoComparer_NumberNotFound()
        {
            int[] numbers = { 5, 10, 15, 20 };
            int index = Array.BinarySearch(numbers, 50);
            Assert.IsTrue(index < 0);
        }

        //String example

        [TestMethod]
        public void BinarySearch_GenericWholeArray_NoComparer_FindsString()
        {
            string[] fruits = { "Apple", "Banana", "Cherry" };
            int index = Array.BinarySearch(fruits, "Banana");
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void BinarySearch_GenericWholeArray_NoComparer_StringNotFound()
        {
            string[] fruits = { "Apple", "Banana", "Cherry" };
            int index = Array.BinarySearch(fruits, "Fig");
            Assert.IsTrue(index < 0);
        }

    }
}
