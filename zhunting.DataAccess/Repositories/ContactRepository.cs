using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ZhuntingDbContext _context;
        public ContactRepository(ZhuntingDbContext context)
        {
            _context = context;
        }

        #region CREATE
        public async Task CreateContact(Contact contact)
        {
            _context.Add(contact);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region READ
        public async Task<List<Contact>> GetContacts()
        {
            return await _context.Contacts.OrderByDescending(e => e.Title).ToListAsync();
        }

        public async Task<Contact> GetContact(string name)
        {
            return await _context.Contacts.SingleAsync(s => s.Name == name);
        }
        public async Task<Contact> GetContact(Guid Id)
        {
            return await _context.Contacts.SingleAsync(s => s.Id == Id);
        }
        #endregion
        #region UPDATE
        public async Task UpdateContact(Contact contact)
        {
            _context.Entry<Contact>(contact).State = EntityState.Modified;
            _context.Update(contact);
            await _context.SaveChangesAsync();
        }
        #endregion
        #region DELETE
        public async Task DeleteContact(Contact contact)
        {
            _context.Remove(contact);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
