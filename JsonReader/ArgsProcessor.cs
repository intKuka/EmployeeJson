
namespace EmployeeJson
{
    /// <summary>
    /// ArgsProcessor is used to separate input arguments and an easier way to write data into C# objects from json
    /// </summary>
    public class ArgsProcessor
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
                }
                else if (arg.Contains("FirstName:"))
                {
                    firstName = arg[10..];
                }
                else  if (arg.Contains("LastName:"))
                {
                    lastName = arg[9..];
                }
                else if (arg.Contains("Salary:"))
                {
                    salary = decimal.Parse(arg[7..]);
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
