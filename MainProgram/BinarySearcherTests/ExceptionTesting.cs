using BinarySearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySearcherTests
{
    /// <summary>
    /// Contains unit tests to validate exception handling in the BinarySearcher implementation.
    /// </summary>
    [TestClass]
    public sealed class TestBinarySearchExceptions
    {
        /// <summary>
        /// Verifies that an ArgumentNullException is thrown when the input array is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsArgumentNullException_WhenArrayIsNull()
        {
            int[] inputArray = null;
            int elementToFind = 5;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            SUT.doBinaryDearch(inputArray, elementToFind);
        }

        /// <summary>
        /// Verifies that a RankException is thrown when a multidimensional array is passed.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void ThrowsRankException_WhenArrayIsMultidimensional()
        {
            int[,] multiDimArray = { { 1, 2 }, { 3, 4 } };
            object elementToFind = 2;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            // This cast is required because method expects Array, not specific type
            SUT.doBinaryDearch((Array)(object)multiDimArray, elementToFind);
        }

        /// <summary>
        /// Verifies that an InvalidOperationException is thrown when the element type is incompatible with the array type.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsArgumentException_WhenTypeIsIncompatible()
        {
            object[] inputArray = { "a", "b", "c" };
            object elementToFind = 5; // int in a string array

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            SUT.doBinaryDearch(inputArray, elementToFind);
        }

        /// <summary>
        /// Verifies that an InvalidOperationException is thrown when the objects in the array do not implement IComparable.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsInvalidOperationException_WhenObjectNotComparable()
        {
            object[] inputArray = { new object(), new object() };
            object elementToFind = new object();

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            SUT.doBinaryDearch(inputArray, elementToFind);
        }
    }
}
