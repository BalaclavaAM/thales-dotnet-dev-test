using System.Text.Json;
using thales_dotnet_dev_test.Models;

namespace thales_dotnet_dev_test.Data.Repositories
{
    public class EmployeesRepository
    {
        private readonly ILogger<EmployeesRepository> _logger;
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://dummy.restapiexample.com/api/v1/";


        public EmployeesRepository(HttpClient httpClient, ILogger<EmployeesRepository> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}employees");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var employeeResponse = JsonSerializer.Deserialize<EmployeesResponse>(content);
                    if (employeeResponse != null && employeeResponse.Data != null)
                    {
                        employees = employeeResponse.Data.ToList();
                    }
                    else
                    {
                        _logger.LogWarning("The API didn't return employees.");
                    }
                }
                //check if 429
                else if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    _logger.LogWarning("We reached the limit of petitions to the API.");
                }
                else
                {
                    _logger.LogWarning("The API didn't return employees. StatusCode: {StatusCode}", response.StatusCode);
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error at obtaining eployees from the api.");
            }

            return employees;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee employee = new Employee();
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}employee/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var employeeResponse = JsonSerializer.Deserialize<EmployeeResponse>(content);
                    if (employeeResponse != null && employeeResponse.Data != null)
                    {
                        employee = employeeResponse.Data;
                    }
                    else
                    {
                        _logger.LogWarning("The employee was not obtained from the API.");
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    _logger.LogWarning("We reached the limit of petitions to the API.");
                }
                else
                {
                    _logger.LogWarning("The employee was not obtained from the API. StatusCode: {StatusCode}", response.StatusCode);
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error getting employee from API.");
            }
            return employee;
        }
    }
}