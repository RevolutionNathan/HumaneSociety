using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Delete
    {
        public void DeleteAnimal()
        {
            
                DataClasses1DataContext db = new DataClasses1DataContext();

                //Get Employee to Delete
                AnimalsMasterList deleteAnimal = db.AnimalsMasterLists.FirstOrDefault(e => e.Name.Equals("George Michael"));

                //Delete Employee
                db.AnimalsMasterLists.DeleteOnSubmit(deleteAnimal);

                //Save changes to Database.
                db.SubmitChanges();

                //Get All Employee from Database
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
