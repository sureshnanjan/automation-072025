using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
namespace BinarySearcherTests.ExceptionTests  // Organize tests logically by namespace
{
    [TestClass]  
    public class TestBinarySearchExceptions
    {
        // Test: Null array input should throw ArgumentNullException
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearch_ArrayIsNull_ThrowsArgumentNullException()
        {
            int[] array = null;                // Passing null as the array
            int valueToSearch = 3;
            Array.BinarySearch(array, valueToSearch);  // Should throw exception
        }

        // Test: Multidimensional array should throw RankException
        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void BinarySearch_ArrayIsMultidimensional_ThrowsRankException()
        {
            int[,] array = new int[,] { { 1, 2 }, { 3, 4 } };  // 2D array is invalid
            int valueToSearch = 3;
            Array.BinarySearch(array, valueToSearch);         // Should throw exception
        }

        // Test: Searching with incompatible type should throw InvalidOperationException
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinarySearch_ValueIncompatibleType_ThrowsInvalidOperationException()
        {
            string[] array = { "a", "b", "c" };    // Array of strings
            int valueToSearch = 3;                // Searching for an int — type mismatch
            Array.BinarySearch(array, valueToSearch); // Should throw exception
        }

        // Helper class without IComparable — can't be compared
        class NonComparable { public int Id { get; set; } }

        // Test: Objects not implementing IComparable throw InvalidOperationException
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinarySearch_ValueNotComparable_ThrowsInvalidOperationException()
        {
            var array = new NonComparable[]       // Array of custom type
            {
                new NonComparable { Id = 1 },
                new NonComparable { Id = 2 }
            };

            var valueToSearch = new NonComparable { Id = 2 };
            Array.BinarySearch(array, valueToSearch);  // Should throw exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BinarySearch_InvalidRange_ThrowsArgumentOutOfRangeException()
        {
            int[] MyArray = { 10, 20, 30, 40, 25, 35, 45, 50 };  // Valid array
            int StartIndex = 1;      // Start at index 1
            int length = 8;          // Length goes beyond array bounds (index 1 + 8 > 8)
            int ToFind = 35;
            int index = Array.BinarySearch(MyArray, StartIndex, length, ToFind, Comparer.Default); // Throws
        }
    }
}

