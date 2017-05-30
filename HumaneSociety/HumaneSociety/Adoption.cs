using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Adoption
    {
        Adopter adopter = new Adopter();
        Animal animalToAdopt = new Animal(); 

        public void AdoptionMenu()
        {
            Console.Write("Adoption Menu: 1: Adoption Application \n2: Adopt Animal\n3:Quit Menu\n");
            string adoptionMenuChoice = Console.ReadLine();
            bool runMenu = true;
            while (runMenu = true)
            {
                switch (adoptionMenuChoice)
                {
                    case "1":
                        AdoptionApplication();
                        break;
                    case "2":
                        AdoptAnimal();
                        break;
                    case "3":
                        runMenu = false;
                        break;
                    default:
                        AdoptionMenu();
                        break;
                }
            }
            
        }
        public void AdoptionApplication()
        {
            Console.Write("Welcome to the adoption application. Pleae tell us some basic information about yourself so we can contact you. After filling out this form, you will be sent to the serch menu where you can find out everything you want to know about ever animal in our system");
            Console.Write("First Name:");
            adopter.firstName = Console.ReadLine();
            Console.Write("Last Name");
            adopter.lastName = Console.ReadLine();
            Console.Write("Phone number (no spaces, dashes, or peridos");
            adopter.phone = Int32.Parse(Console.ReadLine());
            Console.Write("What kind of animal do you want to adopt? One word");
            adopter.typeOfAnimalWanted = Console.ReadLine();

            DataClasses1DataContext db = new DataClasses1DataContext();

            AdopterProfile newAdopter = new AdopterProfile();

            newAdopter.FirstName = adopter.firstName;
            newAdopter.LastName = adopter.lastName;
            newAdopter.PhoneNUmber = adopter.phone;
            newAdopter.typeAnimalWanted = adopter.typeOfAnimalWanted;

            db.AdopterProfiles.InsertOnSubmit(newAdopter);
            db.SubmitChanges();

            Console.Write("Thanks " + newAdopter.FirstName + "we'll contact you when we have an animal that you'd be interested in");

        }

        public void AdoptAnimal()
        {
            Console.Write("Enter the ID of the animal you wish to adopt");

            try
            {
                animalToAdopt.searchID = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                UI.NeedIntException();
                AdoptAnimal();
            }

            DataClasses1DataContext db = new DataClasses1DataContext();

            AnimalsMasterList deleteAnimal = db.AnimalsMasterLists.FirstOrDefault(e => e.Equals(animalToAdopt.searchID));
            try
            {
                db.AnimalsMasterLists.DeleteOnSubmit(deleteAnimal);

                db.SubmitChanges();
            }
            catch
            {
                Console.Write("Animal not found. Please try again");
                AdoptAnimal();
            }


            Console.Write("Here are all the animals remaining in the database:");
            var animalList = db.AnimalsMasterLists;
            foreach (AnimalsMasterList animal in animalList)
            {
                Console.WriteLine("AnimalId = {0} , Name = {1}", animal.AnimalID, animal.Name);
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
    


    }
}
