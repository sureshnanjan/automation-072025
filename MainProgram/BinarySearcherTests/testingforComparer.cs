using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySearcherTests
{
    // Dummy wrapper class; replace with your real implementation if any
    public class BinarySearcherImpl
    {
        public int doBinarySearch(Array array, int index, int length, object value)
        {
            // Call the Array.BinarySearch overload with range
            return Array.BinarySearch(array, index, length, value);
        }

        internal int doBinarySearch(int[] inputArray, int elementToFind)
        {
            throw new NotImplementedException();
        }

        internal void doBinarySearch(int[,] multiArray, int v)
        {
            throw new NotImplementedException();
        }

        internal void doBinarySearch(int[] array, string v)
        {
            throw new NotImplementedException();
        }

        internal void doBinarySearch(object[] array, object v)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass]
    public class BinarySearchRangeTests
    {
        private BinarySearcherImpl searcher;

        [TestInitialize]
        public void Setup()
        {
            searcher = new BinarySearcherImpl();
        }

        [TestMethod]
        public void Search_FindsValueInFullRange()
        {
            int[] sortedArray = { 1, 3, 5, 7, 9 };

            int valueToFind = 7;

            int index = searcher.doBinarySearch(sortedArray, 0, sortedArray.Length, valueToFind);

            Assert.AreEqual(3, index, "The value 7 should be found at index 3.");
        }

        [TestMethod]
        public void Search_FindsValueInPartialRange()
        {
            int[] sortedArray = { 1, 3, 5, 7, 9 };

            // Search only indices 1 to 3 (3,5,7)
            int valueToFind = 5;

            int index = searcher.doBinarySearch(sortedArray, 1, 3, valueToFind);

            Assert.AreEqual(2, index, "The value 5 should be found at index 2.");
        }

        [TestMethod]
        public void Search_ReturnsNegativeWhenValueNotFound()
        {
            int[] sortedArray = { 1, 3, 5, 7, 9 };

            int valueToFind = 4; // Not in array

            int index = searcher.doBinarySearch(sortedArray, 0, sortedArray.Length, valueToFind);

            Assert.IsTrue(index < 0, "Index should be negative when value not found.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Search_ThrowsWhenRangeIsInvalid()
        {
            int[] sortedArray = { 1, 3, 5 };

            // Length goes beyond array length
            searcher.doBinarySearch(sortedArray, 1, 5, 3);
        }
    }
}
