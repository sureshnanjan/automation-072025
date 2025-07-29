using System;
using System.Collections;

namespace CollectionsTests
{
    /// <summary>
    /// Provides functionality to combine collections such as ArrayList and Queue.
    /// </summary>
    public class CollectionCombiner
    {
        /// <summary>
        /// Combines an ArrayList and a Queue by:
        /// - Creating and initializing both collections
        /// - Removing the first item from the Queue (dequeue)
        /// - Copying the remaining Queue items to an array
        /// - Adding the remaining Queue items to the ArrayList
        /// - Clearing the Queue
        /// </summary>
        /// <returns>
        /// A combined ArrayList containing the original ArrayList items followed by the remaining Queue items.
        /// </returns>
        public ArrayList CombineArrayListAndQueue()
        {
            // Create and initialize a new ArrayList.
            ArrayList myAL = new() { "The", "quick", "brown", "fox" };

            // Create and initialize a new Queue.
            Queue myQueue = new Queue();
            myQueue.Enqueue("jumps");
            myQueue.Enqueue("over");
            myQueue.Enqueue("the");
            myQueue.Enqueue("lazy");
            myQueue.Enqueue("dog");

            // Dequeue one item and print it.
            object dequeuedItem = myQueue.Dequeue();
            Console.WriteLine("Dequeued item: " + dequeuedItem);

            // Copy the remaining queue elements to an object array.
            object[] copiedArray = new object[myQueue.Count];
            myQueue.CopyTo(copiedArray, 0);

            Console.WriteLine("Copied elements from Queue:");
            foreach (var item in copiedArray)
            {
                Console.WriteLine(item);
            }

            // Add Queue elements to the ArrayList.
            myAL.AddRange(myQueue);

            // Clear the queue.
            myQueue.Clear();
            Console.WriteLine("Queue cleared. Count = " + myQueue.Count);

            return myAL;
        }
    }
}
