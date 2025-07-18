using BinarySearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySearcherTests
{
    // Tests for BinarySearcherImpl covering typical cases and edge scenarios.
    [TestClass]
    public sealed class TestBinarySearch
    {
        //This test should return the correct index when the element is in the array.
        [TestMethod]
        public void ElementFoundTest()
        {
            // Arrange
            int[] inputArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int elementToFind = 5;
            int expectedIndex = 4;
            // Act
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualResult = SUT.doBinarySearch(inputArray, elementToFind);
            // Assert
            Assert.AreEqual(expectedIndex, actualResult);
        }

        //This testcase should return bitwise complement of the index where the element should be inserted.
        [TestMethod]
        public void ElementNotFoundButLessthanTest()
        {
            // Arrange
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            int elementToFind = 5;
            int expectedIndex = ~4;
            // Act
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualResult = SUT.doBinarySearch(inputArray, elementToFind);
            // Assert
            Assert.AreEqual(expectedIndex, actualResult);
        }

        //This testcase should return insertion index if the element is greater than all values.
        [TestMethod]
        public void ElementNotFoundButGreaterThanAllTest()
        {
            // Arrange
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            int elementToFind = 15;
            int expectedIndex = ~inputArray.Length;
            // Act
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualResult = SUT.doBinarySearch(inputArray, elementToFind);
            // Assert
            Assert.AreEqual(expectedIndex, actualResult);
        }

        //This testcase should throw ArgumentNullException if the array is null.
        [TestMethod]
        public void NullArrayThrowsArgumentNullException()
        {
            // Arrange
            int[] inputArray = null;
            int elementToFind = 3;
            // Act + Assert
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                SUT.doBinarySearch(inputArray, elementToFind);
            });
        }

        //This testcase should throw RankException for multidimensional arrays.
        [TestMethod]
        public void MultidimensionalArrayThrowsRankException()
        {
            // Arrange
            Array multiArray = Array.CreateInstance(typeof(int), new int[] { 2, 2 }, new int[] { 0, 0 });
            // Act + Assert
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            Assert.ThrowsException<RankException>(() =>
            {
                SUT.doBinarySearch(multiArray, 3);
            });
        }

        //This testcase should return a valid index when duplicate elements are present.
        [TestMethod]
        public void ElementWithDuplicatesTest()
        {
            // Arrange
            int[] inputArray = { 1, 2, 4, 4, 4, 5, 6 };
            int elementToFind = 4;
            int[] validIndices = { 2, 3, 4 };
            // Act
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualResult = SUT.doBinarySearch(inputArray, elementToFind);
            // Assert
            CollectionAssert.Contains(validIndices, actualResult);
        }
    }
}
