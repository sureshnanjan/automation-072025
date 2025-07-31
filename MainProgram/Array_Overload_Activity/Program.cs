/*
* ----------------------------------------------------------------------------
* Title     : BinarySearch Overloads Demonstration in C#
* Author    : Keyur Nagvekar
* Created   : July 28, 2025
* Updated   : July 28, 2025
* License   : MIT License
*
* Copyright (c) 2025 Keyur Nagvekar
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* ----------------------------------------------------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Demonstrates all 8 overloads of Array.BinarySearch (non-generic and generic).
/// Includes documentation, console outputs, and practical test cases.
/// </summary>
class BinarySearchDemo
{
    static void Main()
    {
        Console.WriteLine("--- BinarySearch Overloads Demonstration ---\n");

        // 1. BinarySearch(Array, Object)
        // ❖ Searches entire array using IComparable.
        int[] numbers = { 10, 20, 30, 40, 50 };
        int index1 = Array.BinarySearch(numbers, 30);
        Console.WriteLine("1. BinarySearch(Array, Object): Index of 30 is " + index1);
        System.Diagnostics.Debug.Assert(index1 == 2);

        // 2. BinarySearch(Array, Object, IComparer)
        // ❖ Uses custom IComparer.
        string[] names = { "Alice", "Bob", "Charlie" };
        int index2 = Array.BinarySearch(names, "bob", StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("2. BinarySearch(Array, Object, IComparer): Index of 'bob' is " + index2);
        System.Diagnostics.Debug.Assert(index2 == 1);

        // 3. BinarySearch(Array, Int32, Int32, Object)
        // ❖ Searches a range using IComparable.
        int[] rangeTest = { 5, 10, 15, 20, 25, 30 };
        int index3 = Array.BinarySearch(rangeTest, 1, 4, 20);
        Console.WriteLine("3. BinarySearch(Array, Int, Int, Object): Index of 20 in range(1-4) is " + index3);
        System.Diagnostics.Debug.Assert(index3 == 3);

        // 4. BinarySearch(Array, Int32, Int32, Object, IComparer)
        // ❖ Searches a range using IComparer.
        string[] fruits = { "Apple", "Banana", "Grape", "Orange", "Peach" };
        int index4 = Array.BinarySearch(fruits, 1, 3, "grape", StringComparer.OrdinalIgnoreCase);
        Console.WriteLine("4. BinarySearch(Array, Int, Int, Object, IComparer): Index of 'grape' is " + index4);
        System.Diagnostics.Debug.Assert(index4 == 2);

        // 5. BinarySearch<T>(T[], T)
        // ❖ Generic method using IComparable<T>.
        double[] doubles = { 1.1, 2.2, 3.3, 4.4 };
        int index5 = Array.BinarySearch(doubles, 3.3);
        Console.WriteLine("5. BinarySearch<T>(T[], T): Index of 3.3 is " + index5);
        System.Diagnostics.Debug.Assert(index5 == 2);

        // 6. Binar
