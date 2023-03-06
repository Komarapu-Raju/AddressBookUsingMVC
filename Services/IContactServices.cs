using AddressBook.Models;

namespace AddressBook.Services
{
    public interface IContactServices
    {
        void AddContact(Contact newContact);

        void UpdateContact(Contact updatedContact);

        void DeleteContact(int id);

        Contact GetContactById(int id);

        List<Contact> GetContactsList();
    }
}
