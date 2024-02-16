using ManagementSystem.Business.Repositories.Interfaces;
using ManagementSystem.Data.Dtos.Employees;
using System.Data.SqlClient;
using System.Data;

namespace ManagementSystem.Business.Repositories
{
    public class EmployeeRepository : Repository<EmployeeDto>, IEmployeeRepository
    {
        public EmployeeRepository(string conString) : base(conString) { }

        public async Task<string?> CreateEmployeeAsync(CreateEmployeeDto employeeDto)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };

            long employeeId = 0;

            SqlParameter[] param = {
                new SqlParameter("@Id", employeeId),
                new SqlParameter("@Name", employeeDto.Name),
                new SqlParameter("@ManagerId", employeeDto.ManagerId),
                new SqlParameter("@Enabled", employeeDto.Enabled),
                new SqlParameter("@CreatedAt", DateTime.Now),
                outParam
            };

            await ExecuteProcedureReturnStringAsync("CreateEmployee", param);

            return outParam?.Value?.ToString();
        }

        public async Task<string?> DeleteEmployeeAsync(long id)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] param = {
                new SqlParameter("@Id", id),
                outParam
            };

            await ExecuteProcedureReturnStringAsync("DeleteEmployee", param);

            return outParam?.Value?.ToString();
        }

        public async Task<EmployeeDto> GetEmployeeAsync(long id, Func<SqlDataReader, EmployeeDto> translator)
        {
            SqlParameter[] param = {
                new SqlParameter("@Id", id)
            };

            return await ExtecuteProcedureReturnDataAsync("GetEmployee", translator, param);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(Func<SqlDataReader, IEnumerable<EmployeeDto>> translator)
        {
            return await ExtecuteProcedureReturnDataAsync("GetEmployees", translator);
        }

        public async Task<string?> EnableEmployeeAsync(EnableEmployeeDto enableDto)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] param = {
                new SqlParameter("@Id", enableDto.Id),
                new SqlParameter("@Enabled", enableDto.Enabled),
                outParam
            };

            await ExecuteProcedureReturnStringAsync("EnableEmployee", param);

            return outParam?.Value?.ToString();
        }

        public async Task<string?> UpdateEmployeeAsync(UpdateEmployeeDto employeeDto)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };

            SqlParameter[] param = {
                new SqlParameter("@Id", employeeDto.Id),
                new SqlParameter("@Name", employeeDto.Name),
                new SqlParameter("@ManagerId", employeeDto.ManagerId),
                new SqlParameter("@Enabled", employeeDto.Enabled),
                outParam
            };

            await ExecuteProcedureReturnStringAsync("UpdateEmployee", param);

            return outParam?.Value?.ToString();
        }
    }
}
