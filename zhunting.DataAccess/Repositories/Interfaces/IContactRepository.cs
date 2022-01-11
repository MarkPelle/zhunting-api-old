using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public interface  IContactRepository
    {
        #region CREATE
        public Task CreateContact(Contact contact);
        
        #endregion
        #region READ
        /// <summary>
        /// Returns all contacts from the database.
        /// </summary>
        /// <returns></returns>
        public Task<List<Contact>> GetContacts();

        /// <summary>
        /// Returns an individual, filtered contact
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<Contact> GetContact(string name);
        public Task<Contact> GetContact(Guid Id);

        #endregion
        #region UPDATE
        public Task UpdateContact(Contact contact);
        #endregion
        #region DELETE
        public Task DeleteContact(Contact contact);
        #endregion
    }
}
