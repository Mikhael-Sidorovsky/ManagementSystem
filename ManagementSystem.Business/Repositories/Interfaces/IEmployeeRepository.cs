using ManagementSystem.Data.Dtos.Employees;
using System.Data.SqlClient;

namespace ManagementSystem.Business.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<EmployeeDto>
    {
        Task<string?> CreateEmployeeAsync(CreateEmployeeDto employeeDto);

        Task<string?> DeleteEmployeeAsync(long id);

        Task<EmployeeDto> GetEmployeeAsync(long id, Func<SqlDataReader, EmployeeDto> translator);

        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Func<SqlDataReader, IEnumerable<EmployeeDto>> translator);

        Task<string?> EnableEmployeeAsync(EnableEmployeeDto enableDto);

        Task<string?> UpdateEmployeeAsync(UpdateEmployeeDto employeeDto);
    }
}
