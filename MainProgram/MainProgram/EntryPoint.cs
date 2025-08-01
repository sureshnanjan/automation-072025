using Automator;
using MainProgram;
using Models;
using System.Collections.Generic;
using System.Reflection;


public class Program
{
    public delegate void  MyMethodwithNoArguments();
    public delegate void MyMethodwithDayOfWeek(DayOfWeek inst);

    public delegate int AMethodWith2IntsReturnInt(int a, int b);
    private static void Main(string[] args)
    {
        //Code1507();
        //callingConventions();
        // int myOriginalValue; 
        //DemoRefParam(ref myOriginalValue);

        //designToInterface();

<<<<<<< HEAD
        comparableDemo();
=======
        // comparableDemo();

<<<<<<< HEAD
        DemoUser dminstance = new DemoUser(10, "AUser");
        DemoUser copyofOne = (DemoUser)dminstance.Clone(); // Shallow copy
>>>>>>> 4c83d42b69d81bf5f64327afb32b0617c28e862f
=======
        //DemoUser dminstance = new DemoUser(10, "AUser");
        //DemoUser copyofOne = (DemoUser)dminstance.Clone(); // Shallow copy
>>>>>>> 10e667814f0e67d7065ec9e42fceb6d191319c20

        //GenericsDemo();

        //GenericsDemo(args);
        //GreetUser(DayOfWeek.Friday);
        //GreetUser("monday");
        //GreetUser("Holiday");
        //MyMethodwithNoArguments method1 = delegatesDemo();

        //UsingDelegatesDemo();

        //pubSubDemo();
        //eventFiringDemo();
        // Feed the pets
        Fish[] myfishes = { };
        Cat[] mycats = { };
        //feedCAt(catinst);
        //feedFish(fishinstance);// { }
        



    }

    private static void feedFish(Fish fish, object fishinstance)
    {
        throw new NotImplementedException();
    }

    private static void feedCAt(Cat cat, object catinst)
    {
        throw new NotImplementedException();
    }

    private static void eventFiringDemo()
    {
        TypeWithEvent typeWithEvent = new TypeWithEvent();
        typeWithEvent.Event += sendSMS;
        typeWithEvent.Event += sendEmail;
        typeWithEvent.Event += (s, ea) => { Console.WriteLine($"Handling the Event from  WHATS APP{s} with data {ea.ToString()}"); };
        typeWithEvent.FireEvent();
    }

    private static void sendSMS(object? sender, EventArgs e)
    {
        Console.WriteLine($"Handling the Event from  SMS {sender} with data {e.ToString()}");
    }
    private static void sendEmail(object? sender, EventArgs e)
    {
        Console.WriteLine($"Handling the Event from  EMAIL {sender} with data {e.ToString()}");
    }

    private static void pubSubDemo()
    {
        EventEmitter eventEmitter = new EventEmitter();
        EventSubscriber mailnotification = new EventSubscriber("Email Notification");
        EventSubscriber smsnotification = new EventSubscriber("SMS Notification");
        EventSubscriber whatsapp = new EventSubscriber("Whats App Notification");
        eventEmitter.Subscribe(mailnotification);
        eventEmitter.Subscribe(smsnotification);
        eventEmitter.Subscribe(whatsapp);
        try
        {
            eventEmitter.PublishEvent(new EventArgs());
        }
        catch (Exception)
        {

            throw;
        }
    }

    private static void UsingDelegatesDemo()
    {
        doExecution(Method1);
        doExecution(() => Console.WriteLine("This is something different"));
        Action<string> strOp = (arg) => Console.WriteLine($"{arg}-{arg}-{arg}");
        strOp("suresh");

        int[] mynumbers = { 1, 2, 3, 4, 5, 6, 7 };
        Console.WriteLine(mynumbers.Any(x => x < 100));
        Console.WriteLine(mynumbers.All(x => x > 0));
        Console.WriteLine(mynumbers.Aggregate((a, b) => a * b));

        SuperMan superMan = new SuperMan();
        superMan.Play(() => { Console.WriteLine("PLaywith English"); });
    }

    private static MyMethodwithNoArguments delegatesDemo()
    {
        MyMethodwithNoArguments method1 = designToInterface;
        MyMethodwithDayOfWeek method2 = GreetUser;

        GreetUser(DayOfWeek.Friday);
        method2(DayOfWeek.Monday);
        method2 = dayofweek => Console.WriteLine($"Doing something different with args {dayofweek.ToString()}");
        method2(DayOfWeek.Sunday);
        method1 = () => Console.WriteLine("This is a delegate"); // Lambda 
        AMethodWith2IntsReturnInt adder = addTwoNumbers;
        adder(100, 200);

        AMethodWith2IntsReturnInt doubler = (first, second) => (first * 2) + (second * 2);
        Action<int, int, int> threeargs;
        threeargs = (a, b, c) => Console.WriteLine((a * 2) + (b * 2) + (c * 2));
        return method1;
    }

    private static void GenericsDemo(string[] args)
    {
        Console.WriteLine($"Welcome to Automation");
        string browsername = args[0];
        switch (browsername)
        {
            case "chrome":
                Console.WriteLine("Running in chrome");
                break;
            case "firefox":
                Console.WriteLine("Running on Firefox");
                break;
            default:
                Console.WriteLine("This browser not supported");
                break;
        }
    }

    static void Method1() {

        Console.WriteLine("Inside Method 1");    
    }

    static void doExecution(Action argfunction) {
        Console.WriteLine("Executing another Method");
        argfunction();
        Console.WriteLine("Doing something after execution");
    }

    private static void GenericsDemo()
    {
        GenericCalculator<int> intcal = new GenericCalculator<int>(10, 20);
        GenericCalculator<float> floatcal = new GenericCalculator<float>(10.5f, 20.5f);
        GenericCalculator<DemoUser> demUsercal = new GenericCalculator<DemoUser>(new DemoUser(10, "AUser"), new DemoUser(20, "BUser"));
        List<DemoUser> myUsers = new List<DemoUser>();
        List<int> users = new List<int>();
    }

    private static void GreetUser(DayOfWeek dayofweek) {
        switch (dayofweek)
        {
            case DayOfWeek.Monday:
                Console.WriteLine();
                break;
            case DayOfWeek.Tuesday:
                Console.WriteLine();
                break;
            case DayOfWeek.Wednesday:
                Console.WriteLine();
                break;

            default:
                Console.WriteLine("Everything else");
                break;
        }
        Console.WriteLine("You are in the nth Day of the week");
        Console.WriteLine($"Hello User Have a great {dayofweek}");
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