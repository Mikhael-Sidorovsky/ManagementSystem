using ManagementSystem.Data.Dtos.Employees;
using System.Data.SqlClient;

namespace ManagementSystem.Business.Translators.Employees
{
    public interface IEmployeeTranslator
    {
        EmployeeDto TranslateAsUser(SqlDataReader reader, bool isList = false);

        List<EmployeeDto> TranslateAsEmployeesList(SqlDataReader reader);

        EmployeeDto TranslateAsEmployee(SqlDataReader reader);
    }
}
