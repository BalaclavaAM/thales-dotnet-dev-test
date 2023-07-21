
using thales_dotnet_dev_test.Data.Repositories;
using thales_dotnet_dev_test.Models;

namespace thales_dotnet_dev_test.BusinessLogic
{
    public class EmployeeService
    {
        private readonly EmployeesRepository _employeesRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(EmployeesRepository employeesRepository, ILogger<EmployeeService> logger)
        {
            _employeesRepository = employeesRepository;
            _logger = logger;
        }

        public async Task<List<Employee>> CalculateAnnualSalaries()
        {
            try
            {
                var employees = await _employeesRepository.GetEmployees();
                foreach (var employee in employees)
                {
                    employee.EmployeeAnualSalary = employee.EmployeeSalary * 12;
                }
                return employees;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating annual salaries of employees.");
                return new List<Employee>();
            }
        }

        public async Task<Employee> CalculateAnnualSalarieFromEmployee(int employeeId)
        {
            try
            {
                var employee = await _employeesRepository.GetEmployee(employeeId);
                if (employee != null)
                {
                    employee.EmployeeAnualSalary = employee.EmployeeSalary * 12;
                    return employee;
                }
                _logger.LogError("Employee id {EmployeeId} not found", employeeId);
                return new Employee();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating the employee's annual salary.");
                return new Employee();
            }
        }
    }

}