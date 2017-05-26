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
            
            Console.WriteLine("\nPress any key to return to Main Menu.");
            Console.ReadKey(); 
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
                    CheckOpenRoom();
                    AddAnimalToRoom();
                    break;
                case "2":
                    CheckOpenRoom();
                    AddAnimalToRoom();
                    break;
            }
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
            if (isFull.First() == false)
            {
                room.room = wantedRoomNumber;
                room.occupied = true;
                return false;
            }
            else
            {
                UI.RoomOccupied();
                CheckOpenRoom();
                return true;
            }
        }

        public void AddAnimalToRoom()
        {
            CheckOpenRoom();
            if (CheckOpenRoom() == false)
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
