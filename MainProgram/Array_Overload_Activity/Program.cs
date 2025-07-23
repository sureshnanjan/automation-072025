using System;
using System.Collections;
using System.Collections.Generic;

class Class1
{
    /// <summary>
    /// Demonstrates all overloads of Array.BinarySearch methods with documentation and test cases.
    /// </summary>
    static void Main()
    {
        Console.WriteLine("--- BinarySearch Overloads Demonstration ---\n");

        // 1. BinarySearch(Array, Object)
        // ❖ Searches entire array using IComparable.
        int[] numbers = { 10, 20, 30, 40, 50 };
        int index1 = Array.BinarySearch(numbers, 30);
        Console.WriteLine("BinarySearch(Array, Object): Index of 30 is " + index1);

        // 2. BinarySearch(Array, Object, IComparer)
        // ❖ Uses custom IComparer.
        string[] names = { "Alice", "Bob", "Charlie" };
        int index2 = Array.BinarySearch(names, "bob", StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("BinarySearch(Array, Object, IComparer): Index of 'bob' is " + index2);

        // 3. BinarySearch(Array, Int32, Int32, Object)
        // ❖ Searches a range using IComparable.
        int[] rangeTest = { 5, 10, 15, 20, 25, 30 };
        int index3 = Array.BinarySearch(rangeTest, 1, 4, 20);
        Console.WriteLine("BinarySearch(Array, Int, Int, Object): Index of 20 in range(1-4) is " + index3);

        // 4. BinarySearch(Array, Int32, Int32, Object, IComparer)
        // ❖ Searches a range using IComparer.
        string[] fruits = { "Apple", "Banana", "Grape", "Orange", "Peach" };
        int index4 = Array.BinarySearch(fruits, 1, 3, "grape", StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("BinarySearch(Array, Int, Int, Object, IComparer): Index of 'grape' is " + index4);

        // 5. BinarySearch<T>(T[], T)
        // ❖ Generic method using IComparable<T>.
        double[] doubles = { 1.1, 2.2, 3.3, 4.4 };
        int index5 = Array.BinarySearch(doubles, 3.3);
        Console.WriteLine("BinarySearch<T>(T[], T): Index of 3.3 is " + index5);

        // 6. BinarySearch<T>(T[], T, IComparer<T>)
        // ❖ Generic method with custom IComparer<T>.
        string[] planets = { "Earth", "Mars", "Venus" };
        int index6 = Array.BinarySearch(planets, "venus", StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("BinarySearch<T>(T[], T, IComparer<T>): Index of 'venus' is " + index6);

        // 7. BinarySearch<T>(T[], Int32, Int32, T)
        // ❖ Generic method searching a range with IComparable<T>.
        char[] letters = { 'a', 'b', 'c', 'd', 'e' };
        int index7 = Array.BinarySearch(letters, 1, 3, 'c');
        Console.WriteLine("BinarySearch<T>(T[], Int, Int, T): Index of 'c' is " + index7);

        // 8. BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>)
        // ❖ Generic method searching a range with IComparer<T>.
        string[] colors = { "Blue", "Green", "Red", "Yellow" };
        int index8 = Array.BinarySearch(colors, 0, 3, "red", StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("BinarySearch<T>(T[], Int, Int, T, IComparer<T>): Index of 'red' is " + index8);

        Console.WriteLine("\n--- End of BinarySearch Overloads ---");
    }
}

/*
 Summary of BinarySearch overloads:
 1. BinarySearch(Array, Object): Uses IComparable to search entire array.
 2. BinarySearch(Array, Object, IComparer): Uses IComparer to search entire array.
 3. BinarySearch(Array, Int32, Int32, Object): Uses IComparable to search part of array.
 4. BinarySearch(Array, Int32, Int32, Object, IComparer): Uses IComparer to search part of array.
 5. BinarySearch<T>(T[], T): Generic version using IComparable<T>.
 6. BinarySearch<T>(T[], T, IComparer<T>): Generic with IComparer<T>.
 7. BinarySearch<T>(T[], Int32, Int32, T): Generic with IComparable<T> and range.
 8. BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>): Generic with IComparer<T> and range.
*/
