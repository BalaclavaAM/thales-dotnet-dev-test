using thales_dotnet_dev_test.Models;
using thales_dotnet_dev_test.Data.Repositories;

namespace TestProject
{
    public class MockEmployeesRepository : IEmployeesRepository
    {
        public List<Employee> _employees;

        public MockEmployeesRepository()
        {
            // Initialize the mock data
            _employees = new List<Employee>
            {
                new Employee { Id = 1, EmployeeName = "Tiger Nixon", EmployeeSalary = 320800, EmployeeAge = 61, ProfileImage = "" },
                new Employee { Id = 2, EmployeeName = "Garrett Winters", EmployeeSalary = 170750, EmployeeAge = 63, ProfileImage = "" },
            };
        }

        public Task<List<Employee>> GetEmployees()
        {
            return Task.FromResult(_employees.ToList());
        }

        public Task<Employee> GetEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(employee);
        }
    }
}
