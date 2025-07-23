using BinarySearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySearcherTests
{
    [TestClass]
    public class Testcase_Practice
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsArgumentNullExceptionWhenArrayIsNull()
        {
            var searcher = new BinarySearcherImpl();
            object value = searcher.doBinarySearch(null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void ThrowsRankExceptionWhenArrayIsMultidimensional()
        {
            var searcher = new BinarySearcherImpl();
            int[,] multiArray = new int[2, 2];
            searcher.doBinarySearch(multiArray, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsArgumentExceptionForIncompatibleType()
        {
            var searcher = new BinarySearcherImpl();
            int[] array = { 1, 2, 3 };
            searcher.doBinarySearch(array, "string");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsInvalidOperationExceptionWhenValueNotComparable()
        {
            var searcher = new BinarySearcherImpl();
            object[] array = { new object(), new object() };
            searcher.doBinarySearch(array, new object());
        }
    }
}