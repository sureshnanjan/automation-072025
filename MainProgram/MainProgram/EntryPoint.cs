using Models;
using Automator;
public class Program
{
    /// <summary>
    /// Main method that executes the console logic.
    /// Creates several categories, modifies properties, and displays them.
    /// </summary>
    /// <param name="args">Command-line arguments (not used in this application).</param>
    private static void Main(string[] args)
    {
        // Home Page
        Category[] categories = new Category[]
        {
            new Category("Dogs", 10),
            new Category("Cats", 11),
            new Category("Birds", 12)
        };
        Category reptile = new Category ("Reptiles", 100 );
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
