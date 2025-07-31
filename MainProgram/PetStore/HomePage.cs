namespace PetStore
{
    public class HomePage
    {
        private PetStoreLogo logo;
        private PetStoreMenu menu;
        //private PetStoreSearch search;
        Pets allPets;

        public EST1 EST1 { get; }
        public EST2 EST2 { get; }

        public void doSearch(string searchText) { }
        public void doLogin(string uname, string password) { }
        public HomePage()
        {
            EST1 = new EST1();
            EST2 = new EST2();

            // Removed invalid instantiation of AngelFish
            // myfish = new AngelFish();

            EST1[] myfirstfishes = new EST1[10];
            EST2[] mysecondfishes = new EST2[10];

            // Fixed invalid array initialization
            AngelFish[] myangelfishes = new AngelFish[2];
        }
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
