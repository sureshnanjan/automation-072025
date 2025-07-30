using System;
using System.Collections;

namespace BinaryPractice
{
    // The Person class represents a person with a name and age,
    // and implements IComparable to enable sorting and searching by age.
    public class Person : IComparable   //default comparer
    {
        // Name is initialized to an empty string to avoid null warnings.
        public string Name = string.Empty;

        public int Age;

        // This method is required by the IComparable interface.
        // It compares this person's age to another person's age.
        public int CompareTo(object? obj)
        {
            // Attempt to cast the input object to a Person
            Person? other = obj as Person;

            // Compare the Age of the current object with the other
            // Better to add a null check in production code.
            return this.Age.CompareTo(other.Age);
        }
    }
}
