using ManagementSystem.Business.Repositories.Interfaces;
using ManagementSystem.Business.Services.Employees;
using ManagementSystem.Business.Translators.Employees;
using ManagementSystem.Data.Dtos.Employees;
using NSubstitute;
using System.Data;

namespace ManagementSystem.Tests.Services
{
    public class EmployeeServiceTests
    {
        private IEmployeeService _employeeService;
        private IEmployeeRepository _employeeRepository;
        private IEmployeeTranslator _employeeTranslator;

        [SetUp]
        public void Setup()
        {
            _employeeRepository = Substitute.For<IEmployeeRepository>();
            _employeeTranslator = Substitute.For<IEmployeeTranslator>();
        }

        [Test]
        public async Task GetEmployees_Returns_List_Of_Employee()
        {
            // Arrange

            _employeeRepository.GetEmployeesAsync(r => _employeeTranslator.TranslateAsEmployeesList(r)).Returns(Task.FromResult(new List<EmployeeDto>().AsEnumerable()));
            _employeeService = new EmployeeService(_employeeRepository, _employeeTranslator);

            // Act

            var res = await _employeeService.GetEmployeesAsync();

            // Assert

            Assert.NotNull(res);
        }

        [Test]
        public async Task DeleteEmployeeAsync_Throws_Error_When_Employee_Does_Not_Exist()
        {
            // Arrange

            _employeeRepository.DeleteEmployeeAsync(Arg.Any<long>()).Returns(Task.FromResult("C203"));
            _employeeService = new EmployeeService(_employeeRepository, _employeeTranslator);

            Assert.ThrowsAsync<Exception>(async () => await _employeeService.DeleteEmployeeAsync(10));
        }

        [Test]
        public async Task DeleteEmployeeAsync_Does_Not_Throw_Error_When_Employee_Exists()
        {
            // Arrange

            _employeeRepository.DeleteEmployeeAsync(Arg.Any<long>()).Returns(Task.FromResult("C200"));
            _employeeService = new EmployeeService(_employeeRepository, _employeeTranslator);

            // Assert

            Assert.DoesNotThrowAsync(async () => await _employeeService.DeleteEmployeeAsync(10));
        }

        [Test]
        public async Task EnableEmployeeAsync_Throws_Error_When_Employee_Does_Not_Exist()
        {
            // Arrange

            _employeeRepository.EnableEmployeeAsync(Arg.Any<EnableEmployeeDto>()).Returns(Task.FromResult("C203"));
            _employeeService = new EmployeeService(_employeeRepository, _employeeTranslator);

            // Assert

            Assert.ThrowsAsync<Exception>(async () => await _employeeService.EnableEmployeeAsync(new EnableEmployeeDto()));
        }

        [Test]
        public async Task EnableEmployeeAsync_Does_Not_Throw_Error_When_Employee_Exists()
        {
            // Arrange

            _employeeRepository.EnableEmployeeAsync(Arg.Any<EnableEmployeeDto>()).Returns(Task.FromResult("C200"));
            _employeeService = new EmployeeService(_employeeRepository, _employeeTranslator);

            // Assert

            Assert.DoesNotThrowAsync(async () => await _employeeService.EnableEmployeeAsync(new EnableEmployeeDto()));
        }
    }
}
