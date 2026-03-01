using Microsoft.Data.SqlClient;
using System.Data;

namespace Week7Started
{
    internal class DemoSQL3DataSetCRUD
    {
        static void Main(string[] args)
        {
            try
            {
                using SqlConnection conn = new SqlConnection();
                {
                    DataSet dataSet = new DataSet();
                    conn.ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=Northwind;Integrated Security=True;Trust Server Certificate=True";

                    conn.Open();
                    Console.WriteLine(conn.State);
                    if (conn.State == ConnectionState.Open)
                    {

                        //command--------------------------------------------
                        SqlCommand command = new SqlCommand();

                        command.CommandText = "Select ProductId, ProductName, UnitPrice from Products";

                        command.Connection = conn;

                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet, "Prod");
                        Console.WriteLine(dataSet.Tables["Prod"].Rows[1][1]);

                        dataSet.Tables["Prod"].Rows[1][1] = "Chang";
                        dataSet.Tables["Prod"].Rows[1][2] = 25;

                        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                        adapter.Update(dataSet, "Prod");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
