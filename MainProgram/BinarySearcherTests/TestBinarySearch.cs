using BinarySearcher;
using System.Collections;
using CustomExtensions;
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
        [TestMethod]
        public void ElementFoundForRangeOK() {
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            //inputArray.Add
          
            int elementToFind = 0;
            int actual = Array.BinarySearch(inputArray, 1,5,elementToFind);

        }
    }
}
