using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI1.Data;
using WebAPI1.DTOs;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    [Route("api/numbers")]
    public class NumbersController : Controller
    {
        private readonly IPersonRepo _repository;
        public NumbersController(IPersonRepo repository)
        {
            _repository = repository;
        }

        [HttpGet, Route("search")]
        public IEnumerable<Phone> GetNumberByValue(string number)
        {
            var numbers = _repository.GetPhoneByValue(number);
            return numbers;
        }

        [HttpPost, Route("add")]
        public bool AddPhone(PhoneDTO phoneDTO)
        {
            return _repository.AddPhone(phoneDTO);
        }

        [HttpPatch, Route("update")]
        public bool UpdateNumber(PhoneDTO phoneDTO)
        {
            return _repository.UpdatePhone(phoneDTO);
        }


        [HttpDelete, Route("delete")]
        public bool DeletePhone(int id)
        {
            return _repository.DeletePhone(id);
        }
    }

}
