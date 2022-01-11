using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.DTOs;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories.Interfaces
{
    public interface IGalleryRepository
    {

        #region CREATE
        public Task CreateGallery(Gallery gallery);
        #endregion
        #region READ
        /// <summary>
        /// Returns all galleries from database
        /// </summary>
        /// <returns></returns>
        public Task<List<GalleryDTO>> GetGalleries();

        /// <summary>
        /// Get an individual, filtered gallery
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<GalleryDTO> GetGallery(string name);
        #endregion
        #region DELETE
        public Task DeleteGallery(Gallery gallery);
        #endregion
    }
}
