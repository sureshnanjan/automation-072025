using Microsoft.VisualStudio.TestTools.UnitTesting; // Imports MSTest framework for writing unit tests
using System.Collections; // Imports non-generic collection types like Queue and ArrayList

namespace SystemCollectionsTests
{
    [TestClass] // Marks this class as a container for unit tests
    public class QueueTests
    {
        [TestMethod] // Marks this method as a test method
        public void Enqueue_And_Dequeue()
        {
            Queue q = new Queue(); // Create a new Queue instance
            q.Enqueue("first");    // Add "first" to the queue
            q.Enqueue("second");   // Add "second" to the queue

            Assert.AreEqual("first", q.Dequeue()); // The first dequeued item should be "first"
            Assert.AreEqual("second", q.Dequeue()); // The next dequeued item should be "second"
        }

        [TestMethod]
        public void Peek_ReturnsFrontWithoutRemoving()
        {
            Queue q = new Queue();  // Create a new Queue
            q.Enqueue("alpha");     // Add "alpha" to the queue

            Assert.AreEqual("alpha", q.Peek());     // Peek returns the first item without removing it
            Assert.AreEqual("alpha", q.Dequeue());  // Dequeue still returns "alpha", confirming Peek didn't remove it
        }

        [TestMethod]
        public void Count_ReflectsQueueSize()
        {
            Queue q = new Queue(); // New Queue instance
            q.Enqueue(1);          // Add 1
            q.Enqueue(2);          // Add 2

            Assert.AreEqual(2, q.Count); // Count should be 2 after adding two items
            q.Dequeue();                 // Remove one item
            Assert.AreEqual(1, q.Count); // Count should now be 1
        }

        [TestMethod]
        public void Clear_EmptiesQueue()
        {
            Queue q = new Queue(); // New Queue
            q.Enqueue("x");        // Add one item
            q.Clear();             // Clear the queue

            Assert.AreEqual(0, q.Count); // Count should be 0 after clearing
        }

        [TestMethod]
        public void Contains_ChecksForExistence()
        {
            Queue q = new Queue();      // New Queue
            q.Enqueue("item");          // Add "item"

            Assert.IsTrue(q.Contains("item")); // Should return true since "item" is in the queue
            Assert.IsFalse(q.Contains("none")); // Should return false for something not in the queue
        }

        [TestMethod]
        public void Enumerator_IteratesInOrder()
        {
            Queue q = new Queue(); // Create a new queue
            q.Enqueue(1);          // Enqueue 1
            q.Enqueue(2);          // Enqueue 2
            q.Enqueue(3);          // Enqueue 3

            var list = new ArrayList(); // Create a list to collect iteration output

            foreach (var item in q)     // Iterate over the queue (FIFO order)
                list.Add(item);         // Add each item to the list

            // Ensure that the enumerated order is [1, 2, 3]
            CollectionAssert.AreEqual(new object[] { 1, 2, 3 }, list);
        }
    }
}
