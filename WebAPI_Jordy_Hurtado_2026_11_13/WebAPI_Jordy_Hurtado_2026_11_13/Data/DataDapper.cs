using Microsoft.Data.SqlClient;
using System.Data;

namespace WebAPI_Jordy_Hurtado_2026_11_13.Data
{
    public class DataDapper
    {
        private readonly string _connectionString;

        public DataDapper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException
                                                                 ("Connection string 'DefaultConnection' not found.");
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
