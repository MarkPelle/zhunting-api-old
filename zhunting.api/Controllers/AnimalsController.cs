using Microsoft.AspNetCore.Authorization;
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
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Animal>>> Get()
        {
            return await _animalRepository.GetAnimals();
        }

        [HttpGet]
        [Route("Zone")]
        public async Task<ActionResult<List<Animal>>> Get(Zone zone)
        {
            return await _animalRepository.GetAnimals(zone);
        }

        [HttpGet]
        [Route("Name")]
        public async Task<ActionResult<Animal>> Get(string name)
        {
            return await _animalRepository.GetAnimal(name);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Animal animal)
        {
            await _animalRepository.AddAnimal(animal);
            return Ok();
        }
    }
}
