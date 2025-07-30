using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoInterfaces.Tests
{
    // =====================
    // Interface Implementations
    // =====================

    public class MyEnumerable : IEnumerable
    {
        private int[] numbers = { 1, 2, 3 };
        public IEnumerator GetEnumerator() => numbers.GetEnumerator();
    }

    public class MyCollection : ICollection
    {
        private int[] data = { 1, 2, 3 };
        public int Count => data.Length;
        public bool IsSynchronized => false;
        public object SyncRoot => this;
        public void CopyTo(Array array, int index) => data.CopyTo(array, index);
        public IEnumerator GetEnumerator() => data.GetEnumerator();
    }

    public class DescendingComparer : IComparer
    {
        public int Compare(object x, object y) => Comparer.Default.Compare(y, x);
    }

    public class CaseInsensitiveComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y) =>
            string.Equals(x?.ToString(), y?.ToString(), StringComparison.OrdinalIgnoreCase);
        public int GetHashCode(object obj) =>
            obj.ToString().ToLowerInvariant().GetHashCode();
    }

    public class MyHashCodeProvider : IHashCodeProvider
    {
        public int GetHashCode(object obj) => obj.ToString().Length;
    }

    // =====================
    // MSTest Unit Tests
    // =====================

    [TestClass]
    public class InterfaceTests
    {
        [TestMethod]
        public void IEnumerable_Test()
        {
            var enumerable = new MyEnumerable();
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, enumerable.Cast<int>().ToArray());
        }

        [TestMethod]
        public void ICollection_Test()
        {
            var collection = new MyCollection();
            Assert.AreEqual(3, collection.Count);
            Assert.IsFalse(collection.IsSynchronized);

            Array arr = new int[3];
            collection.CopyTo(arr, 0);
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, arr);
        }

        [TestMethod]
        public void IComparer_Test()
        {
            IComparer comparer = new DescendingComparer();

            // In descending: Compare(5, 2) = -1 because 2 > 5
            Assert.IsTrue(comparer.Compare(5, 2) < 0);

            Assert.AreEqual(0, comparer.Compare(3, 3));

            // In descending: Compare(1, 10) = 1 because 10 < 1
            Assert.IsTrue(comparer.Compare(1, 10) > 0);
        }

        [TestMethod]
        public void IDictionary_IDictionaryEnumerator_Test()
        {
            IDictionary dict = new Hashtable
            {
                ["Name"] = "Keyur",
                ["Age"] = 22
            };

            IDictionaryEnumerator enumerator = dict.GetEnumerator();
            var items = new Dictionary<string, object>();
            while (enumerator.MoveNext())
            {
                items.Add(enumerator.Key.ToString(), enumerator.Value);
            }

            Assert.AreEqual("Keyur", items["Name"]);
            Assert.AreEqual(22, items["Age"]);
        }

        [TestMethod]
        public void IEqualityComparer_Test()
        {
            IEqualityComparer comparer = new CaseInsensitiveComparer();
            Assert.IsTrue(comparer.Equals("Hello", "hello"));
            Assert.AreEqual("abc".ToLowerInvariant().GetHashCode(), comparer.GetHashCode("ABC"));
        }

        [TestMethod]
        public void IHashCodeProvider_Test()
        {
            IHashCodeProvider provider = new MyHashCodeProvider();
            Assert.AreEqual(5, provider.GetHashCode("Hello"));
            Assert.AreEqual(0, provider.GetHashCode(""));
        }

        [TestMethod]
        public void IList_Test()
        {
            IList list = new ArrayList() { 1, 2, 3 };
            list.Add(4);
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, list.Cast<int>().ToArray());
        }

        [TestMethod]
        public void IStructuralComparable_Test()
        {
            var t1 = Tuple.Create(1, 2);
            var t2 = Tuple.Create(1, 3);
            int result = ((IStructuralComparable)t1).CompareTo(t2, Comparer<int>.Default);
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void IStructuralEquatable_Test()
        {
            int[] arr1 = { 1, 2 };
            int[] arr2 = { 1, 2 };
            bool equal = ((IStructuralEquatable)arr1).Equals(arr2, EqualityComparer<int>.Default);
            Assert.IsTrue(equal);
        }
    }
}