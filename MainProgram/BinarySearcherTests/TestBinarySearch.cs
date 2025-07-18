using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearcher;

namespace BinarySearcherTests
{
    [TestClass]
    public sealed class TestBinarySearch
    {
        [TestMethod]
        public void ElementFoundTest()
        {
            int[] inputArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int elementToFind = 5;
            int expectedIndex = 4;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualresult = SUT.DoBinarySearch(inputArray, elementToFind);
            Assert.AreEqual(expectedIndex, actualresult, "The element was not found at the expected index.");
        }

        [TestMethod]
        public void ElementNotFoundButLessthanTest()
        {
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            int elementToFind = 5;
            int expectedIndex = ~4;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualresult = SUT.DoBinarySearch(inputArray, elementToFind);
            Assert.AreEqual(expectedIndex, actualresult, "The element was not found at the expected index.");
        }

        [TestMethod]
        public void ElementNotFoundButGreaterthanAllTest()
        {
            int[] inputArray = { 1, 2, 3, 4, 6, 7, 8, 9, 10 };
            int elementToFind = 15;
            int expectedIndex = ~inputArray.Length;

            BinarySearcherImpl SUT = new BinarySearcherImpl();
            int actualresult = SUT.DoBinarySearch(inputArray, elementToFind);
            Assert.AreEqual(expectedIndex, actualresult, "The element was not found at the expected index.");
        }
    }
}
