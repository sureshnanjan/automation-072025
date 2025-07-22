namespace PetStore
{
    public class HomePage
    {
        private PetStoreLogo logo;
        private PetStoreMenu menu;
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

            EST1[] myfirstfishes = new EST1[10];
            EST2[] mysecondfishes = new EST2[10];

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
    }
}
