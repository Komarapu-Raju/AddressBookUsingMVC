using AddressBook.DBConnection;
using AddressBook.Models;
using AddressBook.ViewModels;
using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AddressBook.Services
{
    public class ContactServices : IContactServices
    {
        private readonly SqlConnection _sqlConnection;

        private readonly IMapper mapper;

        public ContactServices(IDBConnection dbAccess,IMapper mapper)
        {
            _sqlConnection = dbAccess.GetSqlConnection();
            this.mapper = mapper;
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

        public ContactDetailsViewModel GetContactById(int id)
        {
            string query = "SELECT * FROM ContactsTable WHERE ID = @ID";
            return mapper.Map<ContactDetailsViewModel>(_sqlConnection.QuerySingleOrDefault<Contact>(query, new { ID = id }));
        }

        public List<ContactListViewModel> GetContactsList()
        {
            var sql = "SELECT * FROM ContactsTable";
            return mapper.Map<List<ContactListViewModel>>(_sqlConnection.Query<Contact>(sql).ToList());
        }

        public bool DoesContactExist(int id)
        {
            return GetContactsList().Any(contact => contact.Id== id);
        }
    }
}
