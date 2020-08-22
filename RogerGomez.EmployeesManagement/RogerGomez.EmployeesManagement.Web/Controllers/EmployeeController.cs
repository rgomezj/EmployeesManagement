using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using RogerGomez.EmployeesManagement.BusinessLogic;
using RogerGomez.EmployeesManagement.Entities;

namespace RogerGomez.EmployeesManagement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeManager _employeeManager;

        public EmployeeController(ILogger<EmployeeController> logger, EmployeeManager employeeManager)
        {
            _logger = logger;
            _employeeManager = employeeManager;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await this._employeeManager.GetEmployees();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await this._employeeManager.GetEmployeeById(id);
            if(employee == null)
            {
                return NotFound();
            }
            else
            {
                return employee;
            }
        }
    }
}
