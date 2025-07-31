using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace SystemCollectionsTests
{
    // Custom DictionaryBase implementation with validation hooks
    public class MyDictionary : DictionaryBase
    {
        public bool OnInsertCalled = false;
        public bool OnRemoveCalled = false;
        public bool OnClearCalled = false;

        public void Add(object key, object value)
        {
            Dictionary.Add(key, value);
        }

        public void Remove(object key)
        {
            Dictionary.Remove(key);
        }

        public bool Contains(object key) => Dictionary.Contains(key);

        public object this[object key]
        {
            get => Dictionary[key];
            set => Dictionary[key] = value;
        }

        protected override void OnInsert(object key, object value)
        {
            OnInsertCalled = true;
            if (key == null) throw new System.ArgumentNullException(nameof(key), "Key cannot be null");
        }

        protected override void OnRemove(object key, object value)
        {
            OnRemoveCalled = true;
        }

        protected override void OnClear()
        {
            OnClearCalled = true;
        }
    }

    [TestClass]
    public class DictionaryBaseTests
    {
        [TestMethod]
        public void Add_ValidEntry_ShouldBeStored()
        {
            var dict = new MyDictionary();
            dict.Add("id", 123);
            Assert.AreEqual(123, dict["id"]);
            Assert.AreEqual(1, dict.Count);
            Assert.IsTrue(dict.OnInsertCalled);
        }

        [TestMethod]
        public void Add_NullKey_ShouldThrow()
        {
            var dict = new MyDictionary();
            Assert.ThrowsException<System.ArgumentNullException>(() => dict.Add(null, "value"));
        }

        [TestMethod]
        public void Indexer_GetAndSet_ShouldWork()
        {
            var dict = new MyDictionary();
            dict.Add("name", "Alice");
            Assert.AreEqual("Alice", dict["name"]);

            dict["name"] = "Bob";
            Assert.AreEqual("Bob", dict["name"]);
        }

        [TestMethod]
        public void Remove_Item_ShouldBeRemoved()
        {
            var dict = new MyDictionary();
            dict.Add("k", "v");
            dict.Remove("k");
            Assert.IsFalse(dict.Contains("k"));
            Assert.AreEqual(0, dict.Count);
            Assert.IsTrue(dict.OnRemoveCalled);
        }

        [TestMethod]
        public void Contains_ShouldReturnCorrectly()
        {
            var dict = new MyDictionary();
            dict.Add("x", 1);
            Assert.IsTrue(dict.Contains("x"));
            Assert.IsFalse(dict.Contains("y"));
        }

        [TestMethod]
        public void Clear_ShouldRemoveAllAndTriggerHook()
        {
            var dict = new MyDictionary();
            dict.Add("a", 1);
            dict.Add("b", 2);
            dict.Clear();

            Assert.AreEqual(0, dict.Count);
            Assert.IsTrue(dict.OnClearCalled);
        }
    }
}
