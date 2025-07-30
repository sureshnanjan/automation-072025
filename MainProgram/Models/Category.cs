namespace Models
{
    /// <summary>
    /// Represents the category to which a pet belongs, such as "Dogs" or "Cats".
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Unique identifier for the category.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Name of the category (e.g., "Dog", "Cat").
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns a string that represents the current Category object.
        /// </summary>
        /// <returns>A string with category name and ID.</returns>
        public override string ToString()
        {
            return $"Category(Name: {Name}, Id: {Id})";
        }

<<<<<<< HEAD
=======
        public int MyProperty
        {
            get { myVar = 10; return myVar; }
            set { myVar = value; }
        }

        public float MyFloatVar { get => myFloatVar; set => myFloatVar = value; }

        public override string? ToString()
        {
            return $"{this.Name}-{this.MyProperty}";
        }
>>>>>>> f6bb7fb812dedd6e4734d3837588df55f2851795

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

<<<<<<< HEAD
=======

>>>>>>> f6bb7fb812dedd6e4734d3837588df55f2851795
    }
}