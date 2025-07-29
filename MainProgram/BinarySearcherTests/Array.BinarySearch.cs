using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySearchExamples
{
    [TestClass]
    public class BinarySearchTests
    {
    
        /// Test for exact match in a sorted array
 
        [TestMethod]
        public void BinarySearch_String_Found()
        {
            string[] fruits = { "Apple", "Banana", "Mango" };
            int Expected_index = 1; // Expected index for "Banana"
            int Actual_index = Array.BinarySearch(fruits, "Banana");
            Assert.AreEqual(Expected_index, Actual_index);
        }



        /// <summary>
        /// Test for a value that does not exist
        /// </summary>
        [TestMethod]
        public void BinarySearch_String_NotFound()
        {
            string[] fruits = { "Apple", "Banana", "Mango" };
            int index = Array.BinarySearch(fruits, "Cherry");
            Assert.IsTrue(index < 0); // Not found
        }

        /// <summary>
        /// Test for the first item in the array
        /// </summary>
        [TestMethod]
        public void BinarySearch_FirstItem()
        {
            string[] fruits = { "Apple", "Banana", "Mango" };
            int Expected_index = 0; // Expected index for "Apple"
            int index = Array.BinarySearch(fruits, "Apple");
            Assert.AreEqual(Expected_index, index);
        }

        /// <summary>
        /// Test for the last item in the array
        /// </summary>
        [TestMethod]
        public void BinarySearch_LastItem()
        {
            string[] fruits = { "Apple", "Banana", "Mango" };
            int index = Array.BinarySearch(fruits, "Mango");
            Assert.AreEqual(2, index);
        }

        /// <summary>
        /// Test with integers
        /// </summary>
        [TestMethod]
        public void BinarySearch_Integer_Found()
        {
            int[] numbers = { 1, 3, 5, 7, 9 };
            int Expected_index = 2; // Expected index for 5
            int Actual_index = Array.BinarySearch(numbers, 5);
            Assert.AreEqual(Expected_index, Actual_index);
        }

        /// <summary>
        /// Test for missing element in numeric array
        /// </summary>
        [TestMethod]
        public void BinarySearch_Integer_NotFound()
        {
            int[] numbers = { 1, 3, 5, 7, 9 };
            int index = Array.BinarySearch(numbers, 4);
            Assert.IsTrue(index < 0);
        }

        /// <summary>
        /// Test with unsorted array (invalid use case)
        /// </summary>
        [TestMethod]
        public void BinarySearch_UnsortedArray_ReturnsInvalid()
        {
            string[] fruits = { "Mango", "Apple", "Banana" }; // Not sorted
            int index = Array.BinarySearch(fruits, "Banana");
            // Cannot guarantee result; it may be incorrect
            Assert.IsTrue(index < 0, "Unsorted array may return invalid index.");
        }
    }
}
