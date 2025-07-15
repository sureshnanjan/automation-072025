using Models;
internal class Program
{
    private static void Main(string[] args)
    {
        // Home Page
        Category[] categories = new Category[]
        {
            new Category("Dogs" , 10),
            new Category("Cats", 11),
            new Category ("Birds",12)
        };
        Category reptile = new Category ("Reptiles", 100 );
        reptile.Name = "Changed Reptiles";
        Console.WriteLine(reptile.Name);
        Console.WriteLine(reptile.MyProperty);
        //reptile.MyProperty = 10; // This line will cause an error because MyProperty has no setter
        foreach (var item in categories)
        {
            Console.WriteLine(item);
        }
        
    }
}