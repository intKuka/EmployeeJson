using EmployeeJson;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No arguments was exposed");

            return;
        }
        try
        {
            var argsProcessor = new ArgsProcessor(args);

            switch (argsProcessor.operation)
            {
                case Operation.Add:
                    Console.WriteLine("Adding a record...");
                    JsonController.Add(argsProcessor);
                    break;

                case Operation.Update:
                    Console.WriteLine("Updating the record...");
                    JsonController.Update(argsProcessor);
                    break;

                case Operation.GetOne:
                    Console.WriteLine("Getting the record...");
                    JsonController.GetOne(argsProcessor);
                    break;

                case Operation.Delete:
                    Console.WriteLine("Deleting the record...");
                    JsonController.Delete(argsProcessor);
                    break;

                case Operation.GetAll:
                    Console.WriteLine("Getting all records");
                    JsonController.GetAll();
                    break;

                default:
                    Console.WriteLine("Invalid operation type. Somehow.");
                    return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return;
        }








    }
        
}

