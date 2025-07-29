using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearch
{
    [TestClass]
    public class BinarySearchOverloads
    {
        // 1. Array.BinarySearch(Array, Object)

        [TestMethod]
        public void Test_BinarySearch_Array_Object_Found()
        {
            // Arrange
            string[] fruits = { "Apple", "Banana", "Mango", "Orange" };
            int expectedIndex = 2;

            // Act
            int actualIndex = Array.BinarySearch(fruits, "Mango");

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestMethod]
        public void Test_BinarySearch_Array_Object_NotFound()
        {
            // Arrange
            int[] arr = { 10, 20, 30, 40 };

            // Act
            int result = Array.BinarySearch(arr, 25);

            // Assert
            Assert.AreEqual(~2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_EmptyArray()
        {
            // Arrange
            int[] arr = { };
            int expectedIndex = ~0; // Not found, should return negative index

            // Act
            int result = Array.BinarySearch(arr, 10);

            // Assert
            Assert.AreEqual(~0, result);
        }

        [TestMethod]
        public void Test_BinarySearch_SingleElement_Found()
        {
            // Arrange
            int[] arr = { 100 };
            int expectedIndex = 0;

            // Act
            int actualIndex = Array.BinarySearch(arr, 100);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestMethod]
        public void Test_BinarySearch_SingleElement_NotFound()
        {
            // Arrange
            int[] arr = { 99 };
            int expectedIndex = ~1; // Not found, should return negative index

            // Act
            int actualIndex = Array.BinarySearch(arr, 100);

            // Assert
            Assert.AreEqual(expectedIndex, actualIndex);
        }


        [TestMethod]
        public void Test_BinarySearch_Duplicates()
        {
            // Arrange
            int[] arr = { 1, 2, 2, 2, 3 };
            //int[] expectedRange = { 1, 2, 3 }; // Valid range for duplicates
            int expectedIndex = 2; // Any index of the duplicate value

            // Act
            int index = Array.BinarySearch(arr, 2);

            // Assert
            //Assert.IsTrue(index >= 1 && index <= 3, "Index should be within the range of duplicate values.");
            Assert.AreEqual(expectedIndex, index);
        }

        [TestMethod]
        public void Test_BinarySearch_NullReference()
        {
            // Arrange
            string[] arr = { null, "A", "B" };
            Array.Sort(arr);

            // Act
            int index = Array.BinarySearch(arr, null);

            // Assert
            Assert.IsTrue(index >= 0);
        }

        [TestMethod]
        public void Test_BinarySearch_UnsortedArray_Behavior()
        {
            // Arrange
            int[] arr = { 3, 1, 4, 2 };
            int expectedIndex = ~0; // Not found, should return negative index

            // Act
            int result = Array.BinarySearch(arr, 2);

            // Assert
            Assert.IsTrue(result < 0); // result is undefined
        }

        // 2. Array.BinarySearch(Array, Object, IComparer)

        [TestMethod]
        public void Test_BinarySearch_Array_Object_CustomComparer()
        {
            // Arrange
            string[] arr = { "Orange", "Mango", "Banana", "Apple" };

            // Act
            int result = Array.BinarySearch(arr, "Banana", new DescComparer());

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Array_Object_CustomComparer_NotFound()
        {
            // Arrange
            string[] arr = { "Z", "Y", "X" };

            // Act
            int result = Array.BinarySearch(arr, "A", new DescComparer());

            // Assert
            Assert.AreEqual(~3, result);
        }

        // 3. Array.BinarySearch(Array, Int32, Int32, Object)

        [TestMethod]
        public void Test_BinarySearch_Range_Found()
        {
            // Arrange
            string[] arr = { "A", "B", "C", "D", "E" };

            // Act
            int result = Array.BinarySearch(arr, 1, 3, "D");

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Range_NotFound()
        {
            // Arrange
            int[] arr = { 1, 3, 5, 7, 9 };

            // Act
            int result = Array.BinarySearch(arr, 1, 3, 4);

            // Assert
            Assert.AreEqual(~2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Range_ElementOutsideButInArray()
        {
            // Arrange
            int[] arr = { 5, 10, 15, 20, 25 };

            // Act
            int result = Array.BinarySearch(arr, 1, 2, 25);

            // Assert
            Assert.AreEqual(~3, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Range_ElementAtStart()
        {
            // Arrange
            string[] arr = { "A", "B", "C", "D", "E" };

            // Act
            int result = Array.BinarySearch(arr, 1, 3, "B");

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Range_ElementAtEnd()
        {
            // Arrange
            int[] arr = { 2, 4, 6, 8, 10 };

            // Act
            int result = Array.BinarySearch(arr, 1, 3, 8);

            // Assert
            Assert.AreEqual(3, result);
        }

        // 4. Array.BinarySearch(Array, Int32, Int32, Object, IComparer)

        [TestMethod]
        public void Test_BinarySearch_Range_CustomComparer()
        {
            // Arrange
            string[] arr = { "Z", "X", "M", "C", "A" };

            // Act
            int result = Array.BinarySearch(arr, 1, 3, "M", new DescComparer());

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Range_CustomComparer_ElementOutside()
        {
            // Arrange
            string[] arr = { "Z", "X", "M", "C", "A" };

            // Act
            int result = Array.BinarySearch(arr, 1, 2, "A", new DescComparer());

            // Assert
            Assert.AreEqual(~3, result);
        }

        // 5. Array.BinarySearch<T>(T[], T)

        [TestMethod]
        public void Test_BinarySearch_Generic_Found()
        {
            // Arrange
            int[] arr = { 10, 20, 30, 40 };

            // Act
            int result = Array.BinarySearch<int>(arr, 30);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_InsertAtStart()
        {
            // Arrange
            int[] arr = { 10, 20, 30 };

            // Act
            int result = Array.BinarySearch<int>(arr, 5);

            // Assert
            Assert.AreEqual(~0, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_InsertAtEnd()
        {
            // Arrange
            int[] arr = { 10, 20, 30 };

            // Act
            int result = Array.BinarySearch<int>(arr, 35);

            // Assert
            Assert.AreEqual(~3, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_Duplicates()
        {
            // Arrange
            double[] arr = { 1.1, 2.2, 2.2, 3.3 };

            // Act
            int index = Array.BinarySearch(arr, 2.2);

            // Assert
            Assert.IsTrue(index >= 1 && index <= 2);
        }

        // 6. Array.BinarySearch<T>(T[], T, IComparer<T>)

        [TestMethod]
        public void Test_BinarySearch_Generic_CustomComparer()
        {
            // Arrange
            int[] arr = { 100, 90, 80, 70 };

            // Act
            int result = Array.BinarySearch<int>(arr, 90, new DescIntComparer());

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_CustomComparer_NotFound()
        {
            // Arrange
            int[] arr = { 100, 90, 80, 70 };

            // Act
            int result = Array.BinarySearch<int>(arr, 85, new DescIntComparer());

            // Assert
            Assert.AreEqual(~2, result);
        }

        // 7. Array.BinarySearch<T>(T[], Int32, Int32, T)

        [TestMethod]
        public void Test_BinarySearch_Generic_Range()
        {
            // Arrange
            int[] arr = { 1, 3, 5, 7, 9 };

            // Act
            int result = Array.BinarySearch<int>(arr, 1, 3, 5);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_Range_ValueOutsideRange()
        {
            // Arrange
            int[] arr = { 10, 20, 30, 40, 50 };

            // Act
            int result = Array.BinarySearch<int>(arr, 1, 2, 50);

            // Assert
            Assert.AreEqual(~3, result);
        }

        // 8. Array.BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>)

        [TestMethod]
        public void Test_BinarySearch_Generic_Range_CustomComparer()
        {
            // Arrange
            int[] arr = { 100, 90, 80, 70, 60 };
            int expectedIndex = 2; // 80 is at index 2 in descending order

            // Act
            int result = Array.BinarySearch<int>(arr, 1, 3, 80, new DescIntComparer());

            // Assert
            Assert.AreEqual(expectedIndex, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_ReverseOrder_Missing()
        {
            // Arrange
            int[] arr = { 100, 90, 80, 70 };
            int expectedIndex = ~3; // 75 is not found, should return negative index

            // Act
            int result = Array.BinarySearch<int>(arr, 1, 2, 75, new DescIntComparer());

            // Assert
            Assert.AreEqual(~3, result);
        }
    }

    public class DescComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return Comparer.Default.Compare(y, x);
        }
    }

    public class DescIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}
