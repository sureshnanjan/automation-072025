using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Represents a category of pets with a name and various properties.
    /// </summary>
    public class Category
    {
        Pet[] pets;

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; }

        private int myVar;
        private float myFloatVar;

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class with the specified name and value.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <param name="myVar">An integer value associated with the category.</param>
        public Category(string name, int myVar)
        {
            Name = name;
            this.myVar = myVar;
        }

        /// <summary>
        /// Gets or sets the integer property. Always sets to 10 on get.
        /// </summary>
        public int MyProperty
        {
            get { myVar = 10; return myVar; }
            set { myVar = value; }
        }

        /// <summary>
        /// Gets or sets the float variable.
        /// </summary>
        public float MyFloatVar { get => myFloatVar; set => myFloatVar = value; }

        /// <summary>
        /// Returns a string representation of the category.
        /// </summary>
        /// <returns>A string combining the name and integer property.</returns>
        public override string? ToString()
        {
            return $"{this.Name}-{this.MyProperty}";
        }

        /// <summary>
        /// A placeholder method to demonstrate a category doing something.
        /// </summary>
        public void DoSomeThing()
        {
            // Signature
        }

        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <param name="first">The first integer.</param>
        /// <param name="second">The second integer.</param>
        /// <returns>The sum of the two integers.</returns>
        public int addTwoNumbers(int first, int second)
        {
            return first + second;
        }

        /// <summary>
        /// Adds two doubles and returns the result.
        /// </summary>
        /// <param name="first">The first double.</param>
        /// <param name="second">The second double.</param>
        /// <returns>The sum of the two doubles.</returns>
        public double addTwoNumbers(double first, double second)
        {
            return first + second;
        }
    }
}
