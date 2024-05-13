using Microsoft.Data.SqlClient;
using System.Data;

namespace PagingWithDapper.Context
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Connection");
        }

        public IDbConnection CreateConnection()

           => new SqlConnection(_connectionString);
    }
}
