using Microsoft.Data.SqlClient;

namespace AddressBook.DBConnection
{
    public interface IDBConnection
    {
        SqlConnection GetSqlConnection();
    }
}
