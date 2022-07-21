using EmployeeJson;
using Newtonsoft.Json;

class Program
{
    
    
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No arguments was exposed");
            return;
        }
        var argsProcessor = new ArgsProcessor(args);
        

        //switch (args[0])
        //{
        //    case "-add":
        //        Console.WriteLine("add");
        //        JsonController.Add(args);
        //        break;
        //    case "-update":
        //        Console.WriteLine("update");
        //        JsonController.Update(args);
        //        break;
        //    case "-get":
        //        Console.WriteLine("get");
        //        JsonController.Add(args);
        //        break;
        //    case "-delete":
        //        Console.WriteLine("delete");
        //        JsonController.Add(args);
        //        break;
        //    case "-getall":
        //        Console.WriteLine("getall");
        //        JsonController.Add(args);
        //        break;
        //    default:
        //        Console.WriteLine("Wrong operation argument");
        //        return;
        //}





    }
        
}

