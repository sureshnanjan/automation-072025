using MainProgram;
using Models;
using Automator;

/// <summary>
/// Entry point for the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Main method that starts the program.
    /// </summary>
    private static void Main(string[] args)
    {
        //Code1507();
        //callingConventions();
        //int myOriginalValue;
        //DemoRefParam(ref myOriginalValue);
        //designToInterface();

        //comparableDemo();
    }

    /// <summary>
    /// Demonstrates interface-based design and type casting.
    /// </summary>
    private static void designToInterface()
    {
        int mynumber = 10;
        float myFloat = 10.5f;
        Console.WriteLine((float)mynumber);
        Console.WriteLine((int)myFloat);

        string browsername = "Chrome";
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
    }
}
