using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI1.Data;
using WebAPI1.DTOs;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    [Route("api/groupcontacts")]

    public class GroupToPersonsController : Controller
    {
        private readonly IPersonRepo _repository;
        public GroupToPersonsController(IPersonRepo repository)
        {
            _repository = repository;
        }

        [HttpGet, Route("contactsByGroup")]
        public IEnumerable<Contact> GetContactsByGroupID(int id)
        {
            var contacts = _repository.GetContactsFromGroup(id);
            return contacts;
        }

        [HttpDelete, Route("delete")]
        public bool DeleteContactFromGroupID(int groupID, int personID)
        {
            GroupToPersonDTO groupToPersonDTO = new GroupToPersonDTO
            {
                GroupID = groupID,
                ContactID = personID
            };
            return _repository.DeleteContactFromGroup(groupToPersonDTO);
        }

        [HttpPost, Route("add")]
        public bool AddGroupToPerson(int personID, int groupID)
        {
            return _repository.AddContactToGroup(groupID, personID);
        }
    }
}
