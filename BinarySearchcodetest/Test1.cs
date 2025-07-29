namespace BinarySearchcodetest
{
    [TestClass]
    public class ArraySortTest
    {
        [TestMethod]
        public void DefaultSortingtest()
        {
            // Arrange
            int[] array = { 5, 3, 8, 1, 2 };
            int[] expected = { 1, 2, 3, 5, 8 };
            // Act
            Array.Sort(array);
            // Assert
            CollectionAssert.AreEqual(expected, array);
        }
    }
}
