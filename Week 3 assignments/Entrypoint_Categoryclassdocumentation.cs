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
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Models
//{
//    public class Category
//    {
//        Pet[] pets;

//        public string Name { get; set; }
//        private int myVar;
//        private float myFloatVar;

//        public Category(string name, int myVar)
//        {
//            Name = name;
//            this.myVar = myVar;
//        }

//        public int MyProperty
//        {
//            get { myVar = 10;  return myVar; }
//            set { myVar = value; }
//        }

//        public float MyFloatVar { get => myFloatVar; set => myFloatVar = value; }

//        public override string? ToString()
//        {
//            return $"{this.Name}-{this.MyProperty}";
//        }
//    }
//}


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


