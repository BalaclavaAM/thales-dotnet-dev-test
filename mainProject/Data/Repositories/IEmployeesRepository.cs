using thales_dotnet_dev_test.Models;

namespace thales_dotnet_dev_test.Data.Repositories
{
    public interface IEmployeesRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
    }
}
