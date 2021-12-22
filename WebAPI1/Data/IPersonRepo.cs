using WebAPI1.Models;
using System.Collections.Generic;
using WebAPI1.DTOs;

namespace WebAPI1.Data
{
    public interface IPersonRepo 
    {

        #region create
        bool AddContact(Contact contact);
        bool AddGroup(Group group);
        bool AddContactToGroup(int groupID, int contactID);
        bool AddAddress(AddressDTO addressDTO);
        bool AddPhone(PhoneDTO phoneDTO);

        #endregion

        #region read
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactByID(int id);
        List<Address> GetAddressByContactID(int id);
        List<Phone> GetPhoneByContactID(int id);
        List<Group> GetGroups();
        Group GetGroupByID(int id);
        List<Contact> GetContactsFromGroup(int groupID);
        List<Phone> GetPhoneByValue(string number);
        List<Contact> GetContactsByName(string name);
        #endregion

        #region update
        bool UpdateGroup(Group group);
        bool UpdateAddress(AddressDTO addressDTO);
        bool UpdateContact(Contact contact);
        bool UpdatePhone(PhoneDTO phoneDTO);

        #endregion

        #region delete
        bool DeleteGroup(int id);
        bool DeleteContactFromGroup(GroupToPersonDTO groupPersonDTO);
        bool DeleteContact(int id);
        bool DeleteAddress(int id);
        bool DeletePhone(int id);
        #endregion
       
     
    }
}
