using ManagementSystem.Business.Services.Employees;
using ManagementSystem.Business.Utility.Interfaces.Employee;

namespace ManagementSystem.Business.Utility.Employee
{
    public class EmployeeDbClientFactory : DbClientFactory<EmployeeService>, IEmployeeDbClientFactory
    {
    }
}
