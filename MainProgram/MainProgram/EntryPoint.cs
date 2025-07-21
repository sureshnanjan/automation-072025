using MainProgram;
using Models;
using Automator;

/// <summary>
/// Main entry class for the application demonstrating interfaces, cloning, sorting, and parameter passing in C#.
/// </summary>
public class Program
{
    private static void Main(string[] args)
    {
        // Example to demonstrate shallow copy using ICloneable
        DemoUser dminstance = new DemoUser(10, "AUser");
        DemoUser copyofOne = (DemoUser)dminstance.Clone();

        // Uncomment to test specific demos:
        // Code1507();
        // callingConventions();
        // int myOriginalValue; DemoRefParam(ref myOriginalValue);
        // designToInterface();
        // comparableDemo();
    }

    /// <summary>
    /// Demonstrates type casting, interfaces, and browser automation interface design.
    /// </summary>
    private static void designToInterface()
    {
        int mynumber = 10;
        float myFloat = 10.5f;
        Console.WriteLine((float)mynumber); // Explicit cast to float
        Console.WriteLine((int)myFloat);    // Explicit cast to int

        string browsername = "Chrome"; // Change to "Firefox" to test different automators
        IBrowsable automator;

        switch (browsername)
        {
            case "Chrome":
                automator = new ChromeAutomatorWI();
                break;
            case "Firefox":
                automator = new FirefoxAutomatorWI();
                Console.WriteLine("Using Firefox Automator");
                break;
            default:
                automator = new ChromeAutomatorWI();
                break;
        }

        automator.Launch();
        ((INavigate)automator).GotoURL("https://www.google.com");
    }

    /// <summary>
    /// Demonstrates sorting with built-in types and custom objects implementing IComparable.
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
    /// Demonstrates different parameter passing conventions in C#.
    /// </summary>
    private static void callingConventions()
    {
        int myNumber = 10;
        int myNumber2 = 20;
        Pet myPet = new Pet { MyProperty = 100 };

        Console.WriteLine($"Before calling: {myNumber} and {myNumber2}");
        // addTwoNumbers(ref myNumber, ref myNumber2);
        Console.WriteLine($"After calling: {myNumber} and {myNumber2}");

        Console.WriteLine($"Before calling Pet: {myPet.MyProperty}");
        // DoSomeThing(myPet);
        Console.WriteLine($"After calling Pet: {myPet.MyProperty}");
    }

    static int addTwoNumbers(int first, int second)
    {
        first += 10;
        second += 20;
        return first + second;
    }

    static void DemoRefParam(ref int received)
    {
        received = 42; // Required to assign a value
    }

    static void SumOfAll(params int[] received)
    {
        int sum = 0;
        foreach (int number in received)
            sum += number;
        Console.WriteLine($"Sum: {sum}");
    }

    static void DemoOutParam(out int received)
    {
        Console.WriteLine("Initializing out parameter");
        received = 100; // Must be assigned before return
    }

    static void DemoInParam(in int received)
    {
        Console.WriteLine($"Received value: {received}");
        // Cannot modify received inside this method
    }

    static void DoSomeThing(Pet pet)
    {
        Console.WriteLine("Modifying the Pet object");
        pet.MyProperty = 200;
    }

    /// <summary>
    /// Demonstrates category instantiation and method overloading.
    /// </summary>
    private static void Code1507()
    {
        Category[] categories = new Category[]
        {
            new Category("Dogs", 10),
            new Category("Cats", 11),
            new Category("Birds", 12)
        };

        Category reptile = new Category("Reptiles", 100)
        {
            Name = "Changed Reptiles"
        };

        Console.WriteLine(reptile.Name);
        Console.WriteLine(reptile.MyProperty);

        foreach (var item in categories)
        {
            Console.WriteLine(item);
        }

        reptile.addTwoNumbers(100, 200);        // Overloaded method
        reptile.addTwoNumbers(123.456, 67.980); // Overloaded method
        reptile.DoSomeThing();                  // Custom method

        int? mynumber = 0x000010;
        float myFloat = 10.5f;
        bool isTrue = true;

        Console.WriteLine(mynumber);
        Console.WriteLine(myFloat);
        Console.WriteLine(isTrue);
    }
}
cd ..