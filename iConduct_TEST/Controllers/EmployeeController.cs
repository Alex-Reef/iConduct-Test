using Microsoft.AspNetCore.Mvc;
using iConduct.Domain.DTOs;
using iConduct.Application.Services;
using iConduct_TEST.Filters;

namespace iConduct_TEST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ValidationFilter))]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);

            if (!result.IsSuccess)
            {
                return NotFound(new { error = result.ErrorMessage });
            }

            return Ok(result.Data);
        }

        [HttpPut("{id}/enable")]
        public async Task<IActionResult> EnableEmployee(int id, [FromBody] UpdateEmployeeRequest request)
        {
            var result = await _employeeService.UpdateEmployeeEnableAsync(id, request);

            if (!result.IsSuccess)
            {
                return NotFound(new { error = result.ErrorMessage });
            }

            return Ok(new { message = result.Data });
        }
    }
}
