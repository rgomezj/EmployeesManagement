using RogerGomez.EmployeesManagement.Entities;

namespace RogerGomez.EmployeesManagement.BusinessLogic.Salary
{
    public class MonthlySalaryEmployeeProvider : SalaryProvider
    {
        public override decimal GetSalary(Employee employee)
        {
            return employee.MonthlySalary * 12;
        }
    }
}
