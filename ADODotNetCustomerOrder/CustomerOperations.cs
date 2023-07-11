using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADODotNetCustomerOrder
{
    public class CustomerOperations
    {
        public static SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog = CustomerDB; integrated security = true ");

        public static void CheckConnection()
        {
            using(SqlConnection con1 = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog = CustomerDB; integrated security = true "))
            {
                con.Open();
                Console.WriteLine("Connection Established Successfully");
            }
        }

        public static void InsertIntoTable()
        {
            try
            {
                string query = "insert into Customer values('Smith','111111111','Church Street','India','560055',36000.00)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data inserted into the table.");
            }
            catch (Exception e)
            {

                Console.WriteLine("Somethiing went Wrong."+e);
            }finally
            {
                con.Close();
            }
        }
    }
}
