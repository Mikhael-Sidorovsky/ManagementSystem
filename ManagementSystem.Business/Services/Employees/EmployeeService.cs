using ManagementSystem.Business.Repositories.Interfaces;
using ManagementSystem.Business.Translators.Employees;
using ManagementSystem.Data.Dtos.Employees;
using System.Data.SqlClient;

namespace ManagementSystem.Business.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeTranslator _employeeTranslator;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeTranslator employeeTranslator) 
        {
            _employeeRepository = employeeRepository;
            _employeeTranslator = employeeTranslator;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto employeeDto)
        {

            var res = await _employeeRepository.CreateEmployeeAsync(employeeDto);

            if(res != "C200")
            {
                throw new Exception("Error while entity creation"); 
            }
        }

        public async Task DeleteEmployeeAsync(long id)
        {
            var res = await _employeeRepository.DeleteEmployeeAsync(id);

            if (res != "C200")
            {
                throw new Exception("Entity does not exists.");
            }
        }

        public async Task<EmployeeDto> GetEmployeeAsync(long id)
        {
            SqlParameter[] param = {
                new SqlParameter("@Id",id)
            };

            return await _employeeRepository.GetEmployeeAsync(id, r => _employeeTranslator.TranslateAsEmployee(r));
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeesAsync(r => _employeeTranslator.TranslateAsEmployeesList(r));
        }

        public async Task<EmployeeDto> EnableEmployeeAsync(EnableEmployeeDto enableDto)
        {
            var res = await _employeeRepository.EnableEmployeeAsync(enableDto);

            return res == "C200" ? await GetEmployeeAsync(enableDto.Id) : throw new Exception("Entity does not exists.");
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(UpdateEmployeeDto employeeDto)
        {
            var res = await _employeeRepository.UpdateEmployeeAsync(employeeDto);

            return res == "C200" ? await GetEmployeeAsync(employeeDto.Id) : throw new Exception("Entity does not exists.");
        }
    }
}
