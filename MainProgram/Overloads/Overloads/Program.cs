using System;
using System.Collections;
using System.Collections.Specialized;

namespace InterfaceDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== ICollection Example ===");
            MyCollection myCollection = new MyCollection();
            foreach (var item in myCollection)
                Console.WriteLine(item);

            Console.WriteLine("\n=== IComparer Example ===");
            ArrayList numbers = new ArrayList { 3, 1, 4, 2 };
            numbers.Sort(new ReverseComparer());
            foreach (var num in numbers)
                Console.WriteLine(num);

            Console.WriteLine("\n=== IDictionary Example ===");
            IDictionary dict = new Hashtable();
            dict["Name"] = "Arpita";
            dict["Role"] = "Tester";
            foreach (DictionaryEntry entry in dict)
                Console.WriteLine($"{entry.Key}: {entry.Value}");

            Console.WriteLine("\n=== IDictionaryEnumerator Example ===");
            IDictionaryEnumerator enumerator = dict.GetEnumerator();
            while (enumerator.MoveNext())
                Console.WriteLine($"{enumerator.Key} -> {enumerator.Value}");

            Console.WriteLine("\n=== IEnumerable and IEnumerator Example ===");
            foreach (var value in new MyEnumerable())
                Console.WriteLine(value);

            Console.WriteLine("\n=== IEqualityComparer Example ===");
            Hashtable eqTable = new Hashtable(new CaseInsensitiveComparer());
            eqTable["apple"] = "fruit";
            Console.WriteLine("Contains 'APPLE'? " + eqTable.Contains("APPLE"));

            Console.WriteLine("\n=== IHashCodeProvider Example ===");
            MyHashCodeProvider hashProvider = new MyHashCodeProvider();
            Console.WriteLine("Hash Code of 'Test': " + hashProvider.GetHashCode("Test"));

            Console.WriteLine("\n=== IList Example ===");
            IList myList = new ArrayList { "One", "Two", "Three" };
            Console.WriteLine("Index 1: " + myList[1]);

            Console.WriteLine("\n=== IStructuralComparable Example ===");
            IStructuralComparable tuple1 = Tuple.Create(1, 2);
            IStructuralComparable tuple2 = Tuple.Create(1, 3);
            Console.WriteLine("Compare tuples: " + tuple1.CompareTo(tuple2, Comparer.Default));

            Console.WriteLine("\n=== IStructuralEquatable Example ===");
            IStructuralEquatable tupleEq = Tuple.Create("a", "b");
            Console.WriteLine("Are tuples equal? " + tupleEq.Equals(Tuple.Create("A", "b"), StringComparer.OrdinalIgnoreCase));
        }
    }

    // ICollection Example
    public class MyCollection : ICollection
    {
        private string[] data = { "A", "B", "C" };

        public int Count => data.Length;
        public bool IsSynchronized => false;
        public object SyncRoot => this;
        public void CopyTo(Array array, int index) => data.CopyTo(array, index);
        public IEnumerator GetEnumerator() => data.GetEnumerator();
    }

    // IComparer Example
    public class ReverseComparer : IComparer
    {
        public int Compare(object x, object y) => ((int)y).CompareTo((int)x);
    }

    // IEqualityComparer Example
    public class CaseInsensitiveComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y) =>
            string.Equals(x.ToString(), y.ToString(), StringComparison.OrdinalIgnoreCase);

        public int GetHashCode(object obj) =>
            obj.ToString().ToLower().GetHashCode();
    }

    // IHashCodeProvider Example
    public class MyHashCodeProvider : IHashCodeProvider
    {
        public int GetHashCode(object obj) => obj.ToString().Length * 31;
    }

    // IEnumerable & IEnumerator Example
    public class MyEnumerable : IEnumerable
    {
        public IEnumerator GetEnumerator() => new MyEnumerator();
    }

    public class MyEnumerator : IEnumerator
    {
        private int position = -1;
        private string[] data = { "X", "Y", "Z" };

        public object Current => data[position];

        public bool MoveNext()
        {
            position++;
            return position < data.Length;
        }

        public void Reset() => position = -1;
    }
}
