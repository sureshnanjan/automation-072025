using BinarySearcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace TestingBinarySearchTypes
{
    [TestClass]
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
            int index = comparer.doBinarySearchWithComparer(arr, startIndex, count, key);

            // Assert
            Assert.AreEqual(3, index); // 40 is at index 3 in arr
        }


    }
}