using System.Text.Json.Serialization;

namespace thales_dotnet_dev_test.Models
{
    public class EmployeeResponse
    {
        [JsonPropertyName("status")]
        public required string Status { get; set; }

        [JsonPropertyName("data")]
        public Employee? Data { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}