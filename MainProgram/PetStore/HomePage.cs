namespace PetStore
{
    public class HomePage
    {
<<<<<<< HEAD
        private PetStoreLogo logo;
        private PetStoreMenu menu;
<<<<<<< HEAD
        private Pets allPets;

        private EST1 est1;
        private EST2 est2;
        private AngelFish myfish;

        public void doSearch(string searchText)
        {
            // Implement search functionality here
        }

        public void doLogin(string uname, string password)
        {
            // Implement login functionality here
        }

        public HomePage()
        {
            est1 = new EST1();
            est2 = new EST2();
            myfish = new AngelFish();
=======
        //private PetStoreSearch search;
        Pets allPets;

        public EST1 EST1 { get; }
        public EST2 EST2 { get; }

=======
        //private PetStoreLogo logo;
        //private PetStoreMenu menu;
        //private PetStoreSearch search;
        //Pets allPets;
        
>>>>>>> e61a7b07dfaee872f7c92bafa503b62494e5548e
        public void doSearch(string searchText) { }
        public void doLogin(string uname, string password) { }
        public HomePage()
        {
<<<<<<< HEAD
            EST1 = new EST1();
            EST2 = new EST2();

            // Removed invalid instantiation of AngelFish
            // myfish = new AngelFish();
>>>>>>> a41a9228532f222f252ff64a077b287a183eed45

            EST1[] myfirstfishes = new EST1[10];
=======
           EST1[] myfirstfishes = new EST1[10];
>>>>>>> e61a7b07dfaee872f7c92bafa503b62494e5548e
            EST2[] mysecondfishes = new EST2[10];

<<<<<<< HEAD
            // All inherit from Fish, so can be stored in Fish[]
            Fish[] myangelfishes = { new EST2(), new EST1(), new AngelFish() };
        }
    }

    // Supporting classes
    public class PetStoreLogo { }

    public class PetStoreMenu { }

    public class Pets { }

    public class Fish
    {
        // Base fish properties or methods
        public string Name { get; set; }
    }

    public class EST1 : Fish
    {
        // Specific behavior for EST1
    }

    public class EST2 : Fish
    {
        // Specific behavior for EST2
    }

    public class AngelFish : Fish
    {
        // Specific behavior for AngelFish
=======
            // Fixed invalid array initialization
            AngelFish[] myangelfishes = new AngelFish[2];
        }
>>>>>>> a41a9228532f222f252ff64a077b287a183eed45
    }

    internal class Pets
    {
    }

    internal class PetStoreMenu
    {
    }

    // Added AngelFish class definition to resolve CS0144
    //internal abstract class AngelFish
    //{
    //    // Abstract class cannot be instantiated directly
    //    // Add properties or methods as needed
    //}
}
