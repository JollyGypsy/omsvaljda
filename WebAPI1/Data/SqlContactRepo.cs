using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI1.DTOs;
using WebAPI1.Models;

namespace WebAPI1.Data
{
    public class SqlContactRepo : IPersonRepo
    {
        private readonly PhoneBookContext _ctx;

        public SqlContactRepo(PhoneBookContext ctx)
        {
            _ctx = ctx;
        }

        #region insert 
        public bool AddContact(Contact contact)
        {
            if (contact != null)
            {
                try
                {
                    _ctx.Contacts.Add(contact);
                    _ctx.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                    throw;
                }
            }
            else return false;

        }
        public bool AddGroup(Group group)
        {
            try
            {
                _ctx.Groups.Add(group);
                _ctx.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }
        public bool AddPhone(PhoneDTO phoneDTO)
        {
            try
            {
                Phone phone = new Phone {
                    PhoneValue = phoneDTO.PhoneValue,
                    CallCode= phoneDTO.CallCode,
                    ContactID= phoneDTO.ContactID
                };
                _ctx.Phones.Add(phone);
                _ctx.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }

        }
        public bool AddAddress(AddressDTO addressDTO)
        {
            try
            {
                Address address = new Address {
                    AddressValue= addressDTO.AddressValue,
                    State = addressDTO.State,
                    ZipCode = addressDTO.ZipCode,
                    ContactID = addressDTO.ContactID
                };
                _ctx.Addresses.Add(address);
                _ctx.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }

        }
        public bool AddContactToGroup(int groupID, int contactID)
        {
            try
            {
                GroupToPerson groupToPerson = new GroupToPerson
                {
                    GroupID = groupID,
                    ContactID = contactID
                };
                _ctx.GroupToPersons.Add(groupToPerson);
                _ctx.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        #endregion

        #region read

        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                return _ctx.Contacts.ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public Contact GetContactByID(int id)
        {
            try
            {
                return _ctx.Contacts.Where(c => c.ID == id).FirstOrDefault();

            }
            catch (System.Exception)
            {

                throw;
            }        }
        public List<Address> GetAddressByContactID(int id)
        {
            try
            {
                return _ctx.Addresses.Where(c => c.ContactID == id).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }        }
        public List<Phone> GetPhoneByContactID(int id)
        {
            try
            {
                return _ctx.Phones.Where(c => c.ContactID == id).ToList();

            }
            catch (System.Exception)
            {

                throw;
            }        }
        public List<Group> GetGroups()
        {
            try
            {
                List<Group> groups = _ctx.Groups.ToList();
                return groups;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public Group GetGroupByID(int id)
        {
            try
            {
                Group group = _ctx.Groups.Where(a => a.GroupID == id).FirstOrDefault();

                return group;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public List<Contact> GetContactsFromGroup(int groupID)
        {
            try
            {

                List<GroupToPerson> groupToPeople = _ctx.GroupToPersons.Where(g => g.GroupID == groupID).ToList();
                List<Contact> contacts = new List<Contact>();
                foreach (var groupToPerson in groupToPeople)
                {
                    Contact contact = _ctx.Contacts.Where(c => c.ID == groupToPerson.ContactID).FirstOrDefault();
                    contacts.Add(contact);
                }
                return contacts;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public List<Phone> GetPhoneByValue(string number)
        {
            try
            {
                List<Phone> phones = _ctx.Phones.Where(n => n.PhoneValue.Contains(number)).ToList();
                return phones;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public List<Contact> GetContactsByName(string name)
        {
            try
            {
                List<Contact> contacts = _ctx.Contacts.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();
                return contacts;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        #endregion

        #region update
        public bool UpdatePhone(PhoneDTO phoneDTO)
        {
            try
            {
                Phone foundPhone = _ctx.Phones.Where(a => a.PhoneID == phoneDTO.PhoneID).FirstOrDefault();
                if (foundPhone != null)
                {

                    foundPhone.PhoneID = phoneDTO.PhoneID;
                    foundPhone.PhoneValue = phoneDTO.PhoneValue;
                    foundPhone.CallCode = phoneDTO.CallCode;
                    foundPhone.ContactID = phoneDTO.ContactID;                 
                   
                    _ctx.Phones.Update(foundPhone);
                    _ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }
        public bool UpdateContact(Contact contact)
        {
            if (contact != null)
            {
                Contact oldC = _ctx.Contacts.Where(c => c.ID == contact.ID).FirstOrDefault();
                if (oldC != null)
                {
                    oldC.ID = contact.ID;
                    oldC.Name = contact.Name;
                    oldC.Email = contact.Email;
                    oldC.Notes = contact.Notes;
                    oldC.Dob = contact.Dob;
                    oldC.Gender = contact.Gender;
                    try
                    {
                        _ctx.Contacts.Update(oldC);
                        _ctx.SaveChanges();
                        return true;
                    }
                    catch (System.Exception)
                    {
                        return false;
                        throw;
                    }
                }

                else return false;

            }
            else return false;
        }
        public bool UpdateAddress(AddressDTO addressDTO)
        {
            try
            {
                Address foundAddress = _ctx.Addresses.Where(a => a.AddressID == addressDTO.AddressID).FirstOrDefault();
                if (foundAddress != null)
                {
                    foundAddress.AddressValue=addressDTO.AddressValue;
                    foundAddress.State=addressDTO.State;
                    foundAddress.ZipCode=addressDTO.ZipCode;
                   
                    _ctx.Addresses.Update(foundAddress);
                    _ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }

        }
        public bool UpdateGroup(Group group)
        {
            try
            {
                Group foundGroup = _ctx.Groups.Where(a => a.GroupID == group.GroupID).FirstOrDefault();
                if (foundGroup != null)
                {
                    foundGroup.Name = group.Name;
                    _ctx.Groups.Update(foundGroup);
                    _ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        #endregion

        #region delete
        public bool DeleteContact(int id)
        {
            Contact contact = _ctx.Contacts.FirstOrDefault(c => c.ID == id);

            if (contact != null)
            {
                try
                {
                    _ctx.Contacts.Remove(contact);
                    _ctx.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
            else return false;
        }
        public bool DeleteAddress(int id)
        {
            Address address = _ctx.Addresses.Where(a => a.AddressID == id).FirstOrDefault();
            if (address != null)
            {
                try
                {
                    _ctx.Addresses.Remove(address);
                    _ctx.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                    throw;
                }
            }
            else return false;
        }
        public bool DeleteGroup(int id)
        {
            Group foundGroup = GetGroupByID(id);
            if (foundGroup != null)
            {
                try
                {
                    _ctx.Groups.Remove(foundGroup);
                    _ctx.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                    throw;
                }
            }
            else return false;
        }
        public bool DeletePhone(int id)
        {

            Phone phone = _ctx.Phones.Where(a => a.PhoneID == id).FirstOrDefault();
            if (phone != null)
            {
                try
                {
                    _ctx.Phones.Remove(phone);
                    _ctx.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                    throw;
                }
            }
            else return false;
        }
        public bool DeleteContactFromGroup(GroupToPersonDTO groupPersonDTO)
        {
            try
            {
                GroupToPerson groupToPerson = _ctx.GroupToPersons.Where(a => a.GroupID == groupPersonDTO.GroupID).Where(g => g.ContactID == groupPersonDTO.ContactID).FirstOrDefault();
                if (groupToPerson != null)
                {

                    _ctx.GroupToPersons.Remove(groupToPerson);
                    _ctx.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        #endregion


    }
}
