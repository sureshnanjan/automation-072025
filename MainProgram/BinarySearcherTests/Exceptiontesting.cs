using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BinarySearcher;

namespace BinarySearcherTests
{
    /// <summary>
    /// A sample class without IComparable implementation, 
    /// used to test handling of non-comparable types in binary search.
    /// </summary>
    public class NonComparableClass
    {
        public int Value = 5;
    }

    /// <summary>
    /// Contains unit tests that ensure the BinarySearcherImpl class correctly throws exceptions
    /// when given invalid inputs or inputs that violate binary search assumptions.
    /// </summary>
    [TestClass]
    public sealed class ExceptionTesting
    {
        /// <summary>
        /// Verifies that a null array input throws an ArgumentNullException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearch_NullArray_ThrowsArgumentNullException()
        {
            int[] inputArray = null!;
            int elementToFind = 3;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            SUT.DoBinarySearch(inputArray, elementToFind);
        }

        /// <summary>
        /// Verifies that passing a multi-dimensional array throws a RankException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void BinarySearch_MultidimensionalArray_ThrowsRankException()
        {
            Array multiArray = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            int elementToFind = 3;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            SUT.DoBinarySearch(multiArray, elementToFind);
        }

        /// <summary>
        /// Verifies that passing an array with elements of a different type than the search key 
        /// throws an InvalidOperationException due to incompatible types.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinarySearch_IncompatibleType_ThrowsArgumentException()
        {
            object[] inputArray = { "one", "two", "three" }; // string array
            int elementToFind = 3; // incompatible type

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            SUT.DoBinarySearch(inputArray, elementToFind);
        }

        /// <summary>
        /// Verifies that an array of non-comparable objects causes an InvalidOperationException 
        /// when trying to perform binary search.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinarySearch_NonComparableType_ThrowsInvalidOperationException()
        {
            var inputArray = new NonComparableClass[]
            {
                new NonComparableClass(),
                new NonComparableClass()
            };
            var elementToFind = new NonComparableClass();

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            SUT.DoBinarySearch(inputArray, elementToFind);
        }
    }
}
