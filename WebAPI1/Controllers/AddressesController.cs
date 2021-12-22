using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI1.Data;
using WebAPI1.DTOs;
using WebAPI1.Models;
using Microsoft.Extensions.Configuration;
namespace WebAPI1.Controllers
{
    [Route("api/addresses")]
    public class AddressesController : Controller
    {
        private readonly IPersonRepo _repository;
        public AddressesController(IPersonRepo repository)
        {
            _repository = repository;
        }

        //insert
        [HttpPost, Route("add")]
        public bool AddAddress(AddressDTO addressDTO)
        {
            return _repository.AddAddress(addressDTO);
        }
        [HttpPatch, Route("update")]
        public bool UpdateAddress(AddressDTO addressDTO)
        {
            return _repository.UpdateAddress(addressDTO);
        }

        [HttpDelete, Route("delete")]

        public bool DeleteAddress(int id)
        {
           
            return _repository.DeleteAddress(id);
        }
    }
}

