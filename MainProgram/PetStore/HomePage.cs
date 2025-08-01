namespace PetStore
{
    public class HomePage
    {
        private PetStoreLogo logo;
        private PetStoreMenu menu;
        //private PetStoreSearch search;
        //Pets allPets;

        public EST1 EST1 { get; }
        public EST2 EST2 { get; }

        private AngelFish myfish;

        public void doSearch(string searchText) { }
        public void doLogin(string uname, string password) { }
        public HomePage(EST1 eST1, EST2 eST2, AngelFish myfish)
        {
            EST1 = new EST1();
            EST2 = new EST2();
            //myfish = new AngelFish();

            EST1[] myfirstfishes = new EST1[10];
            EST2[] mysecondfishes = new EST2[10];
            AngelFish[] myangelfishes = { new EST2(), new EST1() };
            EST1 = eST1;
            EST2 = eST2;
            this.myfish = myfish;
        }

    }
}