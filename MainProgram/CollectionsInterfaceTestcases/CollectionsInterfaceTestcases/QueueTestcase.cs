using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QueueTests
{
    [TestClass] // Marks this class as a test container
    public class QueueCrudTests
    {
        private Queue _queue; // Queue instance for all tests

        [TestInitialize]
        public void Setup()
        {
            // Arrange: Initialize a fresh queue before each test
            _queue = new Queue();
        }

        // ------------------- CREATE TEST -------------------
        [TestMethod]
        public void Create_EnqueueItems_ShouldIncreaseCount()
        {
            // Act
            _queue.Enqueue("Item1");
            _queue.Enqueue("Item2");
            _queue.Enqueue("Item3");

            // Assert
            Assert.AreEqual(3, _queue.Count, "Enqueue should increase queue count.");
        }

        // ------------------- READ TEST -------------------
        [TestMethod]
        public void Read_PeekItem_ShouldReturnFirstElementWithoutRemovingIt()
        {
            // Arrange
            _queue.Enqueue("First");
            _queue.Enqueue("Second");

            // Act
            var firstItem = _queue.Peek();

            // Assert
            Assert.AreEqual("First", firstItem, "Peek should return the first enqueued item.");
            Assert.AreEqual(2, _queue.Count, "Peek should not remove the element.");
        }

        // ------------------- UPDATE TEST -------------------
        [TestMethod]
        public void Update_DequeueAndEnqueue_ShouldModifyQueue()
        {
            // Arrange
            _queue.Enqueue("OldValue");
            _queue.Enqueue("Second");

            // Act
            _queue.Dequeue();              // Remove the first element
            _queue.Enqueue("NewValue");    // Add a new element

            // Assert
            CollectionAssert.AreEqual(
                new List<object> { "Second", "NewValue" },
                _queue.Cast<object>().ToList(),
                "Queue should reflect updated items after dequeue and enqueue."
            );
        }

        // ------------------- DELETE TEST -------------------
        [TestMethod]
        public void Delete_DequeueItem_ShouldRemoveFirstElement()
        {
            // Arrange
            _queue.Enqueue("Item1");
            _queue.Enqueue("Item2");

            // Act
            var removedItem = _queue.Dequeue();

            // Assert
            Assert.AreEqual("Item1", removedItem, "Dequeue should remove the first enqueued item.");
            Assert.AreEqual(1, _queue.Count, "Queue count should decrease after dequeue.");
        }

        // ------------------- DELETE ALL TEST -------------------
        [TestMethod]
        public void DeleteAll_ClearQueue_ShouldResultInEmptyQueue()
        {
            // Arrange
            _queue.Enqueue("One");
            _queue.Enqueue("Two");

            // Act
            _queue.Clear();

            // Assert
            Assert.AreEqual(0, _queue.Count, "Clear should remove all items from the queue.");
        }

        // ------------------- ENUMERABLE TEST -------------------
        [TestMethod]
        public void Enumerable_ShouldIterateQueueInFIFOOrder()
        {
            // Arrange
            _queue.Enqueue("A");
            _queue.Enqueue("B");
            _queue.Enqueue("C");

            // Act: Convert IEnumerable queue to list
            var items = _queue.Cast<object>().ToList();

            // Assert: Items should be returned in FIFO order
            CollectionAssert.AreEqual(
                new List<object> { "A", "B", "C" },
                items,
                "Enumerable should return queue items in FIFO order."
            );
        }
    }
}
