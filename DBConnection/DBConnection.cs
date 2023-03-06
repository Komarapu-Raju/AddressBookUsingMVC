using Microsoft.Data.SqlClient;

namespace AddressBook.DBConnection
{
    public class DBConnection : IDBConnection
    {
        private readonly string _connectionString;
        public DBConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServerConnection");
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
