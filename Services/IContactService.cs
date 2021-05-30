using System.Collections.Generic;
using csharp_webapi.Entities;

namespace csharp_webapi.Services
{
    public interface IContactService 
    {
        /// <summary>
        /// Find all contacts
        /// </summary>
        /// <returns>
        /// IEnumerable with all contacts
        /// </returns>
        IEnumerable<Contact> FindAll();

        /// <summary>
        /// Find one contact by id
        /// </summary>
        /// <returns>
        /// if exists returns Contact, else returns Null
        /// </returns>
        Contact? FindById(int id);

        /// <summary>
        /// Save a new contact
        /// </summary>
        /// <returns>
        /// Returns the entity id
        /// </returns>
        int Save(Contact contact);
    }
}