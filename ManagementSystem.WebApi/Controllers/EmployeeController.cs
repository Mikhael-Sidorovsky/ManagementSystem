using ManagementSystem.Business.Services.Employees;
using ManagementSystem.Data.Dtos.Employees;
using Microsoft.AspNetCore.Mvc;

namespace ManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var employees = await _employeeService.GetEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message: {ex.Message}, Time of occurrence {DateTime.UtcNow}, StackTrace: {ex.StackTrace}");
                return BadRequest("Something went wrong.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            return await ProcessFunctionResult((par) => _employeeService.GetEmployeeAsync(par), id);            
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEmployeeDto employeeDto)
        {
            return await ProcessActionResult(_employeeService.CreateEmployeeAsync, employeeDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployeeAsync([FromBody] UpdateEmployeeDto employeeDto)
        {
            return await ProcessFunctionResult(_employeeService.UpdateEmployeeAsync, employeeDto);
        }

        [HttpPut("enable")]
        public async Task<IActionResult> EnableEmployeeAsync([FromBody] EnableEmployeeDto enableDto)
        {
            return await ProcessFunctionResult(_employeeService.EnableEmployeeAsync, enableDto);          
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return await ProcessActionResult((param) => _employeeService.DeleteEmployeeAsync(param), id);
        }

        private async Task<IActionResult> ProcessActionResult<T>(Func<T, Task> action, T parameter)
        {
            try
            {
                await action(parameter);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message: {ex.Message}, Time of occurrence {DateTime.UtcNow}, StackTrace: {ex.StackTrace}");
                return BadRequest(ex.Message);
            }
        }

        private async Task<IActionResult> ProcessFunctionResult<TInput, TOut>(Func<TInput, Task<TOut>> action, TInput parameter)
        {
            try
            {
                var res = await action(parameter);
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message: {ex.Message}, Time of occurrence {DateTime.UtcNow}, StackTrace: {ex.StackTrace}");
                return BadRequest(ex.Message);
            }
        }
    }
}
