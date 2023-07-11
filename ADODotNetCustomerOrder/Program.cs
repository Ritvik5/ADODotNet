namespace ADODotNetCustomerOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To ADO.net\n");
            Customer custbj = new Customer();

            //CustomerOperations.CheckConnection();
            //CustomerOperations.InsertIntoTable();
            //CustomerOperations.DeleteRecordFromTable();
            //CustomerOperations.UpdateIntoTable();
            CustomerOperations obj = new CustomerOperations();
            //obj.Display();
            //obj.InsertUsingStoredProcedure(custbj);
            //CustomerOperations.InsertCustomerTableUsingTransaction();
            CustomerOperations.InsertOrdersTableUsingTransaction();
        }
    }
}