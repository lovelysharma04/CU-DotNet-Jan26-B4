using Microsoft.Data.SqlClient;
using System.Data;

namespace Week7Started
{
    internal class DemoSQL2NonQuery
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

                        Console.WriteLine("Enter CategoryName: ");
                        string newCat= Console.ReadLine();

                        command.CommandText = "update categories set categoryname = @newCat where categoryid = 9";

                        command.Parameters.AddWithValue("@newCat", newCat);  //do not support sql injection
                        command.Connection = conn;



                        //write-------- update -------------------------------
                        int effectedRows = command.ExecuteNonQuery();
                        Console.WriteLine($"{effectedRows} rows effected....");

                        
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
