using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace HumaneSociety
{
    
    class CSV
    {
       
        public string filePath = "//Mac/Home/Desktop/devCode/C#/HumaneSociety/HumaneSociety - Sheet1.csv";
       
        public DataTable dt = new DataTable();

        public DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(',');
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public void InsertIntoDatabase(DataTable dt)
        {
            using (SqlConnection connect = new SqlConnection())
            {
                connect.ConnectionString = "Server=localhost;Database=HumaneSociety;Trusted_Connection=True";
                connect.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connect))
                {
                    bulkCopy.DestinationTableName =
                        "dbo.AnimalsMasterList";
                    try
                    {
                        
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
        }







    }

}





//public void TransferCSVToTable(string filePath)
//{
//    string[] csvRows = System.IO.File.ReadAllLines(filePath);
//    string[] fields = null;
//    string[] headers = null;
//    foreach (string csvRow in csvRows)
//    {
//        fields = csvRow.Split(',');
//        DataRow row = dt.NewRow();
//        row.ItemArray = fields;
//        dt.Rows.Add(row);
//    }
//    Console.Write(dt);
////}

//          foreach (DataRow row in dt.Rows)
//                {
//                    foreach( var item in row.ItemArray)
//                    {
//                        int i = 0;
//var name = dt.Rows[i];
//var roomNumber = dt.Rows[i + 1];
//var animalType = dt.Rows[i + 2];
//var date = dt.Rows[i + 3];
//i++;
//                    }
//                    string query = "INSERT INTO AnimalsMasterList (name, roomNumber, animalType, date) VALUES (@Name, @RoomNumber, @AnimalType @date)";
//SqlCommand insertCommand = new SqlCommand(query, connect);
//insertCommand.Parameters.AddWithValue("@name", name);
//                    insertCommand.ExecuteNonQuery();