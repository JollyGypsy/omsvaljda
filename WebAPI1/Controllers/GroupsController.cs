using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI1.Data;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    [Route("api/groups")]
    public class GroupsController : Controller
    {

        private readonly IPersonRepo _repository;
        public GroupsController(IPersonRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Group> GetAllGroups()
        {
            var groups = _repository.GetGroups();
            return groups;
        }

        [HttpGet("{id}")]
        public Group GetGroupByID(int id)
        {
            return _repository.GetGroupByID(id);
        }
        //insert
        [HttpPost,Route("add")]
        public bool AddGroup(Group group)
        {
            return _repository.AddGroup(group);
        }

        [HttpPatch,Route("update")]
        public bool UpdateGroup(Group group)
        {
            return _repository.UpdateGroup(group);
        }


        [HttpDelete, Route("delete")]
        public bool DeleteGroup(int id)
        {
            return _repository.DeleteGroup(id);
        }
    }
}
