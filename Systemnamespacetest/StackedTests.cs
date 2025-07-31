using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace SystemCollectionsTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Push_Pop_Peek()
        {
            Stack s = new Stack();
            s.Push("first");
            s.Push("second");
            Assert.AreEqual("second", s.Peek());
            Assert.AreEqual("second", s.Pop());
            Assert.AreEqual("first", s.Pop());
        }

        [TestMethod]
        public void CountAndClear()
        {
            Stack s = new Stack(new[] { 1, 2, 3 });
            Assert.AreEqual(3, s.Count);
            s.Clear();
            Assert.AreEqual(0, s.Count);
        }

        [TestMethod]
        public void Contains_Check_And_GetEnumerator()
        {
            Stack s = new Stack(new[] { "a", "b", "c" });
            Assert.IsTrue(s.Contains("b"));
            var arr = new ArrayList();
            foreach (var item in s)
                arr.Add(item);
            CollectionAssert.AreEqual(new object[] { "c", "b", "a" }, arr);
        }
    }
}
