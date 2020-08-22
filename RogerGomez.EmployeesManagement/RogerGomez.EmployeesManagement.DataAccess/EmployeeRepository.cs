using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RogerGomez.EmployeesManagement.DataAccess.Services;
using RogerGomez.EmployeesManagement.Entities;

namespace RogerGomez.EmployeesManagement.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeService _employeeService;

        public EmployeeRepository(EmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var response = await this._employeeService.GetEmployees();
            return JsonConvert.DeserializeObject<IEnumerable<Employee>>(response);
        }
    }
}
