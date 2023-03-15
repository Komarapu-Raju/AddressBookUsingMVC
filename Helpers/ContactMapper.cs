using AddressBook.Models;
using AddressBook.ViewModels;
using AutoMapper;

namespace AddressBook.Helpers
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<Contact, ContactDetailsViewModel>();
            CreateMap<Contact, ContactListViewModel>();
        }
    }
}
