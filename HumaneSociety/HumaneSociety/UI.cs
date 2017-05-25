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
            Console.Write("Main Menu:\n 1: Add Animal\n 2: Delete Animal\n 3 Register\n 4 Health Records\n 5 Search Animal\n 6 Adoption Application \n");
        }

        public static void AddMenuChoice()
        {
            Console.Write("Add Menu:\n 1: Maually add individual animal;\n 2: Bulk upload from .csv file\n");
        }
        public static void GetAnimalName()
        {
            Console.Write("What is the name of the new animal? \n");
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
            Console.Write("1: Search Animal ID before adding to room \n 2: Animal ID already known");
        }
        public static void AskAnimalID()
        {
            Console.Write("What is the ID number of the animal?");
        }    

        public static void AskAnimalName()
        {
            Console.Write("What is the name of the animal you're looking for?");
        }
        public static void AskRoomNumber()
        {
            Console.Write("What number do you want to put the animal in?");
        }
        public static void RoomOccupied()
        {
            Console.Write("That room is currently occupied. Please pick another room");
        }
        public static void AskAnimalPrice()
        {
            Console.Write("Set the price of the new animal \n");
        }

        public static void AskAnimalFoodAmount()
        {
            Console.Write("Enter the quantity of food the animal eats \n");
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
