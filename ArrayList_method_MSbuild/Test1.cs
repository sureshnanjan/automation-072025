using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterfaceTests
{
    [TestClass]
    public class InterfaceDemoTests
    {
        [TestMethod]
        public void TestIEnumerableAndIEnumerator()
        {
            MyEnumerable numbers = new MyEnumerable();
            int[] expected = { 1, 2, 3 };
            int i = 0;
            foreach (var num in numbers)
            {
                Assert.AreEqual(expected[i], num);
                i++;
            }
        }

        [TestMethod]
        public void TestICollection()
        {
            MyCollection myCol = new MyCollection();
            Assert.AreEqual(3, myCol.Count);
        }

        [TestMethod]
        public void TestIComparer()
        {
            IComparer comparer = new DescendingComparer();
            int result = comparer.Compare(5, 10);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void TestIDictionaryAndEnumerator()
        {
            IDictionary dict = new Hashtable
            {
                ["Name"] = "Keyur",
                ["Age"] = 22
            };

            IDictionaryEnumerator denum = dict.GetEnumerator();
            int count = 0;
            while (denum.MoveNext())
            {
                Assert.IsNotNull(denum.Key);
                Assert.IsNotNull(denum.Value);
                count++;
            }
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TestIEqualityComparer()
        {
            IEqualityComparer eq = new CaseInsensitiveComparer();
            bool result = eq.Equals("hello", "HELLO");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIHashCodeProvider()
        {
#pragma warning disable SYSLIB0035 // IHashCodeProvider is obsolete
            IHashCodeProvider hashProvider = new MyHashCodeProvider();
            int hash = hashProvider.GetHashCode("hello");
#pragma warning restore SYSLIB0035
            Assert.AreEqual(5, hash);
        }

        [TestMethod]
        public void TestIList()
        {
            IList list = new ArrayList() { 1, 2, 3 };
            list.Add(4);
            CollectionAssert.AreEqual(new ArrayList() { 1, 2, 3, 4 }, list);
        }

        [TestMethod]
        public void TestIStructuralComparable()
        {
            var t1 = Tuple.Create(1, 2);
            var t2 = Tuple.Create(1, 3);
            var result = ((IStructuralComparable)t1).CompareTo(t2, Comparer<int>.Default);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestIStructuralEquatable()
        {
            int[] a = { 1, 2 };
            int[] b = { 1, 2 };
            bool result = ((IStructuralEquatable)a).Equals(b, EqualityComparer<int>.Default);
            Assert.IsTrue(result);
        }
    }

    // IEnumerable & IEnumerator
    public class MyEnumerable : IEnumerable
    {
        private int[] numbers = { 1, 2, 3 };
        public IEnumerator GetEnumerator() => numbers.GetEnumerator();
    }

    // ICollection
    public class MyCollection : ICollection
    {
        private int[] data = { 1, 2, 3 };
        public int Count => data.Length;
        public bool IsSynchronized => false;
        public object SyncRoot => this;
        public void CopyTo(Array array, int index) => data.CopyTo(array, index);
        public IEnumerator GetEnumerator() => data.GetEnumerator();
    }

    // IComparer
    public class DescendingComparer : IComparer
    {
        public int Compare(object x, object y) => Comparer.Default.Compare(y, x);
    }

    // IEqualityComparer
    public class CaseInsensitiveComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y) =>
            string.Equals(x?.ToString(), y?.ToString(), StringComparison.OrdinalIgnoreCase);

        public int GetHashCode(object obj) =>
            obj.ToString().ToLowerInvariant().GetHashCode();
    }

    // IHashCodeProvider (obsolete)
    public class MyHashCodeProvider : IHashCodeProvider
    {
        public int GetHashCode(object obj) => obj.ToString().Length;
    }
}