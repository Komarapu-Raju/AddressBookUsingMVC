using AddressBook.Models;
using AddressBook.Services;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactServices _contactServices;

        public ContactController(IContactServices contactServices)
        {
            _contactServices = contactServices;
        }

        public IActionResult ContactForm(int id)
        {
            if (!Convert.ToBoolean(id))
            {
                return View();
            }

            return View(_contactServices.GetContactById(id));
        }

        [HttpPost]
        public IActionResult ContactForm(Contact Contact)
        {
            if (ModelState.IsValid)
            {
                if (!Convert.ToBoolean(Contact.Id))
                {
                    _contactServices.AddContact(Contact);
                    return RedirectToAction("ContactDetails", new { _contactServices.GetContactsList().Last<Contact>().Id });
                }

                _contactServices.UpdateContact(Contact);
                return RedirectToAction("ContactDetails", new { Contact.Id });
            }

            return View();
        }

        public IActionResult ContactDetails(int id)
        {
            return View(_contactServices.GetContactById(id));
        }

        public IActionResult DeleteContact(int id)
        {
            _contactServices.DeleteContact(id);
            return RedirectToAction("Index");
        }

        public IActionResult Index(int id)
        {
            if (Convert.ToBoolean(id))
            {
                return RedirectToAction("ContactDetails", new { id });
            }

            Contact contact = _contactServices.GetContactsList().FirstOrDefault();

            if (contact != null)
            {
                return RedirectToAction("ContactDetails", new { contact.Id });
            }

            return View();
        }

        public IActionResult CloseForm()
        {
            return RedirectToAction("Index");
        }
    }
}
