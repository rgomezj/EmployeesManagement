using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using RogerGomez.EmployeesManagement.BusinessLogic;
using RogerGomez.EmployeesManagement.DataAccess;
using RogerGomez.EmployeesManagement.Entities;

namespace RogerGomez.EmployeesManagement.Tests
{
    public class EmployeeManagerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SalaryForMonthlySalaryEmployee()
        {
            var mockRepository = new Mock<IEmployeeRepository>();
            Employee employeeMonthly = new Employee() { MonthlySalary = 1000, TypeOfContract = TypeOfContract.MonthlySalaryEmployee, Id = 100 };
            IEnumerable<Employee> employees = new List<Employee>() { employeeMonthly };
            mockRepository.Setup(c => c.GetEmployees()).Returns(Task.FromResult(employees));

            EmployeeManager employeeManager = new EmployeeManager(mockRepository.Object);
            Employee employee = employeeManager.GetEmployeeById(100).Result;

            Assert.IsTrue(employee.Salary == 12000);
        }

        [Test]
        public void SalaryForHourlySalaryEmployee()
        {
            var mockRepository = new Mock<IEmployeeRepository>();
            Employee employeeMonthly = new Employee() { HourlySalary = 15, TypeOfContract = TypeOfContract.HourlySalaryEmployee, Id = 100 };
            IEnumerable<Employee> employees = new List<Employee>() { employeeMonthly };
            mockRepository.Setup(c => c.GetEmployees()).Returns(Task.FromResult(employees));

            EmployeeManager employeeManager = new EmployeeManager(mockRepository.Object);
            Employee employee = employeeManager.GetEmployeeById(100).Result;

            Assert.IsTrue(employee.Salary == 21600);
        }
    }
}