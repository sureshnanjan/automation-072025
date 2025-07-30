using BinarySearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using CustomExtensions;
namespace BinarySearcherTests
{
    /// <summary>
    /// Unit tests for BinarySearcherImpl using MSTest
    /// </summary>
    [TestClass]
    public sealed class TestBinarySearch
    {
        /// <summary>
        /// Tests if the element is found at the correct index.
        /// </summary>
        [TestMethod]
        public void ElementFound_ReturnsExpectedIndex()
        {
            // Arrange
            int[] inputArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int target = 5;
            int expectedIndex = 4;

            BinarySearcherImpl searcher = new BinarySearcherImpl();

            // Act
            int actualIndex = searcher.doBinaryDearch(inputArray, target);
            // Assert
            Assert.AreEqual(expectedIndex, actualIndex, "Element was not found at the expected index.");
        }

        /// <summary>
        /// Tests when element is not found but is less than some elements in the array.
        /// </summary>
        [TestMethod]
        public void ElementNotFound_LessThanSomeElements_ReturnsNegativeInsertionIndex()
        {
            // Arrange
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            int target = 5;
            int expectedIndex = ~4;

            BinarySearcherImpl searcher = new BinarySearcherImpl();

            // Act
            int actualIndex = searcher.doBinaryDearch(inputArray, target);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex, "Incorrect negative index when value is not found and less than some elements.");
        }

        /// <summary>
        /// Tests when element is not found and is greater than all elements in the array.
        /// </summary>
        [TestMethod]
        public void ElementNotFound_GreaterThanAllElements_ReturnsNegativeLength()
        {
            // Arrange
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            int target = 15;
            int expectedIndex = ~inputArray.Length;

            BinarySearcherImpl searcher = new BinarySearcherImpl();

            // Act
            int actualIndex = searcher.doBinaryDearch(inputArray, target);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex, "Incorrect negative index when value is greater than all elements.");
        }

        /// <summary>
        /// Tests that ArgumentNullException is thrown when array is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsArgumentNullException_WhenArrayIsNull()
        {
            // Arrange
            int[] inputArray = null;
            int target = 5;

            BinarySearcherImpl searcher = new BinarySearcherImpl();

            // Act
            searcher.doBinaryDearch(inputArray, target);
        }

        /// <summary>
        /// Tests that RankException is thrown for a multi-dimensional array.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void ThrowsRankException_WhenArrayIsMultidimensional()
        {
            // Arrange
            int[,] multiArray = new int[,] { { 1, 2 }, { 3, 4 } };

            BinarySearcherImpl searcher = new BinarySearcherImpl();

            // Act
            searcher.doBinaryDearch((Array)(object)multiArray, 3);
        }

        /// <summary>
        /// Helper class that does not implement IComparable
        /// </summary>
        private class NonComparable
        {
            public int Value { get; set; }
        }

        /// <summary>
        /// Tests that InvalidOperationException is thrown when value does not implement IComparable.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsInvalidOperationException_WhenValueIsNotComparable()
        {
            // Arrange
            object[] inputArray = { new NonComparable(), new NonComparable() };
            NonComparable target = new NonComparable();

            BinarySearcherImpl searcher = new BinarySearcherImpl();

            // Act
            searcher.doBinaryDearch(inputArray, target);
        }
    }
}

// ==========================
// Main Code with Exceptions
// ==========================

namespace BinarySearcher
{
    public class BinarySearcherImpl
    {
        public int doBinaryDearch(Array array, object value)
        {
            // ArgumentNullException
            if (array == null)
                throw new ArgumentNullException(nameof(array), "Input array cannot be null.");

            // RankException
            if (array.Rank != 1)
                throw new RankException("Only single-dimensional arrays are supported.");

            // ArgumentException
            Type elementType = array.GetType().GetElementType();
            if (value != null && !elementType.IsAssignableFrom(value.GetType()))
                throw new ArgumentException("Value type is not compatible with the array elements.");

            // InvalidOperationException for value
            if (value != null && !(value is IComparable))
                throw new InvalidOperationException("Value must implement IComparable.");

            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                object midVal = array.GetValue(mid);

                if (midVal == null || !(midVal is IComparable))
                    throw new InvalidOperationException("Array element does not implement IComparable.");

                IComparable comparer = (IComparable)midVal;
                int cmp = comparer.CompareTo(value);

                if (cmp == 0)
                    return mid;
                else if (cmp < 0)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            // Not found: return bitwise complement of insertion index
            return ~low;
        }
        [TestMethod]
        public void ElementFoundForRangeOK() {
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            //inputArray.Add
          
            int elementToFind = 0;
            int actual = Array.BinarySearch(inputArray, 1,5,elementToFind);

        }
    }
}
