using iConduct.Domain.DTOs;
using iConduct.Domain.Entities;
using iConduct.Infrastructure.Repositories;
using iConduct.Application.Results;

namespace iConduct.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ServiceResult<EmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return ServiceResult<EmployeeDto>.Failure("Employee ID must be greater than 0.");
                }

                var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    return ServiceResult<EmployeeDto>.Failure($"Employee with ID {id} not found.");
                }

                var dto = MapToDto(employee);
                return ServiceResult<EmployeeDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return ServiceResult<EmployeeDto>.Failure($"An error occurred while retrieving the employee: {ex.Message}");
            }
        }

        public async Task<ServiceResult<string>> UpdateEmployeeEnableAsync(int id, UpdateEmployeeRequest request)
        {
            try
            {
                if (request == null)
                {
                    return ServiceResult<string>.Failure("Update request is required.");
                }

                if (id <= 0)
                {
                    return ServiceResult<string>.Failure("Employee ID must be greater than 0.");
                }

                var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    return ServiceResult<string>.Failure($"Employee with ID {id} not found.");
                }

                var result = await _employeeRepository.UpdateEmployeeEnableAsync(id, request.Enable);
                if (!result)
                {
                    return ServiceResult<string>.Failure($"Failed to update employee {id}.");
                }

                var message = $"Employee {id} Enable flag updated to {request.Enable}";
                return ServiceResult<string>.Success(message);
            }
            catch (Exception ex)
            {
                return ServiceResult<string>.Failure($"An error occurred while updating the employee: {ex.Message}");
            }
        }

        private EmployeeDto MapToDto(EmployeeEntity employee)
        {
            return new EmployeeDto
            {
                ID = employee.ID,
                Name = employee.Name,
                ManagerID = employee.ManagerID,
                Enable = employee.Enable
            };
        }
    }
}
