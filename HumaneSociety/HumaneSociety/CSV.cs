using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class CSV
    {
        public void WriteCSVtoSQL()
        {
            var lines = System.IO.File.ReadAllLines(@"/Library/Prefer/Users/nathanwhitcomb/Desktop/devCode/C#/HumaneSociety/HumaneSociety - Sheet1.csvences/SystemConfiguration/");
            if (lines.Count() == 0) return;
            var columns = lines[0].Split(',');
            var table = new MasterListAnimal();

            for (int i = 1; i < lines.Count() - 1; i++)
                table.Rows.Add(lines[i].Split(','));

            var connection = "Server=localhost;Database=HumaneSociety;Trusted_Connection=True"; ;
            var sqlBulk = new SqlBulkCopy(connection);
            sqlBulk.DestinationTableName = "Table1";
            sqlBulk.WriteToServer(table);
        }
    }
       
}
