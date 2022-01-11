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

        #region Create
        public async Task AddAnimal(Animal animal)
        {
            _context.Add(animal);
            await _context.SaveChangesAsync();
        }
        #endregion
        #region READ


        public async Task<List<Animal>> GetAnimals()
        {
            return await _context.Animals.Include(e => e.Image).ToListAsync();
        }

        public async Task<Animal> GetAnimal(string name)
        {
            return await _context.Animals.Include(e => e.Image).SingleAsync(e => e.AnimalName.Replace(" ", "") == name);
        }

        public async Task<List<Animal>> GetAnimals(Zone zone)
        {
            var animals = _context.Animals.Include(e => e.Image);
            if (zone == Zone.Hungary)
            {
                return await animals.Where(a => a.Zone == Zone.Hungary).ToListAsync();
            }
            else
            {
                return await animals.Where(a => a.Zone != Zone.Hungary).ToListAsync();
            }
        }

        #endregion

        #region DELETE
        public async Task DeleteAnimal(Animal animal)
        {
            _context.Remove(animal);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
