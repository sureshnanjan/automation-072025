using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySearcherTests.ExceptionTests
{
    [TestClass]
    public class TestBinarySearchExceptions
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearch_ArrayIsNull_ThrowsArgumentNullException()
        {
            int[] array = null;
            int valueToSearch = 3;
            Array.BinarySearch(array, valueToSearch);
        }

        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void BinarySearch_ArrayIsMultidimensional_ThrowsRankException()
        {
            int[,] array = new int[,] { { 1, 2 }, { 3, 4 } };
            int valueToSearch = 3;
            Array.BinarySearch(array, valueToSearch);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinarySearch_ValueIncompatibleType_ThrowsInvalidOperationException()
        {
            string[] array = { "a", "b", "c" };
            int valueToSearch = 3;  // incompatible type
            Array.BinarySearch(array, valueToSearch);
        }

        class NonComparable { public int Id { get; set; } }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinarySearch_ValueNotComparable_ThrowsInvalidOperationException()
        {
            var array = new NonComparable[]
            {
                new NonComparable { Id = 1 },
                new NonComparable { Id = 2 }
            };

            var valueToSearch = new NonComparable { Id = 2 };
            Array.BinarySearch(array, valueToSearch);
        }
    }
}
