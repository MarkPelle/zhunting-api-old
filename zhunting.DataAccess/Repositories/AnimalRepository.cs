using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.Models;
using zhunting.DataAccess.Extensions;

namespace zhunting.DataAccess.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly ZhuntingDbContext _context;

        public AnimalRepository(ZhuntingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Animal>> GetAnimals()
        {
            return await _context.Animals.Include(e => e.Image).ToListAsync();
        }
        public async Task<List<Animal>> GetAnimalsByZone(Zone zone)
        {
            return await _context.Animals.Include(e => e.Image).Where(a => a.Zone == zone).OrderBy(e => e.AnimalName).ToListAsync();
        }
        public async Task<List<Animal>> GetAnimalsByZoneAbroad()
        {
            return await _context.Animals.Include(e => e.Image).Where(a => a.Zone != Zone.Hungary).OrderBy(e => e.AnimalName).ToListAsync();
        }
        public async Task<Animal> GetAnimal(string name)
        {
            return await _context.Animals.Include(e => e.Image).SingleAsync(e => e.AnimalName.Replace(" ","") == name);
        }
    }
}
