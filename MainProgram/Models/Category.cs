using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Represents a category that can contain pets and related properties.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// An array of pets belonging to this category.
        /// </summary>
        Pet[] pets;

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; }

        private int myVar;
        private float myFloatVar;

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class with the specified name and integer value.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <param name="myVar">An integer value associated with the category.</param>
        public Category(string name, int myVar)
        {
            Name = name;
            this.myVar = myVar;
        }

        /// <summary>
        /// Gets or sets the integer property for the category.
        /// The getter sets the value to 10 before returning it.
        /// </summary>
        public int MyProperty
        {
            get { myVar = 10; return myVar; }
            set { myVar = value; }
        }

        /// <summary>
        /// Gets or sets the floating-point value associated with the category.
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

        /// <summary>
        /// A placeholder method intended to perform some action.
        /// </summary>
        public void DoSomeThing()
        {
            // Signature
        }

        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <param name="first">The first integer value.</param>
        /// <param name="second">The second integer value.</param>
        /// <returns>The sum of the two integers.</returns>
        public int addTwoNumbers(int first, int second)
        {
            return first + second;
        }

        /// <summary>
        /// Adds two double values and returns the result.
        /// </summary>
        /// <param name="first">The first double value.</param>
        /// <param name="second">The second double value.</param>
        /// <returns>The sum of the two doubles.</returns>
        public double addTwoNumbers(double first, double second)
        {
            return first + second;
        }
    }
}
