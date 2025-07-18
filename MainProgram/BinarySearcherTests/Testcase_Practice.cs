using BinarySearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySearcherTests
{
    /// <summary>
    /// Contains unit tests that validate exception handling behavior
    /// of the <see cref="BinarySearcherImpl.doBinaryDearch"/> method.
    /// </summary>
    [TestClass]
    public class ExceptionTests
    {
        /// <summary>
        /// Tests that <see cref="ArgumentNullException"/> is thrown when the input array is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsArgumentNullExceptionWhenArrayIsNull()
        {
            var searcher = new BinarySearcherImpl();
            searcher.doBinaryDearch(null, 5);
        }

        /// <summary>
        /// Tests that <see cref="RankException"/> is thrown when the input array is multidimensional.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void ThrowsRankExceptionWhenArrayIsMultidimensional()
        {
            var searcher = new BinarySearcherImpl();
            int[,] multiArray = new int[2, 2];
            searcher.doBinaryDearch(multiArray, 5);
        }

        /// <summary>
        /// Tests that <see cref="InvalidOperationException"/> is thrown when an incompatible type is used for search.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsArgumentExceptionForIncompatibleType()
        {
            var searcher = new BinarySearcherImpl();
            int[] array = { 1, 2, 3 };
            searcher.doBinaryDearch(array, "string");
        }

        /// <summary>
        /// Tests that <see cref="InvalidOperationException"/> is thrown when the value being searched does not implement a comparison mechanism.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsInvalidOperationExceptionWhenValueNotComparable()
        {
            var searcher = new BinarySearcherImpl();
            object[] array = { new object(), new object() };
            searcher.doBinaryDearch(array, new object());
        }
    }
}

