using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RogerGomez.EmployeesManagement.BusinessLogic.Salary.Factories;
using RogerGomez.EmployeesManagement.DataAccess;
using RogerGomez.EmployeesManagement.Entities;

namespace RogerGomez.EmployeesManagement.BusinessLogic
{
    public class EmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await this._employeeRepository.GetEmployees();
            var employeesWithSalary = employees.Select(c => { c.Salary = SalaryProviderFactory.CreateSalaryProvider(c.TypeOfContract).GetSalary(c); return c; });
            return employeesWithSalary;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employees = await this._employeeRepository.GetEmployees();
            var employee = employees.Where(c => c.Id == id).FirstOrDefault();
            if (employee != null)
            {
                employee.Salary = SalaryProviderFactory.CreateSalaryProvider(employee.TypeOfContract).GetSalary(employee);
            }
            return employee;
        }
    }
}
