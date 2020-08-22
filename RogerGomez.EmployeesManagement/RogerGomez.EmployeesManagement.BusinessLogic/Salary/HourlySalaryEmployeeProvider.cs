using RogerGomez.EmployeesManagement.Entities;

namespace RogerGomez.EmployeesManagement.BusinessLogic.Salary
{
    public class HourlySalaryEmployeeProvider : SalaryProvider
    {
        public override decimal GetSalary(Employee employee)
        {
            return 120 * employee.HourlySalary * 12;
        }
    }
}
