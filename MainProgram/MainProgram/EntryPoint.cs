using Models;
internal class Program
{
    private static void Main(string[] args)
    {
        //Code1507();
        //callingConventions();
        int myOriginalValue; 
        //DemoRefParam(ref myOriginalValue);
        DemoOutParam(out myOriginalValue);
        DemoParams(1, 2, 2, 3, 4);
        DemoParams(1);

        DemoInParam(myOriginalValue);
    }

    private static void callingConventions()
    {
        int myNumber = 10;
        int myNumber2 = 20;
        Pet myPet = new Pet { MyProperty = 100 };
        //Category category = new Category("Dogs", 10);
        Console.WriteLine($" Before calling : {myNumber}and{myNumber2}");
        addTwoNumbers(ref myNumber, ref myNumber2);
        Console.WriteLine($" After Calling {myNumber}and{myNumber2}");
        Console.WriteLine($"Before Calling Pet has {myPet.MyProperty}");
        DoSomeThing(myPet);
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