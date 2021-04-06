using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhunting.Data.Models;
using zhunting.DataAccess.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zhunting.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Contact>> Get(string name)
        {
            return await _contactRepository.GetContact(name);
        }
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> Get()
        {
            return await _contactRepository.GetContacts();
        }
        //[HttpPost("{name}")]
        ////[Route("/Book")]
        //public string Book([FromBody] string name)
        //{
        //    return "jött egy üzike" + name;
        //}
    }
}
