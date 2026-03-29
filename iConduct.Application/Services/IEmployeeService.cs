using iConduct.Domain.DTOs;
using iConduct.Application.Results;

namespace iConduct.Application.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResult<EmployeeDto>> GetEmployeeByIdAsync(int id);
        Task<ServiceResult<string>> UpdateEmployeeEnableAsync(int id, UpdateEmployeeRequest request);
    }
}