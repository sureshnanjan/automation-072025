using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Specialized;

namespace CollectionNameSpaceTests
{
    [TestClass]
    public class TestCollectionsNamespaceActivity
    {
        // 1. ArrayList allows dynamic object storage with indexing support.
        [TestMethod]
        public void Test_ArrayList_CRUD()
        {
            //Arrange
            ArrayList list = new ArrayList();
            Assert.AreEqual(0, list.Count);

            // Create
            list.Add("Apple");
            list.Add("Banana");
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("Apple", list[0]);
            Assert.AreEqual("Banana", list[1]);

            // Update
            list[0] = "Grape";
            Assert.AreEqual("Grape", list[0]);

            // Delete
            list.Remove("Banana");
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Grape", list[0]);
        }


        // 2. Hashtable stores key-value pairs using hash codes, no order guaranteed.
        [TestMethod]
        public void Test_Hashtable_CRUD()
        {
            Hashtable table = new Hashtable();
            Assert.IsTrue(table.Count == 0);

            // Create
            table.Add("id", 101);
            Assert.AreEqual(101, table["id"]);
            Assert.IsTrue(table.ContainsKey("id"));

            // Update
            table["id"] = 202;
            Assert.AreEqual(202, table["id"]);

            // Delete
            table.Remove("id");
            Assert.IsFalse(table.ContainsKey("id"));
        }


        // 3. Queue is FIFO collection — items come out in the same order they went in.
        [TestMethod]
        public void Test_Queue_FIFO_Operations()
        {
            Queue queue = new Queue();
            Assert.AreEqual(0, queue.Count);

            // Enqueue operations
            queue.Enqueue("Task1");
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual("Task1", queue.Peek());

            queue.Enqueue("Task2");
            Assert.AreEqual(2, queue.Count);
            Assert.AreEqual("Task1", queue.Peek()); // still Task1 at front

            // Dequeue operation
            var first = queue.Dequeue();
            Assert.AreEqual("Task1", first);
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual("Task2", queue.Peek()); // now Task2 is at front
        }


        // 4. Stack is LIFO — last item pushed is the first to come out.
        [TestMethod]
        public void Test_Stack_LIFO_Operations()
        {
            Stack stack = new Stack();

            // Create (Push)
            stack.Push("First");
            Assert.AreEqual(1, stack.Count);
            stack.Push("Second");

            // Read (Peek)
            var topItem = stack.Peek();
            Assert.AreEqual("Second", topItem);

            // Update - Not directly applicable to Stack (LIFO), but we can simulate with Pop + Push
            var popped = stack.Pop(); // Remove "Second"
            Assert.AreEqual("Second", popped);
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual("First", stack.Peek());

            // Delete (Pop)
            stack.Push("UpdatedSecond"); // Push a new item
            var removed1 = stack.Pop(); // Removes "UpdatedSecond"
            Assert.AreEqual("UpdatedSecond", removed1);
            Assert.AreEqual(1, stack.Count);

            stack.Pop(); // Removes "First"
            Assert.AreEqual(0, stack.Count);
        }


        // 5. SortedList stores key-value pairs sorted by keys.
        [TestMethod]
        public void Test_SortedList_CRUD()
        {
            // Create
            SortedList sortedList = new SortedList();
            sortedList.Add("b", "Banana");
            sortedList.Add("a", "Apple");

            // Assert after Create
            Assert.AreEqual(2, sortedList.Count);
            Assert.AreEqual("Apple", sortedList["a"]);
            Assert.AreEqual("Banana", sortedList["b"]);

            // Update
            sortedList["a"] = "Avocado";

            // Assert after Update
            Assert.AreEqual("Avocado", sortedList["a"]);
            Assert.AreEqual(2, sortedList.Count);

            // Delete
            sortedList.Remove("a");

            // Assert after Delete
            Assert.IsFalse(sortedList.ContainsKey("a"));
            Assert.AreEqual(1, sortedList.Count);
            Assert.AreEqual("Banana", sortedList["b"]);
        }


        // 6. BitArray efficiently stores bits as true or false values.
        [TestMethod]
        public void Test_BitArray_SetAndCheckBits()
        {
            // Create
            BitArray bits = new BitArray(3);
            Assert.AreEqual(3, bits.Length);
            Assert.IsFalse(bits[0]);
            Assert.IsFalse(bits[1]);
            Assert.IsFalse(bits[2]);

            // Update (Set bits)
            bits[0] = true;
            bits[1] = true;

            // Read (Check values)
            Assert.IsTrue(bits[0]);
            Assert.IsTrue(bits[1]);
            Assert.IsFalse(bits[2]);

            // Simulate Delete (Set back to false)
            bits[0] = false;
            Assert.IsFalse(bits[0]);
        }

        // 7. StructuralComparisons allows deep comparison of collections.
        [TestMethod]
        public void Test_StructuralComparisons_ArraysEquality()
        {
            // Create
            int[] a = { 1, 2, 3 };
            int[] b = { 1, 2, 3 };
            int[] c = { 3, 2, 1 };
            int[] d = null;

            // Read / Equality Check
            bool areEqualAB = StructuralComparisons.StructuralEqualityComparer.Equals(a, b);
            Assert.IsTrue(areEqualAB, "Arrays a and b have same elements in same order");

            bool areEqualAC = StructuralComparisons.StructuralEqualityComparer.Equals(a, c);
            Assert.IsFalse(areEqualAC, "Arrays a and c differ in order");

            // Update
            b[2] = 5;  // Change one value
            bool areEqualAfterUpdate = StructuralComparisons.StructuralEqualityComparer.Equals(a, b);
            Assert.IsFalse(areEqualAfterUpdate, "Arrays differ after update");

            // Null check (Delete-like scenario)
            bool areEqualWithNull = StructuralComparisons.StructuralEqualityComparer.Equals(a, d);
            Assert.IsFalse(areEqualWithNull, "Comparing array to null should return false");
        }

        // 8. CaseInsensitiveComparer compares strings without case sensitivity.
        [TestMethod]
        public void Test_CaseInsensitiveHashCodeProvider_HashCodes()
        {
            CaseInsensitiveHashCodeProvider provider = new CaseInsensitiveHashCodeProvider();

            int hash1 = provider.GetHashCode("test");
            int hash2 = provider.GetHashCode("TEST");

            Assert.AreEqual(hash1, hash2);
        }


    }
}
