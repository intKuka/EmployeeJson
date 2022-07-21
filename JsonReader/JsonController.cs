using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeJson
{
    internal class JsonController
    {
        readonly static string jsonPath = Path.Combine(Environment.CurrentDirectory, @"Json\", "Employees.json");
        static List<EmployeeModel> employees = new();

        public static void Add(string[] args)
        {
            var employee = new EmployeeModel()
            {
                FirstName = args[1].Substring(10),
                LastName = args[2].Substring(9),
                SalaryPerHour = decimal.Parse(args[3].Substring(7)),
            };
            LoadFromJson(jsonPath);
            if (employees.Count > 0)
            {
                employee.Id = employees.Max(e => e.Id) + 1;                
            }               
            employees.Add(employee);
            LoadToJson(employees, jsonPath);
        }
        public static void Update(string[] args)
        {
            LoadFromJson(jsonPath);
            if (employees.Count == 0)
            {
                Console.WriteLine("No record in the file");
                return;
            }
            employees.First(e => e.Id == int.Parse(args[1].Substring(3)));

        }

        //methods for read and write a data to the json

        static void LoadFromJson(string path)
        {
            using (StreamReader r = new(path))
            {
                string json = r.ReadToEnd();
                employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(json);
            }
        }
        static void LoadToJson(IEnumerable<EmployeeModel> employees, string path)
        {
            var json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            if (File.Exists(path) == false)
            {
                File.WriteAllText(path, json);
            }
            else
            {
                File.Delete(path);
                File.WriteAllText(path, json);
            }
        }
    }
}
