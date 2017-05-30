using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Delete
    {
        Animal animalToDelete = new Animal();
        public void DeleteAnimal()
        {
            Console.Write("Enter the ID of the animal you wish to delete");

            try
            {
            animalToDelete.searchID = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                UI.NeedIntException();
                DeleteAnimal();
            }
                
            DataClasses1DataContext db = new DataClasses1DataContext();
            
            AnimalsMasterList deleteAnimal = db.AnimalsMasterLists.FirstOrDefault(e => e.Equals(animalToDelete.searchID));
            try
            {
            db.AnimalsMasterLists.DeleteOnSubmit(deleteAnimal);

            db.SubmitChanges();
            }
            catch
            {
                Console.Write("Animal not found. Please try again");
                DeleteAnimal();
            }
                

        Console.Write("Here are all the animals remaining in the database:");
            var animalList = db.AnimalsMasterLists;
            foreach (AnimalsMasterList animal in animalList)
            {
                Console.WriteLine("AnimalId = {0} , Name = {1}", animal.AnimalID , animal.Name);
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
    }
}
