using BinarySearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_BinarySearchWithComparer_CountExceedsBounds_ThrowsException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 10, 20, 30, 40, 50 };
            int startIndex = 3;
            int count = 5;
            object key = 50;
            DefiningComparer comparer = new DefiningComparer();

            // Act
            int index = SUT.doBinarySearchWithComparer(arr, startIndex, count, key, comparer);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_BinarySearchWithComparer_NullKey_ThrowsException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "apple", "banana", "cherry" };
            int startIndex = 0;
            int count = 3;
            object? key = null;
            DefiningComparer comparer = new DefiningComparer();

            // Act
            int index = SUT.doBinarySearchWithComparer(arr, startIndex, count, key, comparer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_BinarySearchWithComparer_IndexLessThanZero_ThrowsException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 10, 20, 30 };
            int startIndex = -1; // Invalid index
            int count = 2;
            object key = 20;
            DefiningComparer comparer = new DefiningComparer();

            // Act
            int index = SUT.doBinarySearchWithComparer(arr, startIndex, count, key, comparer);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_BinarySearchWithComparer_CountLessThanZero_ThrowsException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 5, 10, 15 };
            int startIndex = 0;
            int count = -1; // Invalid count
            object key = 10;
            DefiningComparer comparer = new DefiningComparer();

            // Act
            int index = SUT.doBinarySearchWithComparer(arr, startIndex, count, key, comparer);
        }

    }
    
    //BinarySearch(Array, Object, IComparer)
    [TestClass]
    public class BinarySearch_ArrayObjectIComparer_Tests
    {
        [TestMethod]
        public void Test_BinarySearch_ArrayObjectIComparer_IntArray()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 1, 2, 3, 4, 5 };
            DefiningComparer comparer = new DefiningComparer();

            // Act
            int result = SUT.DoBinarySearchWithComparerWithoutRange(arr, 4, comparer);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_BinarySearch_ArrayObjectIComparer_StringArray()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "cat", "dog", "lion", "tiger" };
            DefiningComparer comparer = new DefiningComparer();

            // Act
            int result = SUT.DoBinarySearchWithComparerWithoutRange(arr, "dog", comparer);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_BinarySearch_ArrayIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[]? arr = null;
            DefiningComparer comparer = new DefiningComparer();

            // Act
            int result = SUT.DoBinarySearchWithComparerWithoutRange(arr!, 4, comparer);

            // Assert: handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void Test_BinarySearch_MultidimensionalArray_ThrowsRankException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[,] arr = { { 1, 2 }, { 3, 4 } }; // 2D array
            DefiningComparer comparer = new DefiningComparer();

            // Act
            int result = SUT.DoBinarySearchWithComparerWithoutRange(arr, 3, comparer);

            // Assert: handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_BinarySearch_IncompatibleTypesWithNullComparer_ThrowsInvalidOperationException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "a", "b", "c" };
            object key = 100; // incompatible type
            IComparer? comparer = null;

            // Act
            int result = SUT.DoBinarySearchWithComparerWithoutRange(arr, key, comparer!);

            // Assert: handled by ExpectedException
        }

        public class Dummy { } // Does NOT implement IComparable

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_BinarySearch_NonComparableElementsWithNullComparer_ThrowsInvalidOperationException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            Dummy[] arr = { new Dummy(), new Dummy() };
            object key = new Dummy();
            IComparer? comparer = null;

            // Act
            int result = SUT.DoBinarySearchWithComparerWithoutRange(arr, key, comparer!);

            // Assert: handled by ExpectedException
        }
    }

    //BinarySearch(Array, Int32, Int32, Object)
    [TestClass]
    public class BinarySearch_ArrayRangeObject_Tests
    {
        [TestMethod]
        public void Test_BinarySearch_ArrayRangeObject_IntArray()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 10, 20, 30, 40, 50 };

            // Act
            int result = SUT.DoBinarySearchWithRange(arr, 1, 3, 40);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_BinarySearch_ArrayRangeObject_StringArray()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "a", "b", "c", "d", "e" };

            // Act
            int result = SUT.DoBinarySearchWithRange(arr, 1, 3, "d");

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_BinarySearch_Throws_ArgumentNullException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = null;

            // Act
            SUT.DoBinarySearchWithRange(arr, 0, 1, "a");

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void Test_BinarySearch_Throws_RankException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[,] arr = { { 1, 2 }, { 3, 4 } }; // multidimensional array

            // Act
            SUT.DoBinarySearchWithRange(arr, 0, 1, 3);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_BinarySearch_Throws_ArgumentOutOfRangeException_NegativeIndex()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 1, 2, 3 };

            // Act
            SUT.DoBinarySearchWithRange(arr, -1, 2, 2);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_BinarySearch_Throws_ArgumentOutOfRangeException_NegativeLength()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 1, 2, 3 };

            // Act
            SUT.DoBinarySearchWithRange(arr, 0, -1, 2);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_BinarySearch_Throws_ArgumentException_InvalidRange()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 1, 2, 3 };

            // Act
            SUT.DoBinarySearchWithRange(arr, 2, 5, 2); // index + length > array.Length

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_BinarySearch_Throws_ArgumentException_IncompatibleValue()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "a", "b", "c" };

            // Act
            SUT.DoBinarySearchWithRange(arr, 0, 3, 123); // value is int, array is string

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_BinarySearch_Throws_InvalidOperationException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            object[] arr = { new object(), new object() }; // objects not implementing IComparable

            // Act
            SUT.DoBinarySearchWithRange(arr, 0, 2, new object());

            // Assert is handled by ExpectedException
        }
    }

    //BinarySearch<T>(T[], T)
    [TestClass]
    public class BinarySearch_Generic_TArray_Tests
    {
        [TestMethod]
        public void Test_BinarySearch_GenericTArray_IntArray()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 11, 22, 33, 44 };

            // Act
            int result = SUT.DoGenericBinarySearch(arr, 33);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_GenericTArray_StringArray()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "apple", "banana", "mango" };

            // Act
            int result = SUT.DoGenericBinarySearch(arr, "banana");

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_BinarySearch_GenericTArray_Throws_ArgumentNullException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = null;

            // Act
            SUT.DoGenericBinarySearch(arr, 10);

            // Assert handled by ExpectedException
        }

        private class NonComparableType
        {
            public int Value { get; set; }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_BinarySearch_GenericTArray_Throws_InvalidOperationException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            NonComparableType[] arr = {
            new NonComparableType { Value = 1 },
            new NonComparableType { Value = 2 },
            new NonComparableType { Value = 3 }
        };

            // Act
            SUT.DoGenericBinarySearch(arr, new NonComparableType { Value = 2 });

            // Assert handled by ExpectedException
        }
    }

    //BinarySearch<T>(T[], T, IComparer<T>)
    [TestClass]
    public class BinarySearch_GenericWithComparer_Tests
    {
        [TestMethod]
        public void Test_BinarySearch_GenericWithComparer_IntArray()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 1, 3, 5, 7 };

            // Act
            int result = SUT.DoGenericBinarySearchWithComparer(arr, 5, Comparer<int>.Default);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_GenericWithComparer_StringArray()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "ant", "bear", "cat" };

            // Act
            int result = SUT.DoGenericBinarySearchWithComparer(arr, "cat", Comparer<string>.Default);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_BinarySearch_GenericWithComparer_Throws_ArgumentNullException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = null;

            // Act
            SUT.DoGenericBinarySearchWithComparer(arr, 5, Comparer<int>.Default);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_BinarySearch_GenericWithComparer_Throws_ArgumentException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "one", "two", "three" };
            object value = 5;
            // Act
            // Pass an int to a string array without a comparer — incompatible types
            SUT.DoGenericBinarySearchWithComparer<object>(arr, value, null);

            // Assert is handled by ExpectedException
        }

    }


    // BinarySearch<T>(T[], int, int, T)
    [TestClass]
    public class BinarySearch_GenericRange_Tests
    {
        [TestMethod]
        public void Test_BinarySearch_GenericRange_IntArray()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 10, 20, 30, 40, 50 };

            // Act
            int result = SUT.DoGenericBinarySearchWithRange(arr, 1, 3, 30);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_GenericRange_StringArray()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            string[] arr = { "a", "b", "c", "d", "e" };

            // Act
            int result = SUT.DoGenericBinarySearchWithRange(arr, 1, 3, "d");

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_BinarySearch_GenericRange_Throws_ArgumentNullException()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[]? arr = null;

            // Act
            SUT.DoGenericBinarySearchWithRange(arr, 0, 1, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_BinarySearch_GenericRange_Throws_ArgumentOutOfRangeException_IndexTooLow()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 1, 2, 3 };

            // Act
            SUT.DoGenericBinarySearchWithRange(arr, -1, 2, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_BinarySearch_GenericRange_Throws_ArgumentOutOfRangeException_NegativeLength()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 1, 2, 3 };

            // Act
            SUT.DoGenericBinarySearchWithRange(arr, 1, -1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_BinarySearch_GenericRange_Throws_ArgumentException_InvalidRange()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int[] arr = { 1, 2, 3 };

            // Act
            SUT.DoGenericBinarySearchWithRange(arr, 2, 5, 2); // range goes out of bounds
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_BinarySearch_GenericRange_Throws_InvalidOperationException_IncompatibleValue()
        {
            // Arrange
            BinarySearcherImpl SUT = new BinarySearcherImpl();
            object[] arr = { "a", "b", "c" };

            // Act
            SUT.DoGenericBinarySearchWithRange(arr, 0, 3, 10); // int is incompatible with string[]
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