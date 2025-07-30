// -----------------------------------------------------------------------------
// Author      : Arpita Neogi
// Date        : 28/07/25
// Description : Interface demonstration with unit tests (IEnumerable, ICollection, etc.)
// -----------------------------------------------------------------------------
// © 2025 Arpita Neogi. All rights reserved.
// -----------------------------------------------------------------------------

// Import necessary .NET namespaces
using System; // Provides fundamental classes and base classes like String, Int32, etc.
using System.Collections; // Provides non-generic collections like ArrayList, Hashtable, etc.
using System.Collections.Generic; // Provides generic collection interfaces and classes
using Microsoft.VisualStudio.TestTools.UnitTesting; // Required for writing unit tests with MSTest

namespace InterfaceTests // Declare a namespace for organizing related classes
{
    [TestClass] // Indicates this class contains unit tests
    public class InterfaceDemoTests
    {
        [TestMethod] // Marks this method as a test case
        public void TestIEnumerableAndIEnumerator()
        {
            MyEnumerable numbers = new MyEnumerable(); // Custom IEnumerable implementation
            int[] expected = { 1, 2, 3 }; // Expected values
            int i = 0; // Index for comparison

            foreach (var num in numbers) // Loop using IEnumerator
            {
                Assert.AreEqual(expected[i], num); // Verify each number matches expected
                i++; // Move to next index
            }
        }

        [TestMethod]
        public void TestICollection()
        {
            MyCollection myCol = new MyCollection(); // Custom ICollection implementation
            Assert.AreEqual(3, myCol.Count); // Verify count matches number of elements
        }

        [TestMethod]
        public void TestIComparer()
        {
            IComparer comparer = new DescendingComparer(); // Custom IComparer for descending order
            int result = comparer.Compare(5, 10); // Should return > 0 because 10 < 5 in descending
            Assert.IsTrue(result > 0); // Assert that result is positive
        }

        [TestMethod]
        public void TestIDictionaryAndEnumerator()
        {
            // Create dictionary with two entries
            IDictionary dict = new Hashtable
            {
                ["Name"] = "Keyur",
                ["Age"] = 22
            };

            // Get enumerator to iterate through dictionary
            IDictionaryEnumerator denum = dict.GetEnumerator();
            int count = 0; // Counter for items
            while (denum.MoveNext()) // Move to next key-value pair
            {
                Assert.IsNotNull(denum.Key); // Key should not be null
                Assert.IsNotNull(denum.Value); // Value should not be null
                count++; // Increment count
            }
            Assert.AreEqual(2, count); // Assert that there are 2 items
        }

        [TestMethod]
        public void TestIEqualityComparer()
        {
            IEqualityComparer eq = new CaseInsensitiveComparer(); // Custom comparer that ignores case
            bool result = eq.Equals("hello", "HELLO"); // Should return true
            Assert.IsTrue(result); // Assert that the comparison is successful
        }

        [TestMethod]
        public void TestIHashCodeProvider()
        {
#pragma warning disable SYSLIB0035 // Disable obsolete warning for IHashCodeProvider
            IHashCodeProvider hashProvider = new MyHashCodeProvider(); // Custom hash provider
            int hash = hashProvider.GetHashCode("hello"); // Returns 5 (length of "hello")
#pragma warning restore SYSLIB0035 // Restore warning
            Assert.AreEqual(5, hash); // Verify hash code
        }

        [TestMethod]
        public void TestIList()
        {
            IList list = new ArrayList() { 1, 2, 3 }; // Create a non-generic list
            list.Add(4); // Add item to list
            // Assert list contains expected items
            CollectionAssert.AreEqual(new ArrayList() { 1, 2, 3, 4 }, list);
        }

        [TestMethod]
        public void TestIStructuralComparable()
        {
            // Create two tuples
            var t1 = Tuple.Create(1, 2);
            var t2 = Tuple.Create(1, 3);
            // Compare using structural comparison
            var result = ((IStructuralComparable)t1).CompareTo(t2, Comparer<int>.Default);
            Assert.AreEqual(-1, result); // t1 is less than t2
        }

        [TestMethod]
        public void TestIStructuralEquatable()
        {
            int[] a = { 1, 2 }; // First array
            int[] b = { 1, 2 }; // Second array with same values
            // Check for structural equality (value-based)
            bool result = ((IStructuralEquatable)a).Equals(b, EqualityComparer<int>.Default);
            Assert.IsTrue(result); // Arrays should be equal
        }
    }

    // ======== INTERFACE IMPLEMENTATIONS =========

    // Custom implementation of IEnumerable
    public class MyEnumerable : IEnumerable
    {
        private int[] numbers = { 1, 2, 3 }; // Data source
        public IEnumerator GetEnumerator() => numbers.GetEnumerator(); // Return default enumerator
    }

    // Custom implementation of ICollection
    public class MyCollection : ICollection
    {
        private int[] data = { 1, 2, 3 }; // Data array
        public int Count => data.Length; // Return number of elements
        public bool IsSynchronized => false; // Not thread-safe
        public object SyncRoot => this; // Object used for synchronization
        public void CopyTo(Array array, int index) => data.CopyTo(array, index); // Copy elements
        public IEnumerator GetEnumerator() => data.GetEnumerator(); // Get enumerator for data
    }

    // Custom implementation of IComparer for descending order
    public class DescendingComparer : IComparer
    {
        public int Compare(object x, object y) => Comparer.Default.Compare(y, x); // Reverse comparison
    }

    // Custom IEqualityComparer that ignores case when comparing strings
    public class CaseInsensitiveComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y) =>
            string.Equals(x?.ToString(), y?.ToString(), StringComparison.OrdinalIgnoreCase); // Case-insensitive compare

        public int GetHashCode(object obj) =>
            obj.ToString().ToLowerInvariant().GetHashCode(); // Hash code based on lowercase string
    }

    // Obsolete interface IHashCodeProvider implementation
    public class MyHashCodeProvider : IHashCodeProvider
    {
        public int GetHashCode(object obj) => obj.ToString().Length; // Hash code is string length
    }
}
