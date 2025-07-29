using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace SystemCollectionsTests
{
    public class ValidatingCollection : CollectionBase
    {
        public void Add(object item) => List.Add(item);
        public void Remove(object item) => List.Remove(item);

        public object this[int index] => List[index];

        protected override void OnInsert(int index, object value)
        {
            if (value == null)
                throw new System.ArgumentNullException(nameof(value), "Nulls not allowed");
        }

        protected override void OnRemove(int index, object value)
        {
            if (value.Equals("Protected"))
                throw new System.InvalidOperationException("Protected item cannot be removed");
        }
    }

    [TestClass]
    public class CollectionBaseTests
    {
        [TestMethod]
        public void Add_And_IndexAccess()
        {
            var col = new ValidatingCollection();
            col.Add("One");
            col.Add("Two");
            Assert.AreEqual("One", col[0]);
        }

        [TestMethod]
        public void Add_Null_Throws()
        {
            var col = new ValidatingCollection();
            Assert.ThrowsException<System.ArgumentNullException>(() => col.Add(null));
        }

        [TestMethod]
        public void Remove_ProtectedItem_Throws()
        {
            var col = new ValidatingCollection();
            col.Add("Protected");
            Assert.ThrowsException<System.InvalidOperationException>(() => col.Remove("Protected"));
        }
    }
}
