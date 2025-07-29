using System;
using System.Collections;

public class Example
{
    public class ReverserClass : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(y, x));
        }
    }

    internal class secondcharcterClass : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return (x[1].CompareTo(y[1]));
        }

        // Call CaseInsensitiveComparer.Compare with the parameters reversed.

    }

    public static void Main()
    {
        // Initialize a string array.
        string[] words = { "The", "quick", "brown", "fox", "jumps", "over",
                         "the", "lazy", "dog" };

        // Display the array values.
        Console.WriteLine("The array initially contains the following values:");
        PrintIndexAndValues(words);

        // Sort the array values using the default comparer.
        Array.Sort(words);
        Console.WriteLine("After sorting with the default comparer:");
        PrintIndexAndValues(words);

        Array.Sort(words, new secondcharcterClass());
        Console.WriteLine("comparing using the second character:");
        PrintIndexAndValues(words);



        // Sort the array values using the reverse case-insensitive comparer.
        Array.Sort(words, new ReverserClass());
        Console.WriteLine("After sorting with the reverse case-insensitive comparer:");
        PrintIndexAndValues(words);
    }

    public static void PrintIndexAndValues(IEnumerable list)
    {
        int i = 0;
        foreach (var item in list)
            Console.WriteLine($"   [{i++}]:  {item}");

        Console.WriteLine();
    }
}

