///this is the  WEEK 3 assignment -3  documentation file 
///For the classes in the MainProgram

///Entrypoint.cs

/// documentation of the file starts here///

using Models;
using System;

/// <summary>
/// Entry point of the console application.
/// Demonstrates the creation and manipulation of <see cref="Category"/> objects.
/// </summary>
internal class Program
{
    /// <summary>
    /// Main method that executes the console logic.
    /// Creates several categories, modifies properties, and displays them.
    /// </summary>
    /// <param name="args">Command-line arguments (not used in this application).</param>
    private static void Main(string[] args)
    {
        // Create an array of category instances representing homepage categories
        Category[] categories = new Category[]
        {
            new Category("Dogs", 10),
            new Category("Cats", 11),
            new Category("Birds", 12)
        };

        // Create an individual category and modify its Name property
        Category reptile = new Category("Reptiles", 100);
        reptile.Name = "Changed Reptiles";

        // Display properties of the modified category
        Console.WriteLine(reptile.Name);         // Output: Changed Reptiles
        Console.WriteLine(reptile.MyProperty);   // Output: 10 (always, due to forced getter logic)

        // Attempting to set MyProperty directly is commented out as it’s disallowed in this context
        // reptile.MyProperty = 10;

        // Loop through all categories and print their string representation
        foreach (var item in categories)
        {
            Console.WriteLine(item);
        }
    }
}
///

Category.cs
/// documentation starts here ///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks

namespace Models
{
    /// <summary>
    /// Represents a category that may contain a set of pets.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Array to hold pets related to this category (not used currently).
        /// </summary>
        private Pet[] pets;

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; }

        private int myVar;
        private float myFloatVar;

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class with the specified name and identifier.
        /// </summary>
        /// <param name="name">Name of the category.</param>
        /// <param name="myVar">An integer value associated with the category (ID or status).</param>
        public Category(string name, int myVar)
        {
            Name = name;
            this.myVar = myVar;
        }

        /// <summary>
        /// Gets or sets the integer property related to the category.
        /// Note: The getter forcibly sets the value to 10 before returning it.
        /// </summary>
        public int MyProperty
        {
            get { myVar = 10; return myVar; }  // Always returns 10 regardless of the original value
            set { myVar = value; }
        }

        /// <summary>
        /// Gets or sets a floating-point property (purpose undefined).
        /// </summary>
        public float MyFloatVar
        {
            get => myFloatVar;
            set => myFloatVar = value;
        }

        /// <summary>
        /// Returns a string that represents the current category.
        /// </summary>
        /// <returns>A string in the format "Name-MyProperty".</returns>
        public override string? ToString()
        {
            return $"{this.Name}-{this.MyProperty}";
        }

        public void DoSomeThing()
        {
            // Signature
        }

        public int addTwoNumbers(int first, int second)
        {
            return first + second;
        }

        public double addTwoNumbers(double first, double second)
        {
            return first + second;
        }


    }
}

DemoUser.cs
///documentation begins here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    /// <summary>
    /// Represents a demo user with a name and a value.
    /// Implements <see cref="IComparable{DemoUser}"/> for sorting and <see cref="ICloneable"/> for cloning functionality.
    /// </summary>
    public class DemoUser : IComparable<DemoUser>, ICloneable
    {
        /// <summary>
        /// Gets or sets the numeric value associated with the user.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns a string representation of the user in the format "User-&lt;Value&gt;:&lt;Name&gt;".
        /// </summary>
        /// <returns>A formatted string containing the user’s value and name.</returns>
        public override string? ToString()
        {
            return $"User-{this.Value}:{this.Name}";
        }

        /// <summary>
        /// Compares this instance with another <see cref="DemoUser"/> object by name in descending order.
        /// </summary>
        /// <param name="other">The other <see cref="DemoUser"/> instance to compare with.</param>
        /// <returns>
        /// An integer that indicates the relative order of the objects being compared.
        /// A negative number if this instance follows <paramref name="other"/>; 
        /// zero if they are equal; 
        /// a positive number if this instance precedes <paramref name="other"/>.
        /// </returns>
        public int CompareTo(DemoUser? other)
        {
            return other.Name.CompareTo(this.Name);
        }

        /// <summary>
        /// Throws <see cref="NotImplementedException"/>. Intended to create a copy of the current object.
        /// </summary>
        /// <returns>A clone of the current object.</returns>
        /// <exception cref="NotImplementedException">Thrown because the method is not implemented.</exception>
        public object Clone()
        {
            return new DemoUser(this.Value, this.Name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoUser"/> class with the specified value and name.
        /// </summary>
        /// <param name="val">The numeric value associated with the user.</param>
        /// <param name="name">The name of the user.</param>
        public DemoUser(int val, string name)
        {
            Value = val;
            Name = name;
        }
    }
}



