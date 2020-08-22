using RogerGomez.EmployeesManagement.Entities;

namespace RogerGomez.EmployeesManagement.BusinessLogic.Salary
{
    public abstract class SalaryProvider
    {
        public abstract decimal GetSalary(Employee employee);
    }
}
