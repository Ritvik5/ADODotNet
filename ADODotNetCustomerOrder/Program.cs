namespace ADODotNetCustomerOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To ADO.net\n");

            //CustomerOperations.CheckConnection();
            //CustomerOperations.InsertIntoTable();
            CustomerOperations.DeleteRecordFromTable();
            CustomerOperations obj = new CustomerOperations();
            //obj.Display();
        }
    }
}