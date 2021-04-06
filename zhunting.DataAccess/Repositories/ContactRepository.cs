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
        public async Task<List<Contact>> GetContacts()
        {
            return await _context.Contacts.OrderBy(e => e.Order).ToListAsync();
        }

        public async Task<string> GetPhoneNumber(string name)
        {
            var contact = await _context.Contacts.SingleAsync(s => s.Name == name);
            return contact.PhoneNumber;
        }
        public async Task<Contact> GetContact(string name)
        {
            return await _context.Contacts.SingleAsync(s => s.Name == name);
        }
    }
}
