using System.Text.Json.Serialization;
namespace thales_dotnet_dev_test.Models
{
    public class Employee
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("employee_name")]
        public string? EmployeeName { get; set; }

        [JsonPropertyName("employee_salary")]
        public long EmployeeSalary { get; set; }

        [JsonPropertyName("employee_age")]
        public long EmployeeAge { get; set; }

        [JsonPropertyName("profile_image")]
        public string? ProfileImage { get; set; }
        public long EmployeeAnualSalary { get; internal set; }
    }
}