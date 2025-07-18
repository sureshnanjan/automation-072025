using BinarySearcher;
<<<<<<< HEAD
using Microsoft.VisualStudio.TestTools.UnitTesting;

=======
>>>>>>> 186d03cec2df535e30a7e2f1c3c60f8e6120b33c
namespace BinarySearcherTests
{
    [TestClass]
    public sealed class TestBinarySearch
    {
        [TestMethod]
        public void ElementFoundTest()
        {
<<<<<<< HEAD
            int[] inputArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int elementToFind = 5;
            int expectedIndex = 4;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualresult = SUT.doBinaryDearch(inputArray, elementToFind);

=======
            // Arrange Act Assert
            int[] inputArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int elementToFind = 5;
            int expectedIndex = 4; // Zero-based index of the element
            BinarySearcherImpl SUT = new BinarySearcherImpl(); ;
            // System Under Test, replace with actual implementation
            // Act
            int actualresult = SUT.doBinaryDearch(inputArray,elementToFind);
            // Assert
>>>>>>> 186d03cec2df535e30a7e2f1c3c60f8e6120b33c
            Assert.AreEqual(expectedIndex, actualresult, "The element was not found at the expected index.");
        }

        [TestMethod]
        public void ElementNotFoundButLessthanTest()
        {
<<<<<<< HEAD
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            int elementToFind = 5;
            int expectedIndex = ~4;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualresult = SUT.doBinaryDearch(inputArray, elementToFind);

=======
            // Arrange Act Assert
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            int elementToFind = 5;
            int expectedIndex = ~4; // Zero-based index of the element
            BinarySearcherImpl SUT = new BinarySearcherImpl(); ;
            // System Under Test, replace with actual implementation
            // Act
            int actualresult = SUT.doBinaryDearch(inputArray, elementToFind);
            // Assert
>>>>>>> 186d03cec2df535e30a7e2f1c3c60f8e6120b33c
            Assert.AreEqual(expectedIndex, actualresult, "The element was not found at the expected index.");
        }

        [TestMethod]
        public void ElementNotFoundButGreaterthanAllTest()
        {
<<<<<<< HEAD
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            int elementToFind = 15;
            int expectedIndex = ~inputArray.Length;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualresult = SUT.doBinaryDearch(inputArray, elementToFind);

            Assert.AreEqual(expectedIndex, actualresult, "The element was not found at the expected index.");
        }

        // ✅ New Test Case 1: Element at Beginning
        [TestMethod]
        public void ElementAtBeginningTest()
        {
            int[] inputArray = { 1, 2, 3, 4, 5 };
            int elementToFind = 1;
            int expectedIndex = 0;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualresult = SUT.doBinaryDearch(inputArray, elementToFind);

            Assert.AreEqual(expectedIndex, actualresult, "The element at the beginning was not found.");
        }

        // ✅ New Test Case 2: Element at End
        [TestMethod]
        public void ElementAtEndTest()
        {
            int[] inputArray = { 1, 2, 3, 4, 5 };
            int elementToFind = 5;
            int expectedIndex = 4;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualresult = SUT.doBinaryDearch(inputArray, elementToFind);

            Assert.AreEqual(expectedIndex, actualresult, "The element at the end was not found.");
        }

        // ✅ New Test Case 3: Duplicate Elements
        [TestMethod]
        public void ElementWithDuplicatesTest()
        {
            int[] inputArray = { 1, 2, 4, 4, 4, 5, 6 };
            int elementToFind = 4;
            int expectedIndex = 2; // could be 2, 3, or 4 depending on implementation

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualresult = SUT.doBinaryDearch(inputArray, elementToFind);

            // Check that the result is any of the duplicate positions (2, 3, or 4)
            CollectionAssert.Contains(new[] { 2, 3, 4 }, actualresult, "The duplicate element was not found at a valid index.");
        }
    }
}
=======
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
    }
}
>>>>>>> 186d03cec2df535e30a7e2f1c3c60f8e6120b33c
