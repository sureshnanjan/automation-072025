using System;
using System.Collections;

class Program
{
    static void Main()
    {
        // IEnumerable and IEnumerator
        Console.WriteLine("IEnumerable & IEnumerator:");
        MyEnumerable numbers = new MyEnumerable();
        foreach (var num in numbers)
            Console.WriteLine(num);

        // ICollection
        Console.WriteLine("\nICollection:");
        MyCollection myCol = new MyCollection();
        Console.WriteLine("Count: " + myCol.Count);

        // IComparer
        Console.WriteLine("\nIComparer:");
        IComparer comparer = new DescendingComparer();
        Console.WriteLine(comparer.Compare(5, 10)); // Output > 0

        // IDictionary, IDictionaryEnumerator
        Console.WriteLine("\nIDictionary & IDictionaryEnumerator:");
        IDictionary dict = new Hashtable();
        dict["Name"] = "Keyur";
        dict["Age"] = 22;
        IDictionaryEnumerator denum = dict.GetEnumerator();
        while (denum.MoveNext())
            Console.WriteLine($"{denum.Key}: {denum.Value}");

        // IEqualityComparer
        Console.WriteLine("\nIEqualityComparer:");
        IEqualityComparer eq = new CaseInsensitiveComparer();
        Console.WriteLine(eq.Equals("hello", "HELLO")); // True

        // IHashCodeProvider (obsolete, just for demo)
        Console.WriteLine("\nIHashCodeProvider:");
        IHashCodeProvider hashProvider = new MyHashCodeProvider();
        Console.WriteLine(hashProvider.GetHashCode("hello")); // Length of string

        // IList
        Console.WriteLine("\nIList:");
        IList list = new ArrayList() { 1, 2, 3 };
        list.Add(4);
        foreach (var item in list)
            Console.Write(item + " ");

        // IStructuralComparable
        Console.WriteLine("\n\nIStructuralComparable:");
        var t1 = Tuple.Create(1, 2);
        var t2 = Tuple.Create(1, 3);
        Console.WriteLine(((IStructuralComparable)t1).CompareTo(t2, Comparer<int>.Default)); // -1

        // IStructuralEquatable
        Console.WriteLine("\nIStructuralEquatable:");
        int[] a = { 1, 2 };
        int[] b = { 1, 2 };
        Console.WriteLine(((IStructuralEquatable)a).Equals(b, EqualityComparer<int>.Default)); // True
    }
}

// IEnumerable & IEnumerator
class MyEnumerable : IEnumerable
{
    private int[] numbers = { 1, 2, 3 };
    public IEnumerator GetEnumerator() => numbers.GetEnumerator();
}

// ICollection
class MyCollection : ICollection
{
    private int[] data = { 1, 2, 3 };
    public int Count => data.Length;
    public bool IsSynchronized => false;
    public object SyncRoot => this;
    public void CopyTo(Array array, int index) => data.CopyTo(array, index);
    public IEnumerator GetEnumerator() => data.GetEnumerator();
}

// IComparer
class DescendingComparer : IComparer
{
    public int Compare(object x, object y) => Comparer.Default.Compare(y, x);
}

// IEqualityComparer
class CaseInsensitiveComparer : IEqualityComparer
{
    public new bool Equals(object x, object y) =>
        string.Equals(x?.ToString(), y?.ToString(), StringComparison.OrdinalIgnoreCase);
    public int GetHashCode(object obj) =>
        obj.ToString().ToLowerInvariant().GetHashCode();
}

// IHashCodeProvider
class MyHashCodeProvider : IHashCodeProvider
{
    public int GetHashCode(object obj) => obj.ToString().Length;
}
