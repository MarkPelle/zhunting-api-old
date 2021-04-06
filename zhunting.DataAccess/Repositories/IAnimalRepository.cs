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

        #endregion
        #region READ
        /// <summary>
        /// Returns all animals from the database
        /// </summary>
        /// <returns></returns>
        public Task<List<Animal>> GetAnimals();

        // TODO: Merge 2 methods into one well parametered.
        public Task<List<Animal>> GetAnimalsByZone(Zone zone);
        public Task<List<Animal>> GetAnimalsByZoneAbroad();

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
        #endregion
    }
}
