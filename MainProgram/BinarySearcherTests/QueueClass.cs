using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace BinarySearcherTests
{
    [TestClass]
    public class QueueClass
    {
        public Queue queue;

        [TestInitialize]
        public void Queue_Setup()
        {
            queue = new Queue();
            queue.Enqueue("One");
            queue.Enqueue("Two");
            queue.Enqueue("Three");
        }

        [TestMethod]
        public void Test_Queue_CreateAndRead()
        {
            // Arrange
            var expectedCount = 3;

            // Act
            var actualCount = queue.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void Test_Queue_Update()
        {
            // Note: Queues do not support random access updates.
            // So we simulate by dequeuing, modifying, and enqueuing again.

            // Arrange
            var expectedFirst = "Updated-One";
            Queue updatedQueue = new Queue();
            updatedQueue.Enqueue(expectedFirst);
            updatedQueue.Enqueue("Two");
            updatedQueue.Enqueue("Three");

            // Act
            Queue tempQueue = new Queue();
            tempQueue.Enqueue("Updated-One");
            queue.Dequeue(); // Remove "One" in queue
            tempQueue.Enqueue(queue.Dequeue()); // add and remove "Two" in tempQueue and queue respectively
            tempQueue.Enqueue(queue.Dequeue()); // add and remove "Three" in tempQueue and queue respectively

            queue = tempQueue; // Replace original

            // Assert
            Assert.AreEqual(expectedFirst, queue.Peek());
        }

        [TestMethod]
        public void Test_Queue_Delete()
        {
            // Arrange
            var expectedFirst = "Two";

            // Act
            queue.Dequeue(); // Remove "One"
            var actualFirst = queue.Peek();

            // Assert
            Assert.AreEqual(expectedFirst, actualFirst);
        }

        [TestMethod]
        public void Test_Queue_Enumerate()
        {
            // Arrange
            var expectedElements = new[] { "One", "Two", "Three" };
            int index = 0;

            // Act & Assert
            foreach (var item in queue)
            {
                Assert.AreEqual(expectedElements[index], item);
                index++;
            }

            Assert.AreEqual(expectedElements.Length, index);
        }
    }
}

