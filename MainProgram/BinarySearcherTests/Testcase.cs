using BinarySearcher;
namespace BinarySearcherTests
{
    [TestClass]
    public sealed class TestBinarySearchEdgeCases
    {
        [TestMethod]
        public void EmptyArrayTest()
        {
            // Arrange
            int[] inputArray = { };
            int elementToFind = 3;
            int expectedIndex = ~0;

            BinarySearcherImpl SUT = new BinarySearcherImpl();

            // Act
            int actualResult = SUT.doBinaryDearch(inputArray, elementToFind);

            // Assert
            Assert.AreEqual(expectedIndex, actualResult, "Should return ~0 for empty array.");
        }

        [TestMethod]
        public void SingleElementArray_ElementFound()
        {
            // Arrange
            int[] inputArray = { 10 };
            int elementToFind = 10;
            int expectedIndex = 0;

            BinarySearcherImpl SUT = new BinarySearcherImpl();

            // Act
            int actualResult = SUT.doBinaryDearch(inputArray, elementToFind);

            // Assert
            Assert.AreEqual(expectedIndex, actualResult, "Should return 0 for found in single-element array.");
        }

        [TestMethod]
        public void SingleElementArray_ElementNotFound()
        {
            // Arrange
            int[] inputArray = { 10 };
            int elementToFind = 5;
            int expectedIndex = ~0;

            BinarySearcherImpl SUT = new BinarySearcherImpl();

            // Act
            int actualResult = SUT.doBinaryDearch(inputArray, elementToFind);

            // Assert
            Assert.AreEqual(expectedIndex, actualResult, "Should return ~0 for not found in single-element array.");
        }

        [TestMethod]
        public void AllDuplicates_ElementExists()
        {
            // Arrange
            int[] inputArray = { 7, 7, 7, 7 };
            int elementToFind = 7;

            BinarySearcherImpl SUT = new BinarySearcherImpl();

            // Act
            int actualResult = SUT.doBinaryDearch(inputArray, elementToFind);

            // Assert
            Assert.IsTrue(actualResult >= 0 && actualResult < inputArray.Length, "Element should be found among duplicates.");
        }

        [TestMethod]
        public void AllDuplicates_ElementNotExists()
        {
            // Arrange
            int[] inputArray = { 7, 7, 7, 7 };
            int elementToFind = 8;
            int expectedIndex = ~4;

            BinarySearcherImpl SUT = new BinarySearcherImpl();

            // Act
            int actualResult = SUT.doBinaryDearch(inputArray, elementToFind);

            // Assert
            Assert.AreEqual(expectedIndex, actualResult, "Should return index where element would be inserted.");
        }

        [TestMethod]
        public void NegativeNumbersTest()
        {
            // Arrange
            int[] inputArray = { -20, -15, -10, -5, 0, 5 };
            int elementToFind = -10;
            int expectedIndex = 2;

            BinarySearcherImpl SUT = new BinarySearcherImpl();

            // Act
            int actualResult = SUT.doBinaryDearch(inputArray, elementToFind);

            // Assert
            Assert.AreEqual(expectedIndex, actualResult, "Should correctly handle negative numbers.");
        }
    }
}
