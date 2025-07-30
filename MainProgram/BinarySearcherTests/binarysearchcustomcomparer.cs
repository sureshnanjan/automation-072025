// Author: Siva Sree
// Date Created: 2025-07-27
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# file contains unit tests to demonstrate the use of the Array.BinarySearch() method
// using a custom comparer. It shows different test cases including successful search,
// unsuccessful search, empty range search, and how the method handles a null comparer.
// This file uses MSTest for writing unit tests, and helps understand binary search behavior
// within a specified range using a custom IComparer implementation.

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchAdvancedTests
{
    /// <summary>
    /// A simple comparer class that compares integers in ascending order using the default CompareTo method.
    /// This will be used to pass a custom comparer into the Array.BinarySearch method.
    /// </summary>
    public class SimpleComparer : IComparer<int>
    {
        /// <summary>
        /// Compares two integers using their natural order (ascending).
        /// </summary>
        /// <param name="x">The first integer to compare.</param>
        /// <param name="y">The second integer to compare.</param>
        /// <returns>
        /// A negative number if x is less than y, zero if they are equal,
        /// and a positive number if x is greater than y.
        /// </returns>
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }

    /// <summary>
    /// This test class contains unit test methods for the Array.BinarySearch method using a custom comparer.
    /// It tests various scenarios such as element found, not found, edge cases, and exception handling.
    /// </summary>
    [TestClass]
    public class BinarySearchCustomComparer
    {
        // A sorted array of integers used in all test cases.
        int[] numbers = { 1, 3, 5, 7, 9, 11, 13 };

        /// <summary>
        /// Tests if the method correctly finds an element that exists within the given range.
        /// </summary>
        [TestMethod]
        public void Test_ElementInsideRange_Found()
        {
            // Search for 5 in range index 1 to 3: {3, 5, 7}
            int index = Array.BinarySearch(numbers, 1, 3, 5, new SimpleComparer());
            Assert.AreEqual(2, index); // 5 is at index 2 in the full array
        }

        /// <summary>
        /// Tests if the method returns a negative value when the element does not exist in the range.
        /// </summary>
        [TestMethod]
        public void Test_ElementInsideRange_NotFound()
        {
            // Search for 6 in {3, 5, 7} — not present
            int index = Array.BinarySearch(numbers, 1, 3, 6, new SimpleComparer());
            Assert.IsTrue(index < 0); // Should return a negative index
        }

        /// <summary>
        /// Tests that the method does not find an element that is outside the defined search range.
        /// </summary>
        [TestMethod]
        public void Test_ElementOutsideGivenRange_NotFound()
        {
            // Search for 11 in range index 2 to 3: {5, 7}
            int index = Array.BinarySearch(numbers, 2, 2, 11, new SimpleComparer());
            Assert.IsTrue(index < 0); // 11 is outside this subrange
        }

        /// <summary>
        /// Tests if the method finds an element that exists at the start of the range.
        /// </summary>
        [TestMethod]
        public void Test_ElementAtStartOfRange_Found()
        {
            // Search for 1 in range {1, 3, 5}
            int index = Array.BinarySearch(numbers, 0, 3, 1, new SimpleComparer());
            Assert.AreEqual(0, index); // 1 is at index 0
            PetStore mycheenai = new PetStore();
            foreach (var item in mycheenai)
            {
                
            }
        }

        /// <summary>
        /// Tests if the method finds an element that exists at the end of the given range.
        /// </summary>
        [TestMethod]
        public void Test_ElementAtEndOfRange_Found()
        {
            // Search for 7 in range {3, 5, 7}
            int index = Array.BinarySearch(numbers, 1, 3, 7, new SimpleComparer());
            Assert.AreEqual(3, index); // 7 is at index 3
        }

        /// <summary>
        /// Tests if the method correctly returns a negative index when the element is not present at all.
        /// </summary>
        [TestMethod]
        public void Test_ElementOutsideArrayBounds()
        {
            // Search for 100 in entire array — not present
            int index = Array.BinarySearch(numbers, 0, 7, 100, new SimpleComparer());
            Assert.IsTrue(index < 0); // Should return negative index
        }

        /// <summary>
        /// Tests how the method behaves when the range to search is empty (count = 0).
        /// </summary>
        [TestMethod]
        public void Test_EmptyRange()
        {
            // Search in empty range — should return not found
            int index = Array.BinarySearch(numbers, 2, 0, 5, new SimpleComparer());
            Assert.IsTrue(index < 0);
        }

        /// <summary>
        /// Tests if the method throws ArgumentNullException when a null comparer is passed.
        /// </summary>
      
        [TestMethod]
        public void Test_NullComparer_UsesDefaultComparer()
        {
            int[] numbers = { 1, 3, 5, 7, 9, 11, 13 };

            // Pass null as the comparer — should use default comparer for int
            int index = Array.BinarySearch(numbers, 0, numbers.Length, 5, null);

            // 5 is at index 2
            Assert.AreEqual(2, index);
        }
       



    }
}
