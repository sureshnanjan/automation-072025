using System;
using System.Collections;

namespace ArrayListDemo
{
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

            // AddRange
            myList.AddRange(new string[] { "Date", "Elderberry" });

            // Insert
            myList.Insert(1, "Blueberry");

            // InsertRange
            myList.InsertRange(0, new string[] { "Avocado", "Apricot" });

            Console.WriteLine("\nAfter AddRange, Insert, InsertRange:");
            PrintList(myList);

            // Contains
            Console.WriteLine($"\nContains 'Cherry'? {myList.Contains("Cherry")}");

            // IndexOf / LastIndexOf
            Console.WriteLine($"Index of 'Banana': {myList.IndexOf("Banana")}");
            Console.WriteLine($"Last Index of 'Banana': {myList.LastIndexOf("Banana")}");

            // GetRange
            ArrayList rangeList = myList.GetRange(2, 3);
            Console.WriteLine("\nGetRange (2, 3):");
            PrintList(rangeList);

            // Clone
            ArrayList clonedList = (ArrayList)myList.Clone();
            Console.WriteLine("\nCloned List:");
            PrintList(clonedList);

            // Reverse
            clonedList.Reverse();
            Console.WriteLine("\nReversed Cloned List:");
            PrintList(clonedList);

            // Sort
            clonedList.Sort();
            Console.WriteLine("\nSorted Cloned List:");
            PrintList(clonedList);

            // Remove / RemoveAt / RemoveRange
            myList.Remove("Banana");
            myList.RemoveAt(0);
            myList.RemoveRange(0, 2);
            Console.WriteLine("\nAfter Remove, RemoveAt, RemoveRange:");
            PrintList(myList);

            // ToArray
            object[] objArray = myList.ToArray();
            Console.WriteLine("\nToArray Result:");
            foreach (var item in objArray)
                Console.WriteLine(item);

            // TrimToSize
            myList.TrimToSize();

            // Synchronized
            ArrayList syncList = ArrayList.Synchronized(myList);

            // FixedSize / ReadOnly
            ArrayList fixedSizeList = ArrayList.FixedSize(myList);
            ArrayList readOnlyList = ArrayList.ReadOnly(myList);

            // Adapter
            IList ilist = new string[] { "X", "Y", "Z" };
            ArrayList adaptedList = ArrayList.Adapter(ilist);

            // BinarySearch
            ArrayList numbers = new ArrayList() { 1, 3, 5, 7, 9 };
            int index = numbers.BinarySearch(5); // should return 2
            Console.WriteLine($"\nBinary Search for 5 in sorted numbers: Index {index}");

            // SetRange
            numbers.SetRange(1, new int[] { 10, 11 });
            Console.WriteLine("\nSetRange at index 1 with [10, 11]:");
            PrintList(numbers);

            // Repeat
            ArrayList repeated = ArrayList.Repeat("Hello", 3);
            Console.WriteLine("\nArrayList.Repeat(\"Hello\", 3):");
            PrintList(repeated);
        }

        static void PrintList(ArrayList list)
        {
            foreach (var item in list)
                Console.Write(item + " ");
            Console.WriteLine();
        }
    }
}
