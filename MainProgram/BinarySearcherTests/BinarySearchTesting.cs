using BinarySearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace TestingBinarySearchTypes
{
    [TestClass]
    //using BinarySearch(Array, Int32, Int32, Object, IComparer)
    public sealed class TestingBinarySearchwithComparer
    {
      [TestMethod]
      public void Test_BinarySearchWithAscendingComparer_ReturnsCorrectIndex()
        {
            //Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 10, 20, 30, 40, 50, 60 };
            int startIndex = 1;
            int count = 4;
            object key = 40;
            DefiningComparer comparer = new DefiningComparer();
            // Act
            int index = SUT.doBinarySearchWithComparer(arr, startIndex, count, key, comparer);

            // Assert
            Assert.AreEqual(3, index); // 40 is at index 3 in arr
        }
        [TestMethod]
        public void Test_BinarySearchWithAscendingComparer_StringArray_ReturnsCorrectIndex()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "apple", "banana", "cherry", "date", "fig", "grape" };
            int startIndex = 1;
            int count = 4;
            object key = "date";
            DefiningComparer comparer = new DefiningComparer();

            // Act
            int index = SUT.doBinarySearchWithComparer(arr, startIndex, count, key, comparer);

            // Assert
            Assert.AreEqual(3, index); // "date" is at index 3 in arr
        }


        [TestMethod]
        public void Test_BinarySearchWithAscendingComparer_EmptyArray_ReturnsNegativeOne()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = new int[] { };
            int startIndex = 0;
            int count = 0;
            object key = 10;
            DefiningComparer comparer = new DefiningComparer();

            // Act
            int index = SUT.doBinarySearchWithComparer(arr, startIndex, count, key, comparer);

            // Assert
            Assert.AreEqual(-1, index); // Not found in empty array
        }
    }
    //BinarySearch(Array, Object, IComparer)
    [TestClass]
    public class BinarySearch_ArrayObjectIComparer_Tests
    {
        [TestMethod]
        public void Test_BinarySearch_ArrayObjectIComparer_IntArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 1, 2, 3, 4, 5 };
            DefiningComparer comparer = new DefiningComparer();
            var result = SUT.DoBinarySearchWithComparerWithoutRange(arr, 4, comparer);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_BinarySearch_ArrayObjectIComparer_StringArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "cat", "dog", "lion", "tiger" };
            DefiningComparer comparer = new DefiningComparer();
            var result = SUT.DoBinarySearchWithComparerWithoutRange(arr, "dog", comparer);
            Assert.AreEqual(1, result);
        }
    }
    //BinarySearch(Array, Int32, Int32, Object)
    [TestClass]
    public class BinarySearch_ArrayRangeObject_Tests
    {
        [TestMethod]
        public void Test_BinarySearch_ArrayRangeObject_IntArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 10, 20, 30, 40, 50 };
            int result = SUT.DoBinarySearchWithRange(arr, 1, 3, 40);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_BinarySearch_ArrayRangeObject_StringArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "a", "b", "c", "d", "e" };
            int result = SUT.DoBinarySearchWithRange(arr, 1, 3, "d");
            Assert.AreEqual(3, result);
        }
    }
    //BinarySearch<T>(T[], T)
    [TestClass]
    public class BinarySearch_Generic_TArray_Tests
    {
        [TestMethod]
        public void Test_BinarySearch_GenericTArray_IntArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 11, 22, 33, 44 };
            int result = SUT.DoGenericBinarySearch(arr, 33);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_GenericTArray_StringArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "apple", "banana", "mango" };
            int result = SUT.DoGenericBinarySearch(arr, "banana");
            Assert.AreEqual(1, result);
        }
    }
    //BinarySearch<T>(T[], T, IComparer<T>)
    [TestClass]
    public class BinarySearch_GenericWithComparer_Tests
    {
        [TestMethod]
        public void Test_BinarySearch_GenericWithComparer_IntArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 1, 3, 5, 7 };
            int result = SUT.DoGenericBinarySearchWithComparer(arr, 5, Comparer<int>.Default);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_GenericWithComparer_StringArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "ant", "bear", "cat" };
            int result = SUT.DoGenericBinarySearchWithComparer(arr, "cat", Comparer<string>.Default);
            Assert.AreEqual(2, result);
        }
    }

    //BinarySearch<T>(T[], int, int, T)
    [TestClass]
    public class BinarySearch_GenericRange_Tests
    {
        [TestMethod]
        public void Test_BinarySearch_GenericRange_IntArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 10, 20, 30, 40, 50 };
            int result = SUT.DoGenericBinarySearchWithRange(arr, 1, 3, 30);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_GenericRange_StringArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "a", "b", "c", "d", "e" };
            int result = SUT.DoGenericBinarySearchWithRange(arr, 1, 3, "d");
            Assert.AreEqual(3, result);
        }
    }

    //BinarySearch<T>(T[], int, int, T, IComparer<T>)
    [TestClass]
    public class BinarySearch_GenericRangeComparer_Tests
    {
        [TestMethod]
        public void Test_BinarySearch_GenericRangeComparer_IntArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 2, 4, 6, 8, 10 };
            int result = SUT.DoGenericBinarySearchWithRangeComparer(arr, 1, 3, 6, Comparer<int>.Default);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_GenericRangeComparer_StringArray()
        {
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "blue", "green", "orange", "red", "yellow" };
            int result = SUT.DoGenericBinarySearchWithRangeComparer(arr, 1, 3, "red", Comparer<string>.Default);
            Assert.AreEqual(3, result);
        }
    }

}