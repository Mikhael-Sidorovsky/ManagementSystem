using ManagementSystem.Business.Services.Employees;

namespace ManagementSystem.Business.Utility.Interfaces.Employee
{
    public interface IEmployeeDbClientFactory : IDbClientFactory<EmployeeService>
    {
    }
}
