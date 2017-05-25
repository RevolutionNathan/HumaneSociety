using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class MainMenu
    {
        public void Menu()
        {
            Add add = new Add();
            Delete delete = new Delete();
            Register register = new HumaneSociety.Register();
            UserInterface.MainMenuChoice();
            Health health = new HumaneSociety.Health();
            Search search = new Search();
            Adoption adoption = new Adoption();
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    add.AddAnimal();
                    break;
                case "2":
                    delete.DeleteAnimal();
                    break;
                case "3":
                    register.RunRegister();
                    break;
                case "4":
                    health.HealthRecords();
                    break;
                case "5":
                    search.SearchAnimal();
                    break;
                case "6":
                    adoption.AdoptionApplication();
                    break;
                default:
                    Menu();
                    break;
            }
         }
    }
}
