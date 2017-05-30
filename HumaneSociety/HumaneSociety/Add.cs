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
        Animal newAnimalInfo = new Animal();
        Search search = new Search();
        CSV csv = new CSV();
        Room room = new Room();
        public void AddMenu()
        {
            UI.AddMenuChoice();
            string addMenuChoice = Console.ReadLine();
            switch(addMenuChoice)
            {
                case "1":
                    newAnimalInfo.getAnimalInfo();
                    AddAnimal();
                    break;
                case "2":
                    csv.ConvertCSVtoDataTable(csv.filePath);
                    break;
            }
        }
        
        public void AddAnimal()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            AnimalsMasterList newAnimal = new AnimalsMasterList();
            newAnimal.Name = newAnimalInfo.name;
            newAnimal.AnimalType = newAnimalInfo.type;
            newAnimal.Price = newAnimalInfo.price;
            newAnimal.EntryDate = DateTime.Now;
            newAnimal.AdoptedDate = DateTime.Now;
            newAnimal.Adopted = newAnimal.Adopted;
            
            db.AnimalsMasterLists.InsertOnSubmit(newAnimal);

            db.SubmitChanges();

            AnimalsMasterList Animal = db.AnimalsMasterLists.FirstOrDefault(e => e.Name.Equals(newAnimalInfo.name));

            Console.WriteLine("Let's update the food and healthrecords for Animal Id = {0} , Name = {1}", Animal.AnimalID, Animal.Name);
            AddFood();
            AddHealth();
            AddAnimalToRoom();

            Console.Write("Now let's set some personality traits for the animal. These will be determined through a series of true / false questions.");
            AddTraits();

            DataClasses1DataContext datab = new DataClasses1DataContext();
            Trait addedTraits = new Trait();
            addedTraits.AnimalID = Animal.AnimalID;
            addedTraits.Energetic = newAnimalInfo.energetic;
            addedTraits.Cuddly = newAnimalInfo.cuddly;
            addedTraits.SpayedNuetered = newAnimalInfo.spayedNeutered;
            addedTraits.Young = newAnimalInfo.young;

            datab.Traits.InsertOnSubmit(addedTraits);

            datab.SubmitChanges();
            Console.WriteLine("\n Animal added. Press any key to return to Main Menu.\n");
            Console.ReadKey(); 
        }

        public void AddTraits()
        {
            Console.Write("Is the animal energetic? true / false\n");
            newAnimalInfo.energetic = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Is the animal cuddly? true / false?\n");
            newAnimalInfo.cuddly = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Is the animal spayed or nuetered? true / false\n");
            newAnimalInfo.spayedNeutered = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Is the animal young? true / false\n");
            newAnimalInfo.young = Convert.ToBoolean(Console.ReadLine());
        }
        public void AddHealth()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Shot addShot = new Shot();
            AnimalsMasterList Animal = db.AnimalsMasterLists.FirstOrDefault(e => e.Name.Equals(newAnimalInfo.name));
            addShot.AnimalID = Animal.AnimalID;
            UI.AskShotsStatus();
            addShot.Shots = Convert.ToBoolean(Console.ReadLine());

            db.Shots.InsertOnSubmit(addShot);
            db.SubmitChanges();
        }
        public void AddFood()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Food addFood = new Food();
            AnimalsMasterList Animal = db.AnimalsMasterLists.FirstOrDefault(e => e.Name.Equals(newAnimalInfo.name));
            addFood.AnimalID = Animal.AnimalID;
            UI.AskAnimalFoodAmount();
            addFood.Amount = Int32.Parse(Console.ReadLine());
            UI.AskAnimalFoodKind();
            addFood.Kind = Console.ReadLine();

            db.Foods.InsertOnSubmit(addFood);
            db.SubmitChanges();

        }
        public void RoomMenu()
        {
            UI.RoomMenu();
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    search.getAnimalIDByName();
                    search.CheckOpenRoom();
                    AddAnimalToRoom();
                    break;
                case "2":
                    search.CheckOpenRoom();
                    AddAnimalToRoom();
                    break;
            }
        }
        
        public void AddAnimalToRoom()
        {
            if (search.CheckOpenRoom() == false)
            {
                UI.AskAnimalID();
                room.animalID = Int32.Parse(Console.ReadLine());
                RoomNumber putAnimalInRoom = new RoomNumber();
                putAnimalInRoom.AnimalID = room.animalID;
                putAnimalInRoom.Room = room.room;
                putAnimalInRoom.Occupied = room.occupied;
                DataClasses1DataContext db = new DataClasses1DataContext();
                db.RoomNumbers.InsertOnSubmit(putAnimalInRoom);
                
                db.SubmitChanges();
            }
        }


    }
}
