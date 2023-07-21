using thales_dotnet_dev_test.BusinessLogic;
using thales_dotnet_dev_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace thales_dotnet_dev_test.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(EmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Employee>> Index()
        {
            _logger.LogInformation("Obteniendo empleados.");
            return await _employeeService.CalculateAnnualSalaries();
        }

        [HttpGet("{id}")]
        public async Task<Employee> Details(int id)
        {
            _logger.LogInformation("Obteniendo empleado con id {EmployeeId}", id);
            return await _employeeService.CalculateAnnualSalarieFromEmployee(id);
        }
    }
}