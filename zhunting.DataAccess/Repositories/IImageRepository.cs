using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.DTOs;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public interface IImageRepository
    {
        public Task<List<string>> GetGallery(string name);
        public Task<List<GalleryDTO>> GetGalleries();
        public string GetImage(Guid imageId);
        public Task AddGallery(Gallery gallery);
        public void RemoveGallery(Gallery gallery);
        public void EditGallery(Gallery gallery);
        public Task AddImage(Image image);
        public Task RemoveImage(Image gallery);

    }
}
