using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    static class UI
    {
        public static void MainMenuChoice()
        {
            Console.Write("Main Menu:\n 1: Add Animal\n 2: Delete Animal\n 3 Register\n 4 Rooming \n 5 Health Records\n 6 Search Animal\n 7 Adoption Application \n 8 Adopt Animal \n 9 Quit\n");
        }

        public static void AddMenuChoice()
        {
            Console.Write("Add Menu:\n 1: Maually add individual animal;\n 2: Bulk upload from .csv file\n");
        }

        public static void KindSearch()
        {
            Console.Write("what kind of animal are you searching for?\n");
        }
        public static void Cuddly()
        {
            Console.Write("are you seeking a cuddly animal true / false\n");
        }

        public static void SearchShotsOrGiveShots()
        {
            Console.Write("1: search animal innoculation records\n 2: give shots\n");
        }
        public static void Young()
        {
            Console.Write("are you seeking a young animal?\n");
        }
        public static void SpayNuet()
        {
            Console.Write("are you seeking an animals that's already spayed or neutered? true / false\n");
        }
        public static void GetAnimalName()
        {
            Console.Write("What is the name of the new animal? \n");
        }
        public static void Energetic()
        {
            Console.Write("are you seeking an energetic animal? true / false\n");
        }

        public static void GetAnimalRoomNumber()
        {
            Console.Write("What room do yo want to put the new animal in? \n");
        }

        public static void NeedStringException()
        {
            Console.Write("Please enter a string \n");
        }

        public static void NeedIntException()
        {
            Console.Write("Please enter an int \n");
        }

        public static void NeedDateTimeException()
        {
            Console.Write("Please enter date time format \n");
        }

        public static void AskAnimalType()
        {
            Console.Write("What kind of animal is the new animal? \n");
        }

        public static void RoomMenu()
        {
            Console.Write("1: Search Animal ID before adding to room \n 2: Animal ID already known\n");
        }
        public static void AskAnimalID()
        {
            Console.Write("What is the ID number of the animal?\n");
        }
        public static void SearchAnimalMenu()
        {
            Console.WriteLine("1: search food quantity 2: search animal by type 3: search animal by traits\n");
        }
        public static void AskAnimalName()
        {
            Console.Write("What is the name of the animal you're looking for?\n");
        }
        public static void AskRoomNumber()
        {
            Console.Write("What number do you want to put the animal in?\n");
        }
        public static void EnterIDYouWant()
        {
            Console.Write("Enter the ID of the animal you're looking for\n");
        }
        public static void ListIDsFromNameSearch()
        {
            Console.Write("here are the ids that match the name of the animal you're looking for\n");
        }

        public static void AnimalNameQuery()
        {
            Console.Write("Do you know the name of the animal you're searching for? 1: yes; 2: no\n");
        }

        public static void RoomOccupied()
        {
            Console.Write("That room is currently occupied. Please pick another room\n");
        }
        public static void AskAnimalPrice()
        {
            Console.Write("Set the price of the new animal \n");
        }
        public static void AskAnimalFoodKind()
        {
            Console.Write("What kind of food does the animal eat?\n");
        }
        public static void AskAnimalFoodAmount()
        {
            Console.Write("Enter the quantity of food the animal eats \n");
        }
        public static void RoomOPen()
        {
            Console.Write("That room is currently unoccupied");
        }
        public static void NeedValidID()
        {
            Console.Write("Please enter a valid Animal ID\n");
        }
        public static void AskShotsStatus()
        {
            Console.Write("Does the animal have it's shots? (enter true / false) \n");
        }

        public static void AskGender()
        {
            Console.Write("What gender is the animal? \n");
        }

        public static void AskColor()
        {
            Console.Write("What color is the new animal? \n");
        }
            
        public static void AskPersonality()
        {
            Console.Write("Describe the animal's personality in one word \n");
        }
    }
}
