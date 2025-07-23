using MainProgram;
using Models;
using Automator;


/// <summary>
/// Main entry point of the application demonstrating OOP principles, interfaces, and utility methods.
/// </summary>
public class Program
{
    /// <summary>
    /// The main method that acts as the program entry point.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    private static void Main(string[] args)
    {
        // Uncomment below to test various functionalities:
        // Code1507();
        // callingConventions();
        // int myOriginalValue;
        // DemoRefParam(ref myOriginalValue);
        // designToInterface();
        // comparableDemo();

        DemoUser dminstance = new DemoUser(10, "AUser");
        DemoUser copyofOne = (DemoUser)dminstance.Clone(); // Shallow copy (throws NotImplementedException)
    }

    /// <summary>
    /// Demonstrates interface-based design using browser automation interfaces.
    /// </summary>
    private static void designToInterface()
    {
        int mynumber = 10;
        float myFloat = 10.5f;
        Console.WriteLine((float)mynumber);
        Console.WriteLine((int)myFloat);

        string browsername = "Chrome"; // or "Firefox"
        IBrowsable automator;

        switch (browsername)
        {
            case "Chrome":
                automator = new ChromeAutomatorWI();
                break;
            case "Firefox":
                automator = new FirefoxAutomatorWI();
                Console.WriteLine("Using Chrome Automator");
                break;
            default:
                automator = new ChromeAutomatorWI();
                break;
        }

        automator.Launch();
        ((INavigate)automator).GotoURL("https://www.google.com");
    }

    /// <summary>
    /// Demonstrates sorting of built-in types and custom objects using <see cref="IComparable{T}"/>.
    /// </summary>
    private static void comparableDemo()
    {
        int[] myNumbers = { 10, 1, 222, 32, 4, 5, 0, 100 };
        string[] myNamee = { "AJohn", "Jane", "Doe", "Zach" };
        DemoUser[] myUsers = {
            new DemoUser(10, "AUser"),
            new DemoUser(11, "DUser"),
            new DemoUser(12, "BUser"),
            new DemoUser(20, "ZUser"),
            new DemoUser(0, "XUser")
        };

        Console.WriteLine("Before Sorting");
        foreach (var item in myNumbers) Console.WriteLine(item);
        foreach (var item in myNamee) Console.WriteLine(item);
        foreach (var item in myUsers) Console.WriteLine(item);

        Console.WriteLine("After Sorting");
        Array.Sort(myNumbers);
        Array.Sort(myNamee);
        Array.Sort(myUsers);

        foreach (var item in myNumbers) Console.WriteLine(item);
        foreach (var item in myNamee) Console.WriteLine(item);
        foreach (var item in myUsers) Console.WriteLine(item);
    }

    /// <summary>
    /// Demonstrates parameter passing conventions such as ref, out, and in.
    /// </summary>
    private static void callingConventions()
    {
        int myNumber = 10;
        int myNumber2 = 20;
        Pet myPet = new Pet { MyProperty = 100 };

        Console.WriteLine($"Before calling : {myNumber} and {myNumber2}");
        //addTwoNumbers(ref myNumber, ref myNumber2);
        Console.WriteLine($"After calling : {myNumber} and {myNumber2}");

        Console.WriteLine($"Before calling Pet: {myPet.MyProperty}");
        //DoSomeThing(myPet);
        Console.WriteLine($"After calling Pet: {myPet.MyProperty}");
    }

    /// <summary>
    /// Adds two integers (does not modify inputs externally).
    /// </summary>
    static int addTwoNumbers(int first, int second)
    {
        first += 10;
        second += 20;
        return first + second;
    }

    /// <summary>
    /// Demonstrates the usage of the ref modifier.
    /// </summary>
    /// <param name="received">An integer passed by reference.</param>
    static void DemoRefParam(ref int received)
    {
        // Modify the value as needed
    }

    /// <summary>
    /// Demonstrates the usage of the out modifier.
    /// </summary>
    /// <param name="received">An output parameter to be initialized inside the method.</param>
    static void DemoOutParam(out int received)
    {
        Console.WriteLine("Initializing the param as I am an OUT modifier");
        received = 100;
    }

    /// <summary>
    /// Demonstrates the usage of the in modifier.
    /// </summary>
    /// <param name="received">An input parameter passed as readonly.</param>
    static void DemoInParam(in int received)
    {
        // Cannot assign value to received
    }

    /// <summary>
    /// Demonstrates variable arguments using params.
    /// </summary>
    /// <param name="received">An array of integers.</param>
    static void SumOfAll(params int[] received)
    {
        // Example: Sum all elements
    }

    /// <summary>
    /// Example sort method for an array.
    /// </summary>
    /// <param name="array">Array to be sorted.</param>
    void sort(int[] array)
    {
        // Sorting logic
    }

    /// <summary>
    /// Modifies the given <see cref="Pet"/> object by changing its property.
    /// </summary>
    /// <param name="pet">The pet object to modify.</param>
    static void DoSomeThing(Pet pet)
    {
        Console.WriteLine("Changing the passed Pet");
        pet.MyProperty = 200;
    }

    /// <summary>
    /// Demonstrates creating and interacting with <see cref="Category"/> objects.
    /// </summary>
    private static void Code1507()
    {
        Category[] categories = new Category[]
        {
            new Category("Dogs", 10),
            new Category("Cats", 11),
            new Category("Birds", 12)
        };

        Category reptile = new Category("Reptiles", 100);
        reptile.Name = "Changed Reptiles";

        Console.WriteLine(reptile.Name);
        Console.WriteLine(reptile.MyProperty);

        foreach (var item in categories)
        {
            Console.WriteLine(item);
        }

        reptile.addTwoNumbers(100, 200);
        reptile.addTwoNumbers(123.456, 67.980);
        reptile.DoSomeThing();

        int? mynumber = 0x000010; // Hexadecimal literal
        Console.WriteLine(mynumber);

        float myFloat = 10.5f;
        bool isTrue = true;
    }
}
