// Author: Siva Sree
// Date Created: 2025-07-27
// Copyright (c) 2025 Siva Sree
// All Rights Reserved.
//
// Description:
// This C# file demonstrates the use of System.Collections.ArrayList and
// its interfaces: IList, ICollection, IEnumerable, and ICloneable.
// It performs various operations on a dynamic list of numbers such as
// adding, inserting, cloning, copying, and iterating using interface methods.

using System;
using System.Collections;

namespace InterfaceDemo
{
    /// <summary>
    /// Demonstrates complete usage of ArrayList and its related interfaces
    /// using integer values. Covers interface methods and properties.
    /// </summary>
    public class ArrayListInterfaceExample
    {
        /// <summary>
        /// Main execution method showing interface usage on ArrayList.
        /// </summary>
        public static void Main()
        {
            // 1. Create an ArrayList instance using the default constructor
            ArrayList numbers = new ArrayList();

            // 2. Add elements using IList.Add()
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);

            // 3. Insert element at specific index using IList.Insert()
            numbers.Insert(1, 15); // Inserts 15 at index 1

            // 4. Display all elements using IEnumerable via foreach loop
            Console.WriteLine("ArrayList elements:");
            foreach (int num in numbers)
            {
                Console.WriteLine($"- {num}");
            }

            // 5. Access element by index using IList indexer
            Console.WriteLine($"\nElement at index 2: {numbers[2]}");

            // 6. Check if a value exists using IList.Contains()
            Console.WriteLine($"Contains 30? {numbers.Contains(30)}");

            // 7. Get index of an element using IList.IndexOf()
            Console.WriteLine($"Index of 15: {numbers.IndexOf(15)}");

            // 8. Remove an element using IList.Remove()
            numbers.Remove(20);
            Console.WriteLine("\nAfter removing 20:");
            foreach (int num in numbers)
            {
                Console.WriteLine($"- {num}");
            }

            // 9. Get count using ICollection.Count
            Console.WriteLine($"\nCount of elements: {numbers.Count}");

            // 10. Copy to an array using ICollection.CopyTo()
            int[] numArray = new int[numbers.Count];
            numbers.CopyTo(numArray);

            Console.WriteLine("\nCopied to array:");
            foreach (int val in numArray)
            {
                Console.WriteLine($"- {val}");
            }

            // 11. Clone the ArrayList using ICloneable.Clone()
            ArrayList clonedNumbers = (ArrayList)numbers.Clone();
            Console.WriteLine("\nCloned ArrayList:");
            foreach (int value in clonedNumbers)
            {
                Console.WriteLine($"- {value}");
            }

            // 12. Clear all elements using IList.Clear()
            numbers.Clear();
            Console.WriteLine($"\nAfter clearing: Count = {numbers.Count}");
        }
    }
}

