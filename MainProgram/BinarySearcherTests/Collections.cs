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
    public class QueueTest() //queue
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
            //Assert.AreEqual("Apple", dequeued);
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
    [TestClass]
    public class BitArrayTests //BitArrayTests
    {
        [TestMethod]
        public void Create_BitArrayWithValues_ShouldStoreCorrectly()
        {
            // Arrange
            bool[] bits = new bool[] { true, false, true };

            // Act
            BitArray bitArray = new BitArray(bits);

            // Assert
            Assert.AreEqual(3, bitArray.Length);
            Assert.IsTrue(bitArray[0]);
            Assert.IsFalse(bitArray[1]);
            Assert.IsTrue(bitArray[2]);
        }

        [TestMethod]
        public void Read_IndividualBits_ShouldReturnExpectedValues()
        {
            // Arrange
            BitArray bitArray = new BitArray(new bool[] { false, true, false });

            // Act
            bool first = bitArray[0];
            bool second = bitArray[1];
            bool third = bitArray[2];

            // Assert
            Assert.IsFalse(first);
            Assert.IsTrue(second);
            Assert.IsFalse(third);
        }

        [TestMethod]
        public void Update_SetBitValue_ShouldReflectChanges()
        {
            // Arrange
            BitArray bitArray = new BitArray(3); // default false

            // Act
            bitArray[1] = true;

            // Assert
            Assert.IsFalse(bitArray[0]);
            Assert.IsTrue(bitArray[1]);
        }

        [TestMethod]
        public void Delete_ClearBitValue_ShouldSetToFalse()
        {
            // Arrange
            BitArray bitArray = new BitArray(new bool[] { true, true, true });

            // Act
            bitArray[1] = false;

            // Assert
            Assert.IsTrue(bitArray[0]);
            Assert.IsFalse(bitArray[1]);
            Assert.IsTrue(bitArray[2]);
        }

        [TestMethod]
        public void Enumerate_Bits_ShouldReturnCorrectSequence()
        {
            // Arrange
            BitArray bitArray = new BitArray(new bool[] { true, false, true });

            // Act
            bool[] expected = new bool[] { true, false, true };
            bool[] actual = new bool[bitArray.Count];
            int i = 0;

            foreach (bool bit in bitArray)
            {
                actual[i++] = bit;
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
    [TestClass]
    public class StackTests //StackTests
    {
        [TestMethod]
        public void Create_PushItemsOntoStack_ShouldContainItems() // Create
        {
            // Arrange
            Stack stack = new Stack();

            // Act
            stack.Push("First");
            stack.Push("Second");

            // Assert
            Assert.AreEqual(2, stack.Count);
            CollectionAssert.Contains(stack, "First");
            CollectionAssert.Contains(stack, "Second");
        }

        [TestMethod]
        public void Read_Peek_ShouldReturnTopItemWithoutRemoving() // Read
        {
            // Arrange
            Stack stack = new Stack();
            stack.Push("First");
            stack.Push("Second");
            string expectedTop = "Second";
            int expectedcount = 2;
            int realcount= stack.Count;

            // Act
            var topItem = stack.Peek(); // Should return "Second"

            // Assert
            Assert.AreEqual(expectedTop, topItem);
            Assert.AreEqual(expectedcount,realcount); // Count should remain the same
        }

        [TestMethod]
        public void Update_ReplaceTopItem_UsingPopAndPush() // Update
        {
            // Arrange
            Stack stack = new Stack();
            stack.Push("OldTop");
            stack.Push("TopToReplace");

            // Act
            stack.Pop(); // Remove top item
            stack.Push("NewTop"); // Push new item

            // Assert
            Assert.AreEqual("NewTop", stack.Peek());
            Assert.AreEqual(2, stack.Count);
        }

        [TestMethod]
        public void Delete_PopItem_ShouldRemoveTopItem() // Delete
        {
            // Arrange
            Stack stack = new Stack();
            stack.Push("Bottom");
            stack.Push("Top");

            // Act
            var removedItem = stack.Pop();

            // Assert
            Assert.AreEqual("Top", removedItem);
            Assert.AreEqual(1, stack.Count);
            CollectionAssert.DoesNotContain(stack, "Top");
        }

        [TestMethod]
        public void Enumerate_StackItemsUsingIEnumerable_ShouldMatchExpected() // IEnumerable
        {
            // Arrange
            Stack stack = new Stack();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C"); // Top of stack

            // Act
            string[] expected = { "C", "B", "A" };
            string[] actual = new string[stack.Count];

            int i = 0;
            foreach (var item in stack)
            {
                actual[i++] = item.ToString();
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
