using AddressBook.Models;
using AddressBook.ViewModels;

namespace AddressBook.Services
{
    public interface IContactServices
    {
        void AddContact(Contact newContact);

        void UpdateContact(Contact updatedContact);

        void DeleteContact(int id);

        ContactDetailsViewModel GetContactById(int id);

        List<ContactListViewModel> GetContactsList();

        bool DoesContactExist(int id);
    }
}
