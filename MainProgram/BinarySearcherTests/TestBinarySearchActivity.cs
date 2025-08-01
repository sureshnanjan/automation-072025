/*Copyright(c) 2025 Elangovan R
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
*The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace BinarySearchFrameworkTests
{
    /// <summary>
    /// Unit tests for all overloads of Array.BinarySearch and Array.BinarySearch<T>
    /// Covers typical use cases, edge cases, custom comparers, and subrange searches.
    /// </summary>
    [TestClass]
    public sealed class ArrayBinarySearchTests
    {
        // =======================================
        // 1. Array.BinarySearch(Array, Object)
        // =======================================
        // Use this when:
        // You want to search a sorted one-dimensional array using the default comparison logic.

        [TestMethod]
        public void Test_BinarySearch_Array_Object_Found()
        {
            string[] fruits = { "Apple", "Banana", "Mango", "Orange" };
            int index = Array.BinarySearch(fruits, "Mango");
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void Test_BinarySearch_Array_Object_NotFound()
        {
            int[] arr = { 10, 20, 30, 40 };
            int result = Array.BinarySearch(arr, 25);
            Assert.AreEqual(~2, result); // Would be inserted at index 2
        }

        [TestMethod]
        public void Test_BinarySearch_EmptyArray()
        {
            int[] arr = { };
            int result = Array.BinarySearch(arr, 10);
            Assert.AreEqual(~0, result);
        }

        [TestMethod]
        public void Test_BinarySearch_SingleElement_Found()
        {
            int[] arr = { 100 };
            int result = Array.BinarySearch(arr, 100);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_BinarySearch_SingleElement_NotFound()
        {
            int[] arr = { 99 };
            int result = Array.BinarySearch(arr, 100);
            Assert.AreEqual(~1, result);
        }

        // ================================================
        // 2. Array.BinarySearch(Array, Object, IComparer)
        // ================================================
        // 📌 Use this when:
        // You want to search a sorted array using a custom comparer.

        [TestMethod]
        public void Test_BinarySearch_Array_Object_CustomComparer()
        {
            string[] arr = { "Orange", "Mango", "Banana", "Apple" };
            int result = Array.BinarySearch(arr, "Banana", new DescComparer());
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Array_Object_CustomComparer_NotFound()
        {
            string[] arr = { "Z", "Y", "X" };
            int result = Array.BinarySearch(arr, "A", new DescComparer());
            Assert.AreEqual(~3, result);
        }

        // ========================================================
        // 3. Array.BinarySearch(Array, Int32, Int32, Object)
        // ========================================================
        // 📌 Use this when:
        // You want to search a subrange of a sorted array.

        [TestMethod]
        public void Test_BinarySearch_Range_Found()
        {
            string[] arr = { "A", "B", "C", "D", "E" };
            int result = Array.BinarySearch(arr, 1, 3, "D");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Range_NotFound()
        {
            int[] arr = { 1, 3, 5, 7, 9 };
            int result = Array.BinarySearch(arr, 1, 3, 4);
            Assert.AreEqual(~2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Range_ElementOutsideButInArray()
        {
            int[] arr = { 5, 10, 15, 20, 25 };
            int result = Array.BinarySearch(arr, 1, 2, 25); // 10, 15
            Assert.AreEqual(~3, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Range_ElementAtStart()
        {
            string[] arr = { "A", "B", "C", "D", "E" };
            int result = Array.BinarySearch(arr, 1, 3, "B");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Range_ElementAtEnd()
        {
            int[] arr = { 2, 4, 6, 8, 10 };
            int result = Array.BinarySearch(arr, 1, 3, 8);
            Assert.AreEqual(3, result);
        }

        // =============================================================
        // 4. Array.BinarySearch(Array, Int32, Int32, Object, IComparer)
        // =============================================================
        // 📌 Use this when:
        // You want to search a subrange using custom comparison logic.

        [TestMethod]
        public void Test_BinarySearch_Range_CustomComparer()
        {
            string[] arr = { "Z", "X", "M", "C", "A" };
            int result = Array.BinarySearch(arr, 1, 3, "M", new DescComparer());
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Range_CustomComparer_ElementOutside()
        {
            string[] arr = { "Z", "X", "M", "C", "A" };
            int result = Array.BinarySearch(arr, 1, 2, "A", new DescComparer());
            Assert.AreEqual(~3, result);
        }

        // ===========================================
        // 5. Array.BinarySearch<T>(T[], T)
        // ===========================================
        // 📌 Use this when:
        // You want to search a generic typed sorted array using default comparer.

        [TestMethod]
        public void Test_BinarySearch_Generic_Found()
        {
            int[] arr = { 10, 20, 30, 40 };
            int result = Array.BinarySearch<int>(arr, 30);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_InsertAtStart()
        {
            int[] arr = { 10, 20, 30 };
            int result = Array.BinarySearch<int>(arr, 5);
            Assert.AreEqual(~0, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_InsertAtEnd()
        {
            int[] arr = { 10, 20, 30 };
            int result = Array.BinarySearch<int>(arr, 35);
            Assert.AreEqual(~3, result);
        }

        // ===================================================
        // 6. Array.BinarySearch<T>(T[], T, IComparer<T>)
        // ===================================================
        // 📌 Use this when:
        // You want to search a generic array using a custom comparer.

        [TestMethod]
        public void Test_BinarySearch_Generic_CustomComparer()
        {
            int[] arr = { 100, 90, 80, 70 };
            int result = Array.BinarySearch<int>(arr, 90, new DescIntComparer());
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_CustomComparer_NotFound()
        {
            int[] arr = { 100, 90, 80, 70 };
            int result = Array.BinarySearch<int>(arr, 85, new DescIntComparer());
            Assert.AreEqual(~2, result);
        }

        // ===============================================================
        // 7. Array.BinarySearch<T>(T[], Int32, Int32, T)
        // ===============================================================
        // 📌 Use this when:
        // You want to search a specific range of a generic array.

        [TestMethod]
        public void Test_BinarySearch_Generic_Range()
        {
            int[] arr = { 1, 3, 5, 7, 9 };
            int result = Array.BinarySearch<int>(arr, 1, 3, 5);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_Range_ValueOutsideRange()
        {
            int[] arr = { 10, 20, 30, 40, 50 };
            int result = Array.BinarySearch<int>(arr, 1, 2, 50); // Range: 20,30
            Assert.AreEqual(~3, result);
        }

        // ========================================================================
        // 8. Array.BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>)
        // ========================================================================
        // 📌 Use this when:
        // You want to search a generic typed subrange with custom comparison logic.

        [TestMethod]
        public void Test_BinarySearch_Generic_Range_CustomComparer()
        {
            int[] arr = { 100, 90, 80, 70, 60 };
            int result = Array.BinarySearch<int>(arr, 1, 3, 80, new DescIntComparer());
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_ReverseOrder_Missing()
        {
            int[] arr = { 100, 90, 80, 70 };
            int result = Array.BinarySearch<int>(arr, 1, 2, 75, new DescIntComparer()); // 90, 80
            Assert.AreEqual(~2, result);
        }
    }

    /// <summary>
    /// Descending comparer for non-generic Array.BinarySearch (IComparer).
    /// </summary>
    public class DescComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return Comparer.Default.Compare(y, x); // Reverse logic for descending order
        }
    }

    /// <summary>
    /// Descending comparer for generic Array.BinarySearch<T> (IComparer<T>).
    /// </summary>
    public class DescIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x); // Reverse logic for descending order
        }
    }
}
