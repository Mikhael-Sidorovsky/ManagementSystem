using ManagementSystem.Data.Dtos.Employees;

namespace ManagementSystem.Business.Services.Employees
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(CreateEmployeeDto employeeDto);

        Task DeleteEmployeeAsync(long id);

        Task<EmployeeDto> GetEmployeeAsync(long id);

        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();

        Task<EmployeeDto> EnableEmployeeAsync(EnableEmployeeDto enableDto);

        Task<EmployeeDto> UpdateEmployeeAsync(UpdateEmployeeDto employeeDto);
    }
}
