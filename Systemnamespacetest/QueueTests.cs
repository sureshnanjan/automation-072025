using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace SystemCollectionsTests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void Enqueue_And_Dequeue()
        {
            Queue q = new Queue();
            q.Enqueue("first");
            q.Enqueue("second");

            Assert.AreEqual("first", q.Dequeue());
            Assert.AreEqual("second", q.Dequeue());
        }

        [TestMethod]
        public void Peek_ReturnsFrontWithoutRemoving()
        {
            Queue q = new Queue();
            q.Enqueue("alpha");
            Assert.AreEqual("alpha", q.Peek());
            Assert.AreEqual("alpha", q.Dequeue());
        }

        [TestMethod]
        public void Count_ReflectsQueueSize()
        {
            Queue q = new Queue();
            q.Enqueue(1);
            q.Enqueue(2);
            Assert.AreEqual(2, q.Count);
            q.Dequeue();
            Assert.AreEqual(1, q.Count);
        }

        [TestMethod]
        public void Clear_EmptiesQueue()
        {
            Queue q = new Queue();
            q.Enqueue("x");
            q.Clear();
            Assert.AreEqual(0, q.Count);
        }

        [TestMethod]
        public void Contains_ChecksForExistence()
        {
            Queue q = new Queue();
            q.Enqueue("item");
            Assert.IsTrue(q.Contains("item"));
            Assert.IsFalse(q.Contains("none"));
        }

        [TestMethod]
        public void Enumerator_IteratesInOrder()
        {
            Queue q = new Queue();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            var list = new ArrayList();
            foreach (var item in q)
                list.Add(item);

            CollectionAssert.AreEqual(new object[] { 1, 2, 3 }, list);
        }
    }
}
