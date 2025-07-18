using BinarySearcher;
namespace BinarySearcherTests
{
    [TestClass]
    public sealed class TestBinarySearch
    {
        [TestMethod]
        public void ElementFoundTest()
        {
            // Arrange Act Assert
            int[] inputArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int elementToFind = 5;
            int expectedIndex = 4; // Zero-based index of the element
            BinarySearcherImpl SUT = new BinarySearcherImpl(); ;
            // System Under Test, replace with actual implementation
            // Act
            int actualresult = SUT.doBinaryDearch(inputArray,elementToFind);
            // Assert
            Assert.AreEqual(expectedIndex, actualresult, "The element was not found at the expected index.");
        }

        [TestMethod]
        public void ElementNotFoundButLessthanTest()
        {
            // Arrange Act Assert
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            int elementToFind = 5;
            int expectedIndex = ~4; // Zero-based index of the element
            BinarySearcherImpl SUT = new BinarySearcherImpl(); ;
            // System Under Test, replace with actual implementation
            // Act
            int actualresult = SUT.doBinaryDearch(inputArray, elementToFind);
            // Assert
            Assert.AreEqual(expectedIndex, actualresult, "The element was not found at the expected index.");
        }

        [TestMethod]
        public void ElementNotFoundButGreaterthanAllTest()
        {
            // Arrange Act Assert
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            int elementToFind = 15;
            int expectedIndex = ~inputArray.Length; // Zero-based index of the element
            BinarySearcherImpl SUT = new BinarySearcherImpl(); ;
            // System Under Test, replace with actual implementation
            // Act
            int actualresult = SUT.doBinaryDearch(inputArray, elementToFind);
            // Assert
            Assert.AreEqual(expectedIndex, actualresult, "The element was not found at the expected index.");
        }
        /// <summary>
        /// ArgumentNullException: array is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArrayIsNull_ThrowsArgumentNullException()
        {
            int[] inputArray = null;
            int elementToFind = 5;

            SUT.doBinaryDearch(inputArray, elementToFind);
        }

        /// <summary>
        /// RankException: array is multidimensional.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void ArrayIsMultidimensional_ThrowsRankException()
        {
            Array inputArray = Array.CreateInstance(typeof(int), 3, 3); // 2D array
            int elementToFind = 5;

            Array.Sort(inputArray); // will throw RankException
        }

        /// <summary>
        /// ArgumentException: value is of incompatible type with array elements.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValueNotCompatibleWithArray_ThrowsArgumentException()
        {
            object[] inputArray = { "one", "two", "three" };
            object elementToFind = 2; // int, incompatible with string

            Array.BinarySearch(inputArray, elementToFind); // will throw ArgumentException
        }

        /// <summary>
        /// InvalidOperationException: value does not implement IComparable.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ValueWithoutIComparable_ThrowsInvalidOperationException()
        {
            var inputArray = new object[] { new Dummy(), new Dummy() };
            var elementToFind = new Dummy();

            Array.BinarySearch(inputArray, elementToFind); // throws because Dummy doesn't implement IComparable
        }

        private class Dummy { } // no IComparable implemented
    }
}

    }
}
