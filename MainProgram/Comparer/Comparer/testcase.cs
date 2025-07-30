using System;
using System.Collections;

namespace Comparer
{
    public class Program
    {
        // Reverse case-insensitive comparer
        public class ReverseCaseInsensitiveComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return (new CaseInsensitiveComparer()).Compare(y, x);
            }
        }

        // Comparer that compares the second character of strings
        public class SecondCharComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                string s1 = x as string;
                string s2 = y as string;

                if (s1 == null || s2 == null || s1.Length < 2 || s2.Length < 2)
                    throw new ArgumentException("Both objects must be strings with at least two characters.");

                return s1[1].CompareTo(s2[1]);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Running Console Tests...\n");

            Test_DefaultSort();
            Test_SortFromIndex1();
            Test_ReverseCaseInsensitiveComparer();
            Test_SecondCharComparer();

            Console.WriteLine("\nAll tests completed.");
        }

        static void Test_DefaultSort()
        {
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            Array.Sort(words);
            string[] expected = { "The", "brown", "dog", "fox", "jumps", "lazy", "over", "quick", "the" };

            PrintResult("Default Sort", words, expected);
        }

        static void Test_SortFromIndex1()
        {
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            Array.Sort(words, 1, words.Length - 1);
            string[] expected = { "The", "brown", "dog", "fox", "jumps", "lazy", "over", "quick", "the" };

            PrintResult("Sort from index 1", words, expected);
        }

        static void Test_ReverseCaseInsensitiveComparer()
        {
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            Array.Sort(words, new ReverseCaseInsensitiveComparer());
            string[] expected = { "the", "quick", "over", "lazy", "jumps", "fox", "dog", "brown", "The" };

            PrintResult("Reverse Case-Insensitive", words, expected);
        }

        static void Test_SecondCharComparer()
