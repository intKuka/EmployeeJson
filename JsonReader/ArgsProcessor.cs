using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeJson
{
    internal class ArgsProcessor
    {
        Operation operation;
        int id;
        string firstName = string.Empty;
        string lastName = string.Empty;
        decimal salary;

        public ArgsProcessor(string[] args)
        {
            this.GetArgsValues(args);
        }

        public ArgsProcessor GetArgsValues(string[] args)
        {
            foreach (var arg in args)
            {
                switch (arg)
                {
                    case "-add":
                        operation = Operation.Add;
                        break;
                    case "-update":
                        operation = Operation.Update;
                        break;
                    case "-delete":
                        operation = Operation.Delete;
                        break;
                    case "-get":
                        operation = Operation.GetOne;
                        break;
                    case "-getall":
                        operation = Operation.GetAll;
                        break;
                    default:
                        break;
                }
                if (arg.Contains("Id:"))
                {
                    id = int.Parse(arg[3..]);
                    Console.WriteLine("id");
                }
                if (arg.Contains("FirstName:"))
                {
                    firstName = arg[10..];
                    Console.WriteLine("FirstName");
                }
                if (arg.Contains("LastName:"))
                {
                    lastName = arg[9..];
                    Console.WriteLine("LastName");
                }
                if (arg.Contains("Salary:"))
                {
                    salary = decimal.Parse(arg[7..]);
                    Console.WriteLine("salary");
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
