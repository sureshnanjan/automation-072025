using System;
using System.Collections;

namespace ArrayListDemo
{
    /// <summary>
    /// Demonstrates various methods and properties of the ArrayList class.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ArrayList Method Demonstration - by Keyur Nagvekar\n");

            // Initialize and populate ArrayList
            ArrayList myList = new ArrayList();
            myList.Add("Apple");
            myList.Add("Banana");
            myList.Add("Cherry");

            Console.WriteLine("Initial List:");
            PrintList(myList);

            // AddRange: Adds multiple items at once
            myList.AddRange(new string[] { "Date", "Elderberry" });

            // Insert: Inserts item at a specific index
            myList.Insert(1, "Blueberry");

            // InsertRange: Inserts multiple items at a specified index
            myList.InsertRange(0, new string[] { "Avocado", "Apricot" });

            Console.WriteLine("\nAfter AddRange, Insert, InsertRange:");
            PrintList(myList);

            // Contains: Checks if an item exists in the list
            Console.WriteLine($"\nContains 'Cherry'? {myList.Contains("Cherry")}");

            // IndexOf and LastIndexOf: Finds first and last occurrence index of an item
            Console.WriteLine($"Index of 'Banana': {myList.IndexOf("Banana")}");
            Console.WriteLine($"Last Index of 'Banana': {myList.LastIndexOf("Banana")}");

            // GetRange: Returns a subset of the ArrayList
            ArrayList rangeList = myList.GetRange(2, 3);
            Console.WriteLine("\nGetRange (2, 3):");
            PrintList(rangeList);

            // Clone: Creates a shallow copy of the ArrayList
            ArrayList clonedList = (ArrayList)myList.Clone();
            Console.WriteLine("\nCloned List:");
            PrintList(clonedList);

            // Reverse: Reverses the order of elements in-place
            clonedList.Reverse();
            Console.WriteLine("\nReversed Cloned List:");
            PrintList(clonedList);

            // Sort: Sorts the elements in ascending order
            clonedList.Sort();
            Console.WriteLine("\nSorted Cloned List:");
            PrintList(clonedList);

            // Remove: Removes the first occurrence of the specified object
            // RemoveAt: Removes item at a specific index
            // RemoveRange: Removes a range of elements
            myList.Remove("Banana");
            myList.RemoveAt(0);
            myList.RemoveRange(0, 2);
            Console.WriteLine("\nAfter Remove, RemoveAt, RemoveRange:");
            PrintList(myList);

            // ToArray: Converts ArrayList to a standard object array
            object[] objArray = myList.ToArray();
            Console.WriteLine("\nToArray Result:");
            foreach (var item in objArray)
                Console.WriteLine(item);

            // TrimToSize: Sets the capacity to the actual number of elements
            myList.TrimToSize();

            // Synchronized: Returns a thread-safe version of the ArrayList
            ArrayList syncList = ArrayList.Synchronized(myList);

            // FixedSize: Returns a wrapper with fixed-size behavior (no add/remove)
            ArrayList fixedSizeList = ArrayList.FixedSize(myList);

            // ReadOnly: Returns a read-only wrapper over the ArrayList
            ArrayList readOnlyList = ArrayList.ReadOnly(myList);

            // Adapter: Wraps an IList into an ArrayList
            IList ilist = new string[] { "X", "Y", "Z" };
            ArrayList adaptedList = ArrayList.Adapter(ilist);

            // BinarySearch: Searches a sorted ArrayList and returns the index of an item
            ArrayList numbers = new ArrayList() { 1, 3, 5, 7, 9 };
            int index = numbers.BinarySearch(5); // Should return 2
            Console.WriteLine($"\nBinary Search for 5 in sorted numbers: Index {index}");

            // SetRange: Replaces elements in a range with items from another collection
            numbers.SetRange(1, new int[] { 10, 11 });
            Console.WriteLine("\nSetRange at index 1 with [10, 11]:");
            PrintList(numbers);

            // Repeat: Creates a new ArrayList with repeated elements
            ArrayList repeated = ArrayList.Repeat("Hello", 3);
            Console.WriteLine("\nArrayList.Repeat(\"Hello\", 3):");
            PrintList(repeated);
        }

        /// <summary>
        /// Helper method to print all elements in an ArrayList.
        /// </summary>
        /// <param name="list">The ArrayList to print.</param>
        static void PrintList(ArrayList list)
        {
            foreach (var item in list)
                Console.Write(item + " ");
            Console.WriteLine();
        }
    }
}

