
namespace EmployeeJson
{
    /// <summary>
    /// ArgsProcessor is used to separate input arguments and for easier data transffering between Json records and list of C# objects
    /// </summary>
    internal class ArgsProcessor
    {
        public Operation operation;
        public int id;
        public string firstName = string.Empty;
        public string lastName = string.Empty;
        public decimal? salary;

        public ArgsProcessor(string[] args)
        {
            GetArgsValues(args);
        }

        public ArgsProcessor GetArgsValues(string[] args)
        {
            foreach (var arg in args)
            {                
                if (arg.Contains("Id:"))
                {
                    id = int.Parse(arg[3..]);
                    Console.WriteLine("id");
                    continue;
                }
                else if (arg.Contains("FirstName:"))
                {
                    firstName = arg[10..];
                    Console.WriteLine("FirstName");
                    continue;
                }
                else  if (arg.Contains("LastName:"))
                {
                    lastName = arg[9..];
                    Console.WriteLine("LastName");
                    continue;
                }
                else if (arg.Contains("Salary:"))
                {
                    salary = decimal.Parse(arg[7..]);
                    Console.WriteLine("salary");
                    continue;
                }
                else
                {
                    operation = arg switch
                    {
                        "-add" => Operation.Add,
                        "-update" => Operation.Update,
                        "-delete" => Operation.Delete,
                        "-get" => Operation.GetOne,
                        "-getall" => Operation.GetAll,
                        _ => throw new Exception("Wrong operation type"),
                    };
                }
            }

            return this;
        }


    }

    public enum Operation
    {
        Add,
        Update,
        Delete,
        GetOne,
        GetAll,
    }
}
