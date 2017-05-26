using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Search
    {
        Animal searchAnimal = new Animal();
        public void getAnimalIDByName()
        {
            UI.AskAnimalName();
            searchAnimal.name = Console.ReadLine();

            DataClasses1DataContext db = new DataClasses1DataContext();

            var IDs = db.GetTable<AnimalsMasterList>();
            var IDsList = from i in IDs
                          where i.Name == searchAnimal.name
                          select i.AnimalID;
            UI.ListIDsFromNameSearch();
            Console.Write(IDsList);
            UI.EnterIDYouWant();
            searchAnimal.searchID = Int32.Parse(Console.ReadLine());
        }
        public void SearchRoomByID()
        {
            // 
        }
        public void SearchAnimal()
        {
            UI.SearchAnimalMenu(); Console.WriteLine("1: search food quantity 2: search animal by type 3: search animal by traits");
            string searchChoice = Console.ReadLine();
            switch(searchChoice)
            {
                case "1":
                    FoodSearchMenu();
                    break;
                case "2":
                    KindSearch();
                    break;
                case "3":
                    TraitsSearch();
                    break;
                default:
                    SearchAnimal();
                    break;
            }
        }

        public void TraitsSearch()
        {
            UI.Energetic();
            bool energetic = Convert.ToBoolean(Console.ReadLine());
            UI.Cuddly();
            bool cuddly = Convert.ToBoolean(Console.ReadLine());
            UI.SpayNuet();
            bool SpayNuet = Convert.ToBoolean(Console.ReadLine());
            UI.Young();
            bool young = Convert.ToBoolean(Console.ReadLine());

            DataClasses1DataContext db = new DataClasses1DataContext();

            var Traits = db.GetTable<Trait>();
            var TraitList = from i in Traits
                           where i.Energetic == energetic && i.Cuddly == cuddly && i.SpayedNuetered == SpayNuet && i.Young == young
                           select i.AnimalID;
            Console.Write(TraitList);
            Console.ReadKey();

        }
        public void KindSearch()
        {
            UI.KindSearch();
            string kindSought = Console.ReadLine();

            DataClasses1DataContext db = new DataClasses1DataContext();

            var x = db.GetTable<AnimalsMasterList>().Where(y => y.AnimalType == kindSought);
            foreach(var y in x)
            {
                Console.WriteLine("AnimalID    Name     \n" + y.AnimalID + " " + );
            }
            //var KindList = from i in db.GetTable<AnimalsMasterList>()
            //               where i.AnimalType == kindSought
            //               select i;
            //Console.Write(x);
            Console.ReadKey();

        }
        
        public void FoodSearch()
        {
            UI.AskAnimalID();
            searchAnimal.searchID = Int32.Parse(Console.ReadLine());

            DataClasses1DataContext db = new DataClasses1DataContext();

            var Food = db.GetTable<Food>();
            var FoodList = from i in Food
                          where i.AnimalID == searchAnimal.searchID
                          select i.Amount;
            Console.Write(FoodList);
            Console.ReadKey();
        }

        public void FoodSearchMenu()
        {
            UI.AnimalNameQuery();
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    FoodSearch();
                    break;
                case "2":
                    getAnimalIDByName();
                    FoodSearch();
                    break;
                default:
                    FoodSearchMenu();
                    break;
            }

        }

    }
}

// main search -- establish the animal id then ask what to search for: food, shots, kind, traits (for adopter search)
// adoption -- find animal by id, then change bool
// adoption -- adopter profile and matching sql table
// adopter search can be traits search
// register class needs wallet and it can probably link to the method which marks an animal as adopted
// need to finish by adding try catched and handling null exceptions 
// what if traits was a series of bools in it's own table (energetic, cuddly, spayed/neutered, young/old)
