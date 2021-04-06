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

        /// <summary>
        /// Returns the contact's phone number.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<string> GetPhoneNumber(string name);
        #endregion
        #region UPDATE
        #endregion
        #region DELETE
        #endregion
    }
}
