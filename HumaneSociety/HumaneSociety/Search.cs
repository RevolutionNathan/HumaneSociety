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
        Room room = new Room();
        public void getAnimalIDByName()
        {
            UI.AskAnimalName();
            searchAnimal.name = Console.ReadLine();

            DataClasses1DataContext db = new DataClasses1DataContext();

            var IDs = db.GetTable<AnimalsMasterList>().Where(i => i.Name == searchAnimal.name);
            foreach(var i in IDs)
            {
                Console.Write(i.AnimalID);
            }
           
            UI.EnterIDYouWant();
            searchAnimal.searchID = Int32.Parse(Console.ReadLine());
        }
        public bool CheckOpenRoom()
        {
            UI.AskRoomNumber();
            int wantedRoomNumber = Int32.Parse(Console.ReadLine());
            DataClasses1DataContext db = new DataClasses1DataContext();
            var rooms = db.GetTable<RoomNumber>();
            var isFull = from o in rooms
                         where o.Room == wantedRoomNumber
                         select o.Occupied;
            if (isFull.FirstOrDefault() == false || isFull.FirstOrDefault() == null)
            {
                UI.RoomOPen();
                room.room = wantedRoomNumber;
                room.occupied = true;
                Console.ReadKey();
                return false;
            }
            else
            {
                UI.RoomOccupied();
                CheckOpenRoom();
                return true;
            }
        }

        public void GetAnimalNameByID()
        {
            UI.AskAnimalID();
            searchAnimal.searchID = Int32.Parse(Console.ReadLine());

            DataClasses1DataContext db = new DataClasses1DataContext();
            var searchAnimals = db.GetTable<AnimalsMasterList>();
            var findName = from n in searchAnimals
                           where n.AnimalID == searchAnimal.searchID
                           select n.Name;

            Console.Write("\nThe name of the aninal with ID: " + searchAnimal.searchID + "is: " + findName);
        }
        public void SearchAnimal()
        {
            bool runSearch = true;
            UI.SearchAnimalMenu(); 
            string searchChoice = Console.ReadLine();
            while (runSearch = true)
            {
                switch (searchChoice)
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
                    case "4":
                        GetAnimalNameByID();
                        break;
                    case "5":
                        runSearch = false;
                        break;
                    default:
                        SearchAnimal();
                        break;
                }
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

            var Traits = db.GetTable<Trait>().Where(i => i.Energetic == energetic && i.Cuddly == cuddly && i.SpayedNuetered == SpayNuet && i.Young == young);
            foreach( var i in Traits)
            {
                Console.Write("\n ID of Animal that matches your search: " + i.AnimalID);
            }
            
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
                Console.WriteLine("\n AnimalID:" + y.AnimalID + "\n Animal Name:" + y.Name + "Type of Animal:" + y.AnimalType);
            }
            Console.ReadKey();
        }
        
        public void FoodSearch()
        {
            UI.AskAnimalID();
            searchAnimal.searchID = Int32.Parse(Console.ReadLine());

            DataClasses1DataContext db = new DataClasses1DataContext();

            var Food = db.GetTable<Food>().Where(y => y.AnimalID == searchAnimal.searchID);
            foreach (var y in Food)
            {
                Console.Write(y.Amount);
            } 
            
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
