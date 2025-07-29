using System.Collections;
using System.Collections.Generic;
namespace TestingForDataStructures
{
    
    [TestClass]
    public class QueueCrudOperationsTests
    {
        [TestMethod]
        public void Test_Enqueue_AddItemsToQueue()
        {
            // Arrange
            Queue queue = new Queue();

            // Act
            queue.Enqueue("Alice");
            queue.Enqueue(123);
            queue.Enqueue("Charlie");

            // Assert
            Assert.AreEqual(3, queue.Count);
            Assert.IsTrue(queue.Contains(123));
        }

        [TestMethod]
        public void Test_Dequeue_RemoveFrontItem()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            // Act
            string removed = queue.Dequeue();
            
            // Assert
            Assert.AreEqual("A", removed);
            Assert.AreEqual(2, queue.Count);
            Assert.IsFalse(queue.Contains("A"));
        }

        [TestMethod]
        public void Test_Peek_ViewFrontWithoutRemoving()
        {
            // Arrange
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);

            // Act
            int front = queue.Peek();

            // Assert
            Assert.AreEqual(10, front);
            Assert.AreEqual(2, queue.Count); // Ensure nothing was removed
        }

        [TestMethod]
        public void Test_Contains_CheckIfItemExists()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Red");
            queue.Enqueue("Green");
            queue.Enqueue("Blue");

            // Act & Assert
            Assert.IsTrue(queue.Contains("Green"));
            Assert.IsFalse(queue.Contains("Yellow"));
        }

        [TestMethod]
        public void Test_Clear_EmptyTheQueue()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("1");
            queue.Enqueue("2");

            // Act
            queue.Clear();

            // Assert
            Assert.AreEqual(0, queue.Count);
            Assert.IsFalse(queue.Contains("1"));
        }

        [TestMethod]
        public void Test_Dequeue_OnEmptyQueue_ShouldThrow()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        }

        [TestMethod]
        public void Test_Peek_OnEmptyQueue_ShouldThrow()
        {
            // Arrange
            Queue<int> queue = new Queue<int>();

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => queue.Peek());
        }

        [TestMethod]
        public void Test_Enumerator_LoopThroughItems()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Dog");
            queue.Enqueue("Cat");
            queue.Enqueue("Bird");

            IEnumerator enumerator = queue.GetEnumerator();

            int count = 0;
            string combined = "";

            // Act
            while (enumerator.MoveNext())
            {
                object item = enumerator.Current;
                combined += item + " ";
                count++;
            }

            // Assert
            Assert.AreEqual(3, count);
            Assert.AreEqual("Dog Cat Bird ",combined);

            StringAssert.Contains(combined, "Dog");
            StringAssert.Contains(combined, "Cat");
            StringAssert.Contains(combined, "Bird");
        }

        [TestMethod]

        public void Test_ForeachIteration_MatchesEnumerator()
        {
            // Arrange
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("X");
            queue.Enqueue("Y");

            List<string> fromForeach = new List<string>();

            // Act - foreach
            foreach (var item in queue)
            {
                fromForeach.Add(item);
            }

            // Act - enumerator
            IEnumerator e = queue.GetEnumerator();
            e.MoveNext();
            string firstItem = (string)e.Current;

            // Assert
            Assert.AreEqual("X", fromForeach[0]);
            Assert.AreEqual("X", firstItem);
        }
    }




    [TestClass]
    public class ArrayListCrudOperationsTests
    {
        [TestMethod]
        public void Test_Create_AddElementsToArrayList()
        {
            ArrayList list = new ArrayList();

            list.Add("Apple");
            list.Add(100);
            list.Add(true);

            Assert.AreEqual(3, list.Count, "ArrayList should have 3 items");
            Assert.AreEqual("Apple", list[0]);
            Assert.IsInstanceOfType(list[1], typeof(int));
            Assert.IsTrue((bool)list[2]);
        }

        [TestMethod]
        public void Test_Read_ValidateItems()
        {
            ArrayList list = new ArrayList() { "One", "Two", "Three" };

            string secondItem = (string)list[1];

            Assert.AreEqual("Two", secondItem);
            CollectionAssert.Contains(list, "Three");
        }

        [TestMethod]
        public void Test_Update_ModifyExistingElement()
        {
            ArrayList list = new ArrayList() { "OldValue", "StaySame" };

            list[0] = "NewValue";

            Assert.AreEqual("NewValue", list[0]);
            Assert.AreEqual("StaySame", list[1]);
        }

        [TestMethod]
        public void Test_Delete_RemoveElementByIndex()
        {
            ArrayList list = new ArrayList() { "DeleteMe", "KeepMe" };

            list.RemoveAt(0);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("KeepMe", list[0]);
        }

        [TestMethod]
        public void Test_Delete_RemoveElementByValue()
        {
            ArrayList list = new ArrayList() { "A", "B", "C" };

            list.Remove("B");

            Assert.AreEqual(2, list.Count);
            CollectionAssert.DoesNotContain(list, "B");
        }

        [TestMethod]
        public void Test_Read_InvalidIndex_ShouldThrow()
        {
            ArrayList list = new ArrayList() { "X", "Y" };

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => {
                var invalid = list[5];
            });

            StringAssert.Contains(ex.Message, "Index was out of range");
        }

        [TestMethod]
        public void Test_Update_InvalidIndex_ShouldThrow()
        {
            ArrayList list = new ArrayList() { "A" };

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => {
                list[3] = "Invalid";
            });

            StringAssert.Contains(ex.Message, "Index was out of range");
        }

        [TestMethod]
        public void Test_Clear_AllElements()
        {
            ArrayList list = new ArrayList() { 1, 2, 3 };
            list.Clear();

            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(list.Contains(1));
        }
    }
}
