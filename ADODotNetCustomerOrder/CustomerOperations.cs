using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace ADODotNetCustomerOrder
{
    public class CustomerOperations
    {
        public static SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog = CustomerDB; integrated security = true ");

        public static void CheckConnection()
        {
            using (SqlConnection con1 = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog = CustomerDB; integrated security = true "))
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

                Console.WriteLine("Somethiing went Wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }

        public bool Display()
        {
            try
            {
                using (con)
                {
                    Customer model = new Customer();
                    string query = "SELECT * FROM Customer";
                    SqlCommand command = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("-----------Data-------------");
                        while (reader.Read())
                        {
                            model.Customer_Id = Convert.ToInt32(reader["Customer_Id"]);
                            model.Customer_Name = Convert.ToString(reader["Customer_Name"]);
                            model.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                            model.Address = Convert.ToString(reader["Address"]);
                            model.Country = Convert.ToString(reader["Country"]);
                            model.Pincode = Convert.ToString(reader["Pincode"]);
                            model.Salary = Convert.ToDecimal(reader["Salary"]);
                            Console.WriteLine("Customer_Id: {0}\nCustomer_Name: {1}\nPhoneNumber: {2}\nAddress: {3}\nCountry: {4}\nPincode: {5}\nSalary: {6}\n",
                                               model.Customer_Id, model.Customer_Name, model.PhoneNumber, model.Address, model.Country, model.Pincode, model.Salary);
                        }
                    }
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something went Wrong" + e);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static void DeleteRecordFromTable()
        {
            try
            {
                string query = "DELETE FROM Customer WHERE Customer_Id = 7";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data deleted from the table.");
            }
            catch (Exception e)
            {

                Console.WriteLine("Somethiing went Wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }

        public static void UpdateIntoTable()
        {
            try
            {
                string query = "UPDATE Customer SET Address = 'Chandigarh' WHERE Customer_Id = 5";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Updated into the table.");
            }
            catch (Exception e)
            {

                Console.WriteLine("Somethiing went Wrong." + e);
            }
            finally
            {
                con.Close();
            }
        }

        public static void InsertCustomerTableUsingTransaction()
        {
            using (con)
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string query = "INSERT INTO Customer VALUES('Smith','111111111','Church Street','India','560055',36000.00)";
                    SqlCommand cmd = new SqlCommand(query,con,transaction);
                    cmd.ExecuteNonQuery();

                    string query1 = "INSERT INTO Customer VALUES('Racheal','888888888','Kormangla','India','560055',66000.00)";
                    cmd = new SqlCommand(query1,con,transaction);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine("Transaction Committed");

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Transaction RollBack");
                }
                finally
                {
                    con.Close( );
                }
            }

        }

        public static void InsertOrdersTableUsingTransaction()
        {
            using (con)
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string query = "INSERT INTO Orders(ProductName,Quantity,Rating,Customer_Id) VALUES('Product A','5',3,6)";
                    SqlCommand cmd = new SqlCommand(query, con, transaction);
                    cmd.ExecuteNonQuery();

                    string query1 = "INSERT INTO Orders(ProductName,Quantity,Rating,Customer_Id) VALUES('Product C','10',4,9)";
                    cmd = new SqlCommand(query1, con, transaction);
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine("Transaction Committed");

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Transaction RollBack" + e.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static void DisplayCustomerUsingTransaction()
        {
            using (con)
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                try
                {
                    Customer model = new Customer();
                    string query = "SELECT * FROM Customer";
                    SqlCommand cmd = new SqlCommand(query, con, transaction);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("-----------Data-------------");
                        while (reader.Read())
                        {
                            model.Customer_Id = Convert.ToInt32(reader["Customer_Id"]);
                            model.Customer_Name = Convert.ToString(reader["Customer_Name"]);
                            model.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                            model.Address = Convert.ToString(reader["Address"]);
                            model.Country = Convert.ToString(reader["Country"]);
                            model.Pincode = Convert.ToString(reader["Pincode"]);
                            model.Salary = Convert.ToDecimal(reader["Salary"]);
                            Console.WriteLine("Customer_Id: {0}\nCustomer_Name: {1}\nPhoneNumber: {2}\nAddress: {3}\nCountry: {4}\nPincode: {5}\nSalary: {6}\n",
                                               model.Customer_Id, model.Customer_Name, model.PhoneNumber, model.Address, model.Country, model.Pincode, model.Salary);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Available in the Table.");
                    }
                    reader.Close();
                    transaction.Commit();
                    Console.WriteLine("Transaction Committed");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Transaction Rollback " +e);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static void DisplayOrderUsingTransactions()
        {
            using (con)
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();
                try
                {
                    string query = "SELECT * FROM Orders";
                    SqlCommand cmd = new SqlCommand(query, con,transaction);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Console.WriteLine(reader["ProductName"] + ", " + reader["Quantity"] + ", " + reader["Rating"] + ", " + reader["Customer_Id"]);
                    }
                    reader.Close ();
                    transaction.Commit();
                    Console.WriteLine("Transaction Committed");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Transaction Rollback " + ex);
                }
                finally
                {
                    con.Close() ;
                }
            }
        }

    }
}
