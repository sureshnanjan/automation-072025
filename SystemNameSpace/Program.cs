using System;
using System.Collections; // Includes legacy non-generic collections and interfaces

// Entry point of the program
class Program
{
    static void Main()
    {
        // Demonstrating IEnumerable and IEnumerator
        Console.WriteLine("IEnumerable & IEnumerator:");
        MyEnumerable numbers = new MyEnumerable();
        foreach (var num in numbers) // Calls GetEnumerator internally
            Console.WriteLine(num);  // Prints 1, 2, 3

        // Demonstrating ICollection interface
        Console.WriteLine("\nICollection:");
        MyCollection myCol = new MyCollection();
        Console.WriteLine("Count: " + myCol.Count); // Count should be 3

        // Demonstrating IComparer interface for custom sorting
        Console.WriteLine("\nIComparer:");
        IComparer comparer = new DescendingComparer();
        Console.WriteLine(comparer.Compare(5, 10)); // Outputs 1 because 10 > 5 in descending

        // Demonstrating IDictionary and IDictionaryEnumerator
        Console.WriteLine("\nIDictionary & IDictionaryEnumerator:");
        IDictionary dict = new Hashtable();
        dict["Name"] = "Keyur";
        dict["Age"] = 22;
        IDictionaryEnumerator denum = dict.GetEnumerator();
        while (denum.MoveNext())
            Console.WriteLine($"{denum.Key}: {denum.Value}"); // Outputs key-value pairs

        // Demonstrating IEqualityComparer
        Console.WriteLine("\nIEqualityComparer:");
        IEqualityComparer eq = new CaseInsensitiveComparer();
        Console.WriteLine(eq.Equals("hello", "HELLO")); // True because case is ignored

        // Demonstrating IHashCodeProvider (Obsolete)
        Console.WriteLine("\nIHashCodeProvider:");
        IHashCodeProvider hashProvider = new MyHashCodeProvider();
        Console.WriteLine(hashProvider.GetHashCode("hello")); // Outputs length = 5

        // Demonstrating IList
        Console.WriteLine("\nIList:");
        IList list = new ArrayList() { 1, 2, 3 };
        list.Add(4); // Adds 4 to the list
        foreach (var item in list)
            Console.Write(item + " "); // Outputs: 1 2 3 4

        // Demonstrating IStructuralComparable with Tuple
        Console.WriteLine("\n\nIStructuralComparable:");
        var t1 = Tuple.Create(1, 2);
        var t2 = Tuple.Create(1, 3);
        Console.WriteLine(((IStructuralComparable)t1).CompareTo(t2, Comparer<int>.Default)); // -1 since 2 < 3

        // Demonstrating IStructuralEquatable with arrays
        Console.WriteLine("\nIStructuralEquatable:");
        int[] a = { 1, 2 };
        int[] b = { 1, 2 };
        Console.WriteLine(((IStructuralEquatable)a).Equals(b, EqualityComparer<int>.Default)); // True
    }
}

// Custom class implementing IEnumerable using an array
class MyEnumerable : IEnumerable
{
    private int[] numbers = { 1, 2, 3 };

    // Returns enumerator to allow iteration using foreach
    public IEnumerator GetEnumerator() => numbers.GetEnumerator();
}

// Custom collection implementing ICollection
class MyCollection : ICollection
{
    private int[] data = { 1, 2, 3 };

    public int Count => data.Length;
    public bool IsSynchronized => false; // No thread safety
    public object SyncRoot => this;      // Used for synchronization
    public void CopyTo(Array array, int index) => data.CopyTo(array, index); // Copies data to another array
    public IEnumerator GetEnumerator() => data.GetEnumerator(); // Enables foreach iteration
}

// Custom comparer for sorting in descending order
class DescendingComparer : IComparer
{
    public int Compare(object x, object y) => Comparer.Default.Compare(y, x); // Reverses order
}

// Custom equality comparer (case-insensitive)
class CaseInsensitiveComparer : IEqualityComparer
{
    // Compares strings ignoring case
    public new bool Equals(object x, object y) =>
        string.Equals(x?.ToString(), y?.ToString(), StringComparison.OrdinalIgnoreCase);

    // Generates hash code based on lowercase value
    public int GetHashCode(object obj) =>
        obj.ToString().ToLowerInvariant().GetHashCode();
}

// Obsolete interface - demonstration only
class MyHashCodeProvider : IHashCodeProvider
{
    // Returns hash based on length of string
    public int GetHashCode(object obj) => obj.ToString().Length;
}
