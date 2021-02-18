using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public interface IImageRepository
    {
        public Task<List<string>> GetImageLinksFromGallery(Guid galleryId);
        public string GetImageById(Guid imageId);
        public Task AddImages(Image image);
        public Task DeleteImage(Image image);
        public Task UpdateImage(Image image);
    }
}
