using System.Data.SqlClient;
using iConduct.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace iConduct.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<EmployeeEntity> GetEmployeeByIdAsync(int id)
        {
            var employee = await GetEmployeeAsync(id);
            return employee;
        }

        private async Task<EmployeeEntity?> GetEmployeeAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT ID, Name, ManagerID, Enable FROM Employee WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new EmployeeEntity
                            {
                                ID = (int)reader["ID"],
                                Name = (string)reader["Name"],
                                ManagerID = reader["ManagerID"] == DBNull.Value ? null : (int)reader["ManagerID"],
                                Enable = (bool)reader["Enable"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public async Task<bool> UpdateEmployeeEnableAsync(int id, bool enable)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("UPDATE Employee SET Enable = @Enable WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@Enable", enable);
                    command.Parameters.AddWithValue("@ID", id);
                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }
    }
}
