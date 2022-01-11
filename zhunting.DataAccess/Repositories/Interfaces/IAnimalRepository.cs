using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public interface IAnimalRepository
    {
        #region CREATE
        public Task AddAnimal(Animal animal);

        #endregion
        #region READ
        /// <summary>
        /// Returns all animals from the database
        /// </summary>
        /// <returns></returns>
        public Task<List<Animal>> GetAnimals();

        public Task<List<Animal>> GetAnimals(Zone zone);

        /// <summary>
        /// Returns an individual, filtered animal
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<Animal> GetAnimal(string name);

        #endregion
        #region UPDATE
        #endregion
        #region DELETE
        public Task DeleteAnimal(Animal animal);
        #endregion
    }
}
