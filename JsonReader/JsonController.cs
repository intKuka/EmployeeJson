using Newtonsoft.Json;

namespace EmployeeJson
{
    internal class JsonController
    {
        readonly static string jsonPath = Path.Combine(Environment.CurrentDirectory, @"Json\", "Employees.json");
        static List<EmployeeModel> employees = new();

        //ADD new record
        public static void Add(ArgsProcessor processor)
        {
            var employee = new EmployeeModel()
            {
                FirstName = processor.firstName,
                LastName = processor.lastName,
                SalaryPerHour = (decimal)processor.salary,
            };
            LoadFromJson(jsonPath);
            if (employees.Count > 0)
            {
                employee.Id = employees.Max(e => e.Id) + 1;                
            }               
            employees.Add(employee);
            LoadToJson(employees, jsonPath);
            Console.WriteLine("Creation is completed");
        }

        //UPDATE the record by id
        public static void Update(ArgsProcessor processor)
        {
            LoadFromJson(jsonPath);
            if (employees.Count == 0)
            {
                throw new Exception("No records in the file");
            }
            if (IdExists(employees, processor.id) == false)
            {
                throw new Exception("Given id is not exists");
            }
            var employee = employees.First(e => e.Id == processor.id);
            employee.FirstName = processor.firstName ?? employee.FirstName;
            employee.LastName = processor.lastName ?? employee.LastName;
            if (processor.salary != null) employee.SalaryPerHour = (decimal)processor.salary;
            LoadToJson(employees, jsonPath);
            Console.WriteLine($"Update of Id:{processor.id} is complited");
        }

        //GET one record by id
        public static void GetOne(ArgsProcessor processor)
        {
            LoadFromJson(jsonPath);
            if (employees.Count == 0)
            {
                throw new Exception("No records in the file");
            }
            if (IdExists(employees, processor.id) == false)
            {
                throw new Exception("Given id is not exists");
            }
            var employee = employees.First(e => e.Id == processor.id);
            Console.WriteLine("Id = {0}, FirstName = {1}, LastName = {2}, SalaryPerHour = {3:0.00}", employee.Id, employee.FirstName, employee.LastName, employee.SalaryPerHour);            
        }

        //GET ALL records from a json file
        public static void GetAll()
        {
            LoadFromJson(jsonPath);
            if (employees.Count == 0)
            {
                throw new Exception("No records in the file");
            }
            foreach (var employee in employees)
            {
                Console.WriteLine("Id = {0}, FirstName = {1}, LastName = {2}, SalaryPerHour = {3:0.00}", employee.Id, employee.FirstName, employee.LastName, employee.SalaryPerHour);
            }
        }


        //DELETE a record by id
        public static void Delete(ArgsProcessor processor)
        {
            LoadFromJson(jsonPath);
            if (employees.Count == 0)
            {
                throw new Exception("No records in the file");
            }
            if (IdExists(employees, processor.id) == false)
            {
                throw new Exception("Given id is not exists");
            }
            var employee = employees.First(e => e.Id == processor.id);
            employees.Remove(employee);
            LoadToJson(employees, jsonPath);
            Console.WriteLine($"Deletion of Id:{processor.id} is completed");
        }

        //returns a boolean value based on id
        static bool IdExists(IEnumerable<EmployeeModel> employees, int IdToFind)
        {
            var employee = employees.Single(e => e.Id == IdToFind);
            if (employee == null) return false;
            return true;
        }

        
        //load data to the list from a json file
        static void LoadFromJson(string path)
        {
            using (StreamReader r = new(path))
            {
                string json = r.ReadToEnd();
                employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(json);
            }
        }

        //write data from the list to a json file
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
