using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhunting.Data.DTOs;
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
        private readonly IMapper _mapper;

        public ContactController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Contact>> Get(string name)
        {
            return await _contactRepository.GetContact(name);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> Get()
        {
            return await _contactRepository.GetContacts();
        }
        [HttpGet("GetTitles")]
        public List<string> GetTitles()
        {
            return Enum.GetNames(typeof(Title)).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> CreateContact(Contact contact)
        {
            await _contactRepository.CreateContact(contact);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteContact(Contact contact)
        {
            await _contactRepository.DeleteContact(contact);
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateContact(Guid id,JsonPatchDocument<Contact> contact)
        {
            
            var contactToPatch = await _contactRepository.GetContact(id);
            //var ContactDTO = _mapper.Map<ContactDTO>(contactToPatch);
            contact.ApplyTo(contactToPatch);
            //contactToPatch = _mapper.Map<Contact>(ContactDTO);
            await _contactRepository.UpdateContact(contactToPatch);
            return Ok();
        }

    }
}
