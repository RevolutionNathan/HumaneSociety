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
            Console.Write("here are the ids that match the name of the animal you're looking for" + IDsList);
            
        }
        public void SearchRoomByID()
        {
            // 
        }
        public void SearchAnimal()
        {
            string searchChoice = Console.ReadLine();
            switch(searchChoice)
            {
                case "1":
                    FoodSearch();
                    break;
                case "2":
                    ShotsSearch();
                    break;
                case "3":
                    KindSearch();
                    break;
                case "4":
                    TraitsSearch();
                    break;
                default:
                    SearchAnimal();
                    break;
            }
        }
    }
}

// main search -- establish the animal id then ask what to search for: food, shots, kind, traits (for adopter search)
// shots as it's own class -- 
// adoption -- find animal by id, then change bool
// adoption -- adopter profile and matching sql table
// adopter search can be traits search
// register class needs wallet and it can probably link to the method which marks an animal as adopted
// need to finish by adding try catched and handling null exceptions 
// what if traits was a series of bools in it's own table (energetic, cuddly, spayed/neutered, young/old)
