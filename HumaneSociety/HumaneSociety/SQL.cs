using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class SQL
    {

        public string searchName;

        public void InsertIntoDatabase()
        {
            using (SqlConnection connect = new SqlConnection())
            {
                connect.ConnectionString = "Server=localhost;Database=HumaneSociety;Trusted_Connection=True";
                connect.Open();
                string query = "INSERT INTO AnimalsMasterList (Name, RoomNumber, AnimalType) VALUES (@Name, @RoomNumber, @AnimalType)";
                SqlCommand insertCommand = new SqlCommand(query, connect);
                insertCommand.Parameters.AddWithValue("@Name", /*humanPlayer.name*/);
                
                insertCommand.ExecuteNonQuery();
            }
        }

    }
}
