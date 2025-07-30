using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace CollectionTests
{
    [TestClass]
    public class ArrayListTests //ArrayListTests
    {
        [TestMethod]
        public void Create_AddItemsToArrayList_ShouldContainItems() //Create
        {
            // Arrange
            ArrayList list = new ArrayList();

            // Act
            list.Add("Apple");
            list.Add("Banana");

            // Assert
            Assert.AreEqual(2, list.Count);
            CollectionAssert.Contains(list, "Apple");
            CollectionAssert.Contains(list, "Banana");
        }

        [TestMethod]
        public void Read_GetItemByIndex_ShouldReturnCorrectItem() //Read
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple", "Banana" };
            string fruit = "Banana";

            // Act
            var result = list[1];

            // Assert
            Assert.AreEqual(fruit, result);
        }

        [TestMethod]
        public void Update_ModifyItemAtIndex_ShouldReflectUpdatedValue() //Update
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple", "Banana" };
            string newfruit = "Blueberry";

            // Act
            list[1] = newfruit;

            // Assert
            Assert.AreEqual(newfruit, list[1]);
        }

        [TestMethod]
        public void Delete_RemoveItem_ShouldReduceCount()//delete
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple", "Banana" };

            // Act
            list.Remove("Banana");

            // Assert
            Assert.AreEqual(1, list.Count);
            CollectionAssert.DoesNotContain(list, "Banana");
        }
        [TestMethod]
        public void ReadItems_ShouldReturnExpectedValues() //enumerable
        {
            // Arrange
            ArrayList fruits = new ArrayList { "Orange", "Grapes", "Kiwi" };

            // Act
            string[] expected = { "Orange", "Grapes", "Kiwi" };
            string[] actual = new string[fruits.Count];
            for (int i = 0; i < fruits.Count; i++)
            {
                actual[i] = fruits[i].ToString();
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
    [TestClass]
    public class QueueTest()
    {
        [TestMethod]
        public void Create_EnqueueItems_ShouldContainItems()
        {
            // Arrange
            Queue queue = new Queue();

            // Act
            queue.Enqueue("Apple");
            queue.Enqueue("Banana");

            // Assert
            Assert.AreEqual(2, queue.Count);
            CollectionAssert.Contains(queue, "Apple");
            CollectionAssert.Contains(queue, "Banana");
        }

        [TestMethod]
        public void Read_Peek_ShouldReturnFirstItemWithoutRemoving()
        {
            // Arrange
            Queue queue = new Queue();
            queue.Enqueue("Apple");
            queue.Enqueue("Banana");

            // Act
            var result = queue.Peek();

            // Assert
            Assert.AreEqual("Apple", result);
            Assert.AreEqual(2, queue.Count); // Ensure it wasn't removed
        }

        [TestMethod]
        public void Delete_Dequeue_ShouldRemoveFirstItem()
        {
            // Arrange
            Queue queue = new Queue();
            queue.Enqueue("Apple");
            queue.Enqueue("Banana");

            // Act
            var dequeued = queue.Dequeue();

            // Assert
            Assert.AreEqual("Apple", dequeued);
            Assert.AreEqual(1, queue.Count);
            CollectionAssert.DoesNotContain(queue, "Apple");
        }

        [TestMethod]
        public void Enumerate_ItemsInQueue_ShouldMatchExpectedOrder()
        {
            // Arrange
            Queue queue = new Queue();
            queue.Enqueue("Orange");
            queue.Enqueue("Grapes");
            queue.Enqueue("Kiwi");

            // Act
            string[] expected = { "Orange", "Grapes", "Kiwi" };
            string[] actual = new string[queue.Count];

            int index = 0;
            foreach (var item in queue)
            {
                actual[index++] = item.ToString();
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Clear_ShouldRemoveAllItems()
        {
            // Arrange
            Queue queue = new Queue();
            queue.Enqueue("Apple");
            queue.Enqueue("Banana");

            // Act
            queue.Clear();

            // Assert
            Assert.AreEqual(0, queue.Count);
        }

    }
    //Stack
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Create_PushItems_ShouldContainItems()
        {
            // Arrange
            Stack stack = new Stack();

            // Act
            stack.Push("Apple");
            stack.Push("Banana");

            // Assert
            Assert.AreEqual(2, stack.Count);
            CollectionAssert.Contains(stack, "Apple");
            CollectionAssert.Contains(stack, "Banana");
        }

        [TestMethod]
        public void Read_Peek_ShouldReturnTopItemWithoutRemoving()
        {
            // Arrange
            Stack stack = new Stack();
            stack.Push("Apple");
            stack.Push("Banana");
            string expected = "Banana";


            // Act
            var top = stack.Peek();

            // Assert
            Assert.AreEqual(expected, top); // Last pushed is on top
            Assert.AreEqual(2, stack.Count); // Should not remove
        }

        [TestMethod]
        public void Delete_Pop_ShouldRemoveTopItem()
        {
            // Arrange
            Stack stack = new Stack();
            stack.Push("Apple");
            stack.Push("Banana");

            // Act
            var popped = stack.Pop();

            // Assert
            Assert.AreEqual("Banana", popped); // Last in, first out
            Assert.AreEqual(1, stack.Count);
            CollectionAssert.DoesNotContain(stack, "Banana");
        }

        [TestMethod]
        public void Enumerate_ItemsInStack_ShouldReturnInLIFOOrder()
        {
            // Arrange
            Stack stack = new Stack();
            stack.Push("One");
            stack.Push("Two");
            stack.Push("Three");

            // Act
            string[] expected = { "Three", "Two", "One" }; // LIFO
            string[] actual = new string[stack.Count];
            int index = 0;

            foreach (var item in stack)
            {
                actual[index++] = item.ToString();
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Clear_ShouldRemoveAllItems()
        {
            // Arrange
            Stack stack = new Stack();
            stack.Push("Apple");
            stack.Push("Banana");

            // Act
            stack.Clear();

            // Assert
            Assert.AreEqual(0, stack.Count);
        }
    }

}