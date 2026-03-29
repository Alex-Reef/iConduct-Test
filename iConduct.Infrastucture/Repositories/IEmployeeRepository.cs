using iConduct.Domain.Entities;

namespace iConduct.Infrastructure.Repositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Retrieves an employee by ID with their complete subordinate tree.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <returns>The employee entity with subordinates, or null if not found.</returns>
        Task<EmployeeEntity> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Updates the Enable flag for an employee.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <param name="enable">The new Enable flag value.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateEmployeeEnableAsync(int id, bool enable);
    }
}
