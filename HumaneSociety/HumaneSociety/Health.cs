using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Health
    {
        Search search = new Search();
        Animal healthAnimal = new Animal();
        public void HealthRecords()
        {
            UI.SearchShotsOrGiveShots();
            string healthMenuChoice = Console.ReadLine();
            switch (healthMenuChoice)
            {
                case "1":
                    ShotsSearch();
                    break;
                case "2":
                    GiveShot();
                    break;
                default:
                    HealthRecords();
                    break;
            }
        }
     
        public void GiveShot()
        {
            UI.AskAnimalID();
            try
            {
                int IdOfAnimalToBeInnoculated = Int32.Parse(Console.ReadLine());

                healthAnimal.searchID = IdOfAnimalToBeInnoculated;
                DataClasses1DataContext db = new DataClasses1DataContext();
                Shot animalShot = db.Shots.FirstOrDefault(e => e.AnimalID.Equals(healthAnimal.searchID));

                animalShot.Shots = true;

                db.SubmitChanges();
            }
            catch
            {
                UI.NeedValidID();
                GiveShot();
            }
         
        }

        public void ShotsSearch()
        {
            try
            {
                UI.AskAnimalID();
                healthAnimal.searchID = Int32.Parse(Console.ReadLine());

                DataClasses1DataContext db = new DataClasses1DataContext();

                var Shot = db.GetTable<Shot>();
                var ShotList = from i in Shot
                               where i.AnimalID == healthAnimal.searchID
                               select i.Shots;
                Console.Write(ShotList);
            }
            catch
            {
                UI.NeedValidID();
                ShotsSearch();
            }
           

        }
    }
}
