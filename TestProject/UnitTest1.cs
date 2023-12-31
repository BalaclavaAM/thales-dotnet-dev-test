using Microsoft.Extensions.Logging.Abstractions;
using thales_dotnet_dev_test.Data.Repositories;
using thales_dotnet_dev_test.Models;
using thales_dotnet_dev_test.BusinessLogic;

namespace TestProject
{
    [TestClass]
    public class BusinessLogicTests
    {
        // Mock the EmployeesRepository using Moq
        private readonly MockEmployeesRepository _mockEmployeesRepository = new MockEmployeesRepository();

        [TestMethod]
        public async Task CalculateAnnualSalaries_ShouldCalculateCorrectly()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { Id = 1, EmployeeSalary = 50000 },
                new Employee { Id = 2, EmployeeSalary = 60000 }
            };

            _mockEmployeesRepository._employees = employees;

            var businessLogic = new EmployeeService(_mockEmployeesRepository, new NullLogger<EmployeeService>());

            // Act
            var result = await businessLogic.CalculateAnnualSalaries();

            // Assert
            Assert.AreEqual(600000, result[0].EmployeeAnualSalary);
            Assert.AreEqual(720000, result[1].EmployeeAnualSalary);
        }

        [TestMethod]
        public async Task CalculateAnnualSalarieFromEmployee_ValidId_ShouldCalculateCorrectly()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee { Id = employeeId, EmployeeSalary = 50000 };

            _mockEmployeesRepository._employees = new List<Employee> { employee };

            var businessLogic = new EmployeeService(_mockEmployeesRepository, new NullLogger<EmployeeService>());

            // Act
            var result = await businessLogic.CalculateAnnualSalarieFromEmployee(employeeId);

            // Assert
            Assert.AreEqual(600000, result.EmployeeAnualSalary);
        }
    }
}
