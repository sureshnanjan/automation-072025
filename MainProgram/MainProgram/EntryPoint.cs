using MainProgram;
using Models;
using Automator;
public class Program
{
    private static void Main(string[] args)
    {
        //Code1507();
        //callingConventions();
        // int myOriginalValue; 
<<<<<<< HEAD
        //DemoRefParam(ref myOriginalValue);gti 
=======
        //DemoRefParam(ref myOriginalValue);
>>>>>>> 18c84e212202e2c7edd4701945f0a27b44c470b6

        //designToInterface();

        // comparableDemo();

        DemoUser dminstance = new DemoUser(10, "AUser");
        DemoUser copyofOne = (DemoUser)dminstance.Clone(); // Shallow copy

    }

    private static void designToInterface()
    {
        int mynumber = 10;
        float myFloat = 10.5f;
        Console.WriteLine((float)mynumber);
        Console.WriteLine((int)myFloat);

        //comparableDemo();
        string browsername = "Chrome"; // or "Firefox"
        IBrowsable automator;// = new ChromeAutomator();
        //INavigate automator; // Use INavigate for navigation functionality
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
        INavigate navigateAutomator = automator as INavigate;
        //navigateAutomator.
        ((INavigate)automator).GotoURL("https://www.google.com");
    }

    private static void comparableDemo()
    {
        int[] myNumbers = { 10, 1, 222, 32, 4, 5, 0, 100 };
        string[] myNamee = { "AJohn", "Jane", "Doe", "Zach" };
        DemoUser[] myUsers = { new DemoUser(10,"AUser"), new DemoUser(11,"DUser"), new DemoUser(12,"BUser"), new DemoUser(20,"ZUser"), new DemoUser(0,"XUser") };

        Console.WriteLine("Before Sorting");
        foreach (var item in myNumbers)
        {
            Console.WriteLine(item);
        }
        foreach (var item in myNamee)
        {
            Console.WriteLine(item);
        }
        foreach (var item in myUsers)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("After Sorting");
        Array.Sort(myNumbers);
        Array.Sort(myNamee);
        Array.Sort(myUsers);
        foreach (var item in myNumbers)
        {
            Console.WriteLine(item);
        }
        foreach (var item in myNamee)
        {
            Console.WriteLine(item);
        }
        foreach (var item in myUsers)
        {
            Console.WriteLine(item);
        }
    }

    private static void callingConventions()
    {
        int myNumber = 10;
        int myNumber2 = 20;
        Pet myPet = new Pet { MyProperty = 100 };
        //Category category = new Category("Dogs", 10);
        Console.WriteLine($" Before calling : {myNumber}and{myNumber2}");
        //addTwoNumbers(ref myNumber, ref myNumber2);
        Console.WriteLine($" After Calling {myNumber}and{myNumber2}");
        Console.WriteLine($"Before Calling Pet has {myPet.MyProperty}");
        //DoSomeThing(myPet);
        Console.WriteLine($"After Calling Pet has {myPet.MyProperty}");
    }

    static int addTwoNumbers(int first, int second)
    {
        first = first + 10;
        second = second + 20;
        return first + second;
    }

    static void DemoRefParam(ref int received) {
    
    }

    static void SumOfAll(params int[] received) { }

    void sort(int[] array) { }


    
    static void DemoOutParam(out int received) {
        Console.WriteLine("I am inialising the param as I am an OUT modifier");
        received = 100; // Must assign a value before using it
    }

    static void DemoInParam(in int received) {
        //received = 100;
    }

    static void DoSomeThing(Pet pet)
    {
        Console.WriteLine("Changing the passed Pet");
        pet.MyProperty = 200;
    }

    private static void Code1507()
    {
        // Home Page
        Category[] categories = new Category[]
        {
            new Category("Dogs" , 10),
            new Category("Cats", 11),
            new Category ("Birds",12)
        };
        Category reptile = new Category("Reptiles", 100);
        reptile.Name = "Changed Reptiles";
        Console.WriteLine(reptile.Name);
        Console.WriteLine(reptile.MyProperty);
        //reptile.MyProperty = 10; // This line will cause an error because MyProperty has no setter
        foreach (var item in categories)
        {
            Console.WriteLine(item);
        }
        reptile.addTwoNumbers(100, 200);
        reptile.addTwoNumbers(123.456, 67.980);
        reptile.DoSomeThing();

        int? mynumber = 0x000010; // Binary literal
        Console.WriteLine(mynumber);
        float myFloat = 10.5f; // Float literal
        bool isTrue = true; // Boolean literal
    }
}