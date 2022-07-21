using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeJson
{
    public class EmployeeModel
    {
        public int Id { get; set; } = 1;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public decimal SalaryPerHour { get; set; }
    }
}
