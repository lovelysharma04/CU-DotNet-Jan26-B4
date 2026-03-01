using Microsoft.Data.SqlClient;
using System.Data;

namespace Week7Started
{
    internal class DemoSQL1
    {
        static void Main(string[] args)
        {
            
            try
            {
                using SqlConnection conn = new SqlConnection();
                {
                    conn.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=Northwind;Integrated Security=True;Trust Server Certificate=True";

                    conn.Open();
                    Console.WriteLine(conn.State);
                    if (conn.State == ConnectionState.Open)
                    {

                        //command--------------------------------------------
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "select categoryId, CategoryName from categories order by categoryID";
                        command.Connection = conn;

                        //read-----------------------------------------------
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]}, {reader[1]}");
                        }

                    }

                    
                }
            }
            catch(Exception ex)  
            { 
                Console.WriteLine(ex);
            }
        }
    }
}
