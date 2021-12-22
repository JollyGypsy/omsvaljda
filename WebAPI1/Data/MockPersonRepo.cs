using WebAPI1.Models;
using System.Collections.Generic;

namespace WebAPI1.Data
{
    public class MockPersonRepo : IPersonRepo
    {
        public IEnumerable<Contact> GetAllPersons()
        {
            var users = new List<Contact>
            {
                new Contact
                {
                    ID =0,
                    Name = "Mirko",
                    Email = "example@gmail.com",
                    Notes = "",
                    Gender = "M",
                    Dob = ""
                },
                new Contact
                {
                    ID =1,
                    Name = "Sladjana",
                    Email = "example@yahoo.com",
                    Notes = "work",
                    Gender = "F",
                    Dob = "12/12/1984"
                }
            };
            return users;
        }
        //implement searching form ef database
        public Contact GetPersonByID(int id)
        {
            return new Contact
            {
                ID =id,
                Name = "Mirko",
                Email = "example@gmail.com",
                Notes = "",
                Gender = "M",
                Dob = ""
            };
        }
    }
}
