using AddressBook.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.ViewComponents
{
    public class ContactListViewComponent : ViewComponent
    {
        private readonly IContactServices _contactServices;

        public ContactListViewComponent(IContactServices contactServices)
        {
            _contactServices = contactServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewData["contactList"] = _contactServices.GetContactsList();
            return await Task.FromResult((IViewComponentResult)View("ContactList"));
        }
    }
}
