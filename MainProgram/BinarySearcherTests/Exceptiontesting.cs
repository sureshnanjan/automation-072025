using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BinarySearcher;

namespace BinarySearcherTests
{
    public class NonComparableClass
    {
        public int Value = 5;
    }

    [TestClass]
    public sealed class ExceptionTesting
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearch_NullArray_ThrowsArgumentNullException()
        {
            int[] inputArray = null!;
            int elementToFind = 3;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            SUT.DoBinarySearch(inputArray, elementToFind);
        }

        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void BinarySearch_MultidimensionalArray_ThrowsRankException()
        {
            Array multiArray = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            int elementToFind = 3;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            SUT.DoBinarySearch(multiArray, elementToFind);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinarySearch_IncompatibleType_ThrowsArgumentException()
        {
            object[] inputArray = { "one", "two", "three" }; // string array
            int elementToFind = 3; // incompatible type

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            SUT.DoBinarySearch(inputArray, elementToFind);
        }

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
