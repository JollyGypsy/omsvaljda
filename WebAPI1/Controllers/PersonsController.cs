using WebAPI1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI1.Data;

namespace WebAPI1.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly IPersonRepo _repository;
        public PersonsController(IPersonRepo repository)
        {
            _repository = repository;
        }

        //GET api commands
        [HttpGet]
        public IEnumerable<Contact> GetAllContacts ()
        {
            var userItems = _repository.GetAllContacts();
            return userItems;
        }

        //Post request api/Contacts/{id}
        [HttpPost("{id}")]
        public Contact GetContactById(int id)
        {
            var userItem = _repository.GetContactByID(id);
            return userItem;
        }
        
        [HttpDelete,Route("delete")]

        public bool DeleteContact(int id)
        {
            return _repository.DeleteContact(id);
        }

        [HttpPut("update")]
        public bool UpdateContact([FromBody]Contact contact)
        {
           return _repository.UpdateContact(contact);
        }

        [HttpGet, Route("numbers")]
        public IEnumerable<Phone> GetNumbersByContactID(int id)
        {
            var numbers= _repository.GetPhoneByContactID(id);
            return numbers;
        }

        [HttpGet, Route("addresses")]
        public IEnumerable<Address> GetAddressesByContactID(int id)
        {
            var addresses = _repository.GetAddressByContactID(id);
            return addresses;
        }

       
       
        [HttpPost, Route("add")]
        public bool AddNewContact([FromBody]Contact contact)
        {
            return _repository.AddContact(contact);
        }

        [HttpGet , Route("search")]
        public IEnumerable<Contact> SearchContactByName(string name)
        {
            var contacts = _repository.GetContactsByName(name);
            return contacts;
        }
       
    }
}
