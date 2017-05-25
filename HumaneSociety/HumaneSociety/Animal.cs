using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Animal
    {
        public string name = "new animal";
        public int price = 0;
        public string type = "new animal";
        public DateTime entryDate = DateTime.Now;
        public DateTime adoptedDate = DateTime.Now;
        public bool adopted  = false;
        public string food = "food";
        public int foodAmount = 0;
        public bool shots = true;
        public string gender = "M/F";
        public bool energetic;
        public bool cuddly;
        public bool spayedNeutered;
        public bool young;
        
        public void getAnimalInfo()
        {
            UI.GetAnimalName();
            name = Console.ReadLine();
            UI.AskAnimalType();
            type = Console.ReadLine();
            UI.AskAnimalPrice();
            price = Int32.Parse(Console.ReadLine());
            UI.AskAnimalFoodAmount();
            food = Console.ReadLine();
            UI.AskShotsStatus();
            shots = bool.Parse(Console.ReadLine());
            UI.AskGender();
            gender = Console.ReadLine();
            //UI.AskColor();
            //color = Console.ReadLine();
            //UI.AskPersonality();
            //personality = Console.ReadLine();
        }

       

    }
}
