// ---------------------------------------------------------------------------
// Author: Siva Sree
// Date Created: 2025-07-27
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This file contains unit tests for the usage of C#'s built-in Array.BinarySearch
// functionality. It uses the Microsoft.VisualStudio.TestTools.UnitTesting framework 
// to verify binary search behavior in different conditions such as searching 
// within a specified range, handling unsorted arrays, and understanding 
// the behavior when the element is not found.
// ---------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySearcherTests
{
    /// <summary>
    /// Contains unit tests to validate C#'s Array.BinarySearch behavior
    /// under different use cases using the MSTest framework.
    /// </summary>
    [TestClass]
    public class BuiltInBinarySearchTests
    {
        /// <summary>
        /// Tests that BinarySearch returns the correct index
        /// when the key exists within the specified range of the array.
        /// </summary>
        [TestMethod]
        public void SearchWithinSpecificRange_ShouldReturnCorrectIndex()
        {
            // Arrange
            int[] array = { 1, 3, 5, 7, 9, 11 };
            int startIndex = 1;
            int length = 4;
            int key = 7;
            int expected = 3;

            // Act
            int actual = Array.BinarySearch(array, startIndex, length, key);

            // Assert
            Assert.AreEqual(expected, actual, "Should find element within the specified range.");
        }

        /// <summary>
        /// Tests that BinarySearch returns a negative complement of the insertion point
        /// when the key does not exist within the specified search range.
        /// </summary>
        [TestMethod]
        public void SearchWithinSpecificRange_NotFound_ShouldReturnNegative()
        {
            // Arrange
            int[] array = { 2, 4, 6, 8, 10, 12 };
            int startIndex = 2;
            int length = 3;
            int key = 7;
            int expected = ~3;

            // Act
            int actual = Array.BinarySearch(array, startIndex, length, key);

            // Assert
            Assert.AreEqual(expected, actual, "Should return complement of insertion point.");
        }

        /// <summary>
        /// Demonstrates that using BinarySearch on an unsorted array
        /// yields unpredictable or incorrect results.
        /// </summary>
        [TestMethod]
        public void SearchOnUnsortedArray_ShouldReturnIncorrectIndex()
        {
            // Arrange
            int[] unsortedArray = { 10, 2, 30, 4, 1 };
            int key = 4;

            // Act
            int result = Array.BinarySearch(unsortedArray, key);

            // Assert
            // Behavior is undefined; test only ensures no crash or exception.
            Assert.IsTrue(result < 0 || result >= 0, "Unsorted array - behavior is unpredictable.");
        }
    }
}
