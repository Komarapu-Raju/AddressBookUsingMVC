using AddressBook.DBConnection;
using AddressBook.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AddressBook.Services
{
    public class ContactServices : IContactServices
    {
        private readonly SqlConnection _sqlConnection;

        public ContactServices(IDBConnection dbAccess)
        {
            _sqlConnection = dbAccess.GetSqlConnection();
        }

        public void AddContact(Contact newContact)
        {
            string query = "INSERT INTO ContactsTable (Name, Email, Mobile, Landline, Website, Address) VALUES (@Name, @Email, @Mobile, @Landline, @Website, @Address)";
            _sqlConnection.Execute(query, newContact);
        }

        public void UpdateContact(Contact updatedContact)
        {
            string query = "UPDATE ContactsTable SET Name = @Name, Email = @Email, Mobile = @Mobile, Landline = @Landline, Website = @Website, Address = @Address WHERE ID = @ID";
            _sqlConnection.Execute(query, updatedContact);
        }

        public void DeleteContact(int id)
        {
            string query = "DELETE FROM ContactsTable WHERE ID = @ID";
            _sqlConnection.Execute(query, new { ID = id });
        }

        public Contact GetContactById(int id)
        {
            string query = "SELECT * FROM ContactsTable WHERE ID = @ID";
            return _sqlConnection.QuerySingleOrDefault<Contact>(query, new { ID = id });
        }

        public List<Contact> GetContactsList()
        {
            var sql = "SELECT * FROM ContactsTable";
            return _sqlConnection.Query<Contact>(sql).ToList();
        }

        public bool DoesContactExist(int id)
        {
            return GetContactsList().Any(contact => contact.Id== id);
        }
    }
}
