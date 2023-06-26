using System.Data.SqlClient;
using System.Data;
using webapi.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace webapi.Repository
{
    public class EmployeeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(IConfiguration configuration, ILogger<EmployeeRepository> logger)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _logger = logger;
        }

        public int InsertEmployee(EmployeeModel model)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("InsertEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Name", model.Name);
                        command.Parameters.AddWithValue("@Phone", model.Phone);
                        command.Parameters.AddWithValue("@Email", model.Email);

                        connection.Open();
                        int id = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        return id;

                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to insert employee");
                throw;
            }
        }

        public void test()
        {
            _logger.LogDebug("hello world");
        }


    }
}
