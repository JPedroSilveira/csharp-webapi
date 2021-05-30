using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using csharp_webapi.Entities;
using csharp_webapi.Models;

namespace csharp_webapi.Controllers
{
    public interface IContactController
    {
        /// <summary>
        /// Find all contacts
        /// </summary>
        /// <returns>
        /// Http response ok with all contacts
        /// </returns>
        ActionResult<IEnumerable<Contact>> GetAll();

        /// <summary>
        /// Find all contacts
        /// </summary>
        /// <returns>
        /// if found return Http response ok with the contact, 
        /// else returns Http response not found
        /// </returns>
        ActionResult<Contact> GetById(int id);

        /// <summary>
        /// Save a new contact
        /// </summary>
        /// <returns>
        /// if valid model returns the new id,
        /// else returns Http response bad request 
        /// </returns>
        ActionResult<int> Save(ContactModel model);
    }
}
