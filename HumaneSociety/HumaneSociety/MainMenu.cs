using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class MainMenu
    {

        Add add = new Add();
        Delete delete = new Delete();
        Register register = new HumaneSociety.Register();
        Health health = new HumaneSociety.Health();
        Search search = new Search();
        Adoption adoption = new Adoption();
        private bool runMenu = false;
        public void Menu()
        {
            while (runMenu == false)
            {
                Console.Clear();
                UI.MainMenuChoice();
                string menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        add.AddMenu();
                        break;
                    case "2":
                        delete.DeleteAnimal();
                        break;
                    case "3":
                        register.RunRegister();
                        break;
                    case "4":
                        search.CheckOpenRoom();
                        break;
                    case "5":
                        health.HealthRecords();
                        break;
                    case "6":
                        search.SearchAnimal();
                        break;
                    case "7":
                        adoption.AdoptionApplication();
                        break;
                    case "8":
                        adoption.AdoptAnimal();
                        break;
                    case "9":
                        runMenu = true;
                        break;
                    default:
                        Menu();
                        break;
                }
            }
            
         }

      

    }
}
