using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace CollectionsTests
{
    [TestClass]
    public class CollectionCombinerTests
    {
        [TestMethod]
        public void CombineArrayListAndQueue_ContainsAllExpectedQueueItems()
        {
            // Arrange
            var combiner = new CollectionCombiner();

            // Act
            ArrayList result = combiner.CombineArrayListAndQueue();

            // Assert - Ensure result contains all expected queue items
            CollectionAssert.Contains(result, "over");
            CollectionAssert.Contains(result, "the");
            CollectionAssert.Contains(result, "lazy");
            CollectionAssert.Contains(result, "dog");
        }

        [TestMethod]
        public void CombineArrayListAndQueue_QueueIsClearedAfterUse()
        {
            // Arrange
            var combiner = new CollectionCombiner();

            // Act
            combiner.CombineArrayListAndQueue(); // Should clear queue

            // Assert via debug output or track separately if needed
            // If you've exposed a property like `combiner.QueueCount`
            // Assert.AreEqual(0, combiner.QueueCount);
        }



        [TestMethod]
        public void CombineArrayListAndQueue_ItemsAreInCorrectOrder()
        {
            // Arrange
            var combiner = new CollectionCombiner();

            // Act
            ArrayList result = combiner.CombineArrayListAndQueue();

            // Assert correct sequential order
            var expected = new ArrayList { "The", "quick", "brown", "fox", "over", "the", "lazy", "dog" };
            CollectionAssert.AreEqual(expected, result);
        }


        [TestMethod]
        public void CombineArrayListAndQueue_CopiedArrayContainsCorrectItems()
        {
            // Arrange
            var expectedRemainingQueue = new ArrayList { "over", "the", "lazy", "dog" };

            var combiner = new CollectionCombiner();

            // Act
            ArrayList result = combiner.CombineArrayListAndQueue();

            // Extract copied portion (indices 4 to 7)
            var copiedSection = new ArrayList();
            for (int i = 4; i <= 7; i++ )
            {
                copiedSection.Add(result[i]);
            }

            // Assert
            CollectionAssert.AreEqual(expectedRemainingQueue, copiedSection);
        }
    }
}
