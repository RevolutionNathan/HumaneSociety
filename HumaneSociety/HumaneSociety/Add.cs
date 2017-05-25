using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HumaneSociety
{
    class Add
    {
        
        public void AddAnimal()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            AnimalsMasterList newAnimal = new AnimalsMasterList();
            newAnimal.Name = "Thorin";
            newAnimal.AnimalType = "Bear";
            newAnimal.RoomNumber = 1;
            newAnimal.EntryDate = DateTime.Now;
            newAnimal.AdoptedDate = DateTime.Now;
            newAnimal.Adopted = false;
            
            db.AnimalsMasterLists.InsertOnSubmit(newAnimal);

            db.SubmitChanges();

            AnimalsMasterList Animal = db.AnimalsMasterLists.FirstOrDefault(e => e.Name.Equals("Thorin"));

            Console.WriteLine("Animal Id = {0} , Name = {1}", Animal.AnimalID, Animal.Name);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey(); 
        }
    }
}
