using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySearchUnitTests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void BinarySearch_ElementExists_ReturnsCorrectIndex()
        {
            // Arrange
            Array array = Array.CreateInstance(typeof(int), 5);
            array.SetValue(10, 0);
            array.SetValue(20, 1);
            array.SetValue(30, 2);
            array.SetValue(40, 3);
            array.SetValue(50, 4);

            Array.Sort(array); // Required before using BinarySearch

            // Act
            int index = Array.BinarySearch(array, 30);

            // Assert
            Assert.AreEqual(2, index); // 30 should be at index 2
        }

        [TestMethod]
        public void BinarySearch_ElementDoesNotExist_ReturnsNegativeIndex()
        {
            // Arrange
            Array array = Array.CreateInstance(typeof(int), 5);
            array.SetValue(5, 0);
            array.SetValue(15, 1);
            array.SetValue(25, 2);
            array.SetValue(35, 3);
            array.SetValue(45, 4);

            Array.Sort(array);

            // Act
            int index = Array.BinarySearch(array, 28); // 28 not in array

            // Assert
            Assert.IsTrue(index < 0);
        }

        [TestMethod]
        public void BinarySearch_FirstElement_ReturnsIndexZero()
        {
            // Arrange
            Array array = Array.CreateInstance(typeof(int), 3);
            array.SetValue(1, 0);
            array.SetValue(2, 1);
            array.SetValue(3, 2);

            Array.Sort(array);

            // Act
            int index = Array.BinarySearch(array, 1);

            // Assert
            Assert.AreEqual(0, index);
        }
    }
}
