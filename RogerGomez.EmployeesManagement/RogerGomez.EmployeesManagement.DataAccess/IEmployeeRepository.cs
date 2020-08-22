using System.Collections.Generic;
using System.Threading.Tasks;
using RogerGomez.EmployeesManagement.Entities;

namespace RogerGomez.EmployeesManagement.DataAccess
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
