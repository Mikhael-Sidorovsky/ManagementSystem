using ManagementSystem.Business.Extentions;
using ManagementSystem.Data.Dtos.Employees;
using System.Data;
using System.Data.SqlClient;

namespace ManagementSystem.Business.Translators.Employees
{
    public class EmployeeTranslator : IEmployeeTranslator
    {
        public EmployeeDto TranslateAsUser(SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                {
                    return null;
                }

                reader.Read();
            }
            EmployeeDto item = new();
            if (reader.IsColumnExists("Id"))
            {
                item.Id = reader.GetNullableInt32("Id");
            }

            if (reader.IsColumnExists("Name"))
            {
                item.Name = reader.GetNullableString("Name");
            }

            if (reader.IsColumnExists("Id"))
            {
                item.Id = reader.GetNullableInt32("Id");
            }

            if (reader.IsColumnExists("Enabled"))
            {
                item.Enabled = reader.GetBoolean("Enabled");
            }

            if (reader.IsColumnExists("CreatedAt"))
            {
                item.CreatedAt = reader.GetDateTime("CreatedAt");
            }

            return item;
        }

        public List<EmployeeDto> TranslateAsEmployeesList(SqlDataReader reader)
        {
            var list = new List<EmployeeDto>();
            while (reader.Read())
            {
                list.Add(TranslateAsUser(reader, true));
            }
            return list;
        }

        public EmployeeDto TranslateAsEmployee(SqlDataReader reader)
        {
            var employee = new EmployeeDto();

            if (reader.Read())
            {
                return TranslateAsUser(reader, true);
            }
            else
            {
                return null;
            }
        }
    }
}
