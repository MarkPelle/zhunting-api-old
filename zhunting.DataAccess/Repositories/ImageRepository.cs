using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ZhuntingDbContext _context;

        public ImageRepository(ZhuntingDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetImageLinksFromGallery(Guid galleryId)
        {
            return await _context.Images.Include(g => g.Gallery).Where(g => g.GalleryId == galleryId).Select(e => e.Link).ToListAsync();
        }
        public string GetImageById(Guid imageId)
        {
            return  _context.Images.Where(w => w.Id == imageId).Select(s => s.Link).ToString();
        }

        public async Task AddImages(Image image)
        {
            await _context.AddAsync(image);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteImage(Image image)
        {
            _context.Remove(image);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateImage(Image image)
        {
            _context.Update(image);
            await _context.SaveChangesAsync();
        }
    }
}
