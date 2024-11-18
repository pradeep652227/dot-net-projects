using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MvCProj_1.Context
{
    public class DBContext
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            _connectionString = _configuration.GetSection("ConnectionStrings").GetSection("AttendanceLocalDB").Value;
            return new SqlConnection(_connectionString);
        }
    }
}
