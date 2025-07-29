using BinarySearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            int actualIndex = searcher.doBinarySearch(inputArray, target);

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
            int actualIndex = searcher.doBinarySearch(inputArray, target);

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
            int actualIndex = searcher.doBinarySearch(inputArray, target);

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
            searcher.doBinarySearch(inputArray, target);
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
            searcher.doBinarySearch((Array)(object)multiArray, 3);
        }

        /// <summary>
        /// Tests that InvalidOperationException is thrown when value type is incompatible.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsInvalidOperationException_WhenValueTypeIsIncompatible()
        {
            // Arrange
            string[] inputArray = { "a", "b", "c" };
            int target = 1;

            BinarySearcherImpl searcher = new BinarySearcherImpl();

            // Act
            searcher.doBinarySearch(inputArray, target);
        }

        /// <summary>
        /// Helper class that does not implement IComparable.
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
            searcher.doBinarySearch(inputArray, target);
        }
    }
}