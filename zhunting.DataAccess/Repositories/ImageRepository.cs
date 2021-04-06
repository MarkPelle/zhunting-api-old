using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.DTOs;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ZhuntingDbContext _context;
        private readonly IMapper _mapper; 

        public ImageRepository(ZhuntingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<string>> GetGallery(string name)
        {
            return await _context.Images.Include(e => e.Gallery).Where(g => g.Gallery.Name == name).Select(e => e.Link).ToListAsync(); ;
        }
        public async Task<List<GalleryDTO>> GetGalleries()
        {
            return _mapper.Map<List<GalleryDTO>>(await _context.Galleries.Include(e => e.Images).Where(e => e.IsDeleted == false).ToListAsync());
        }
        public string GetImage(Guid imageId)
        {
            return _context.Images.Where(w => w.Id == imageId).Select(s => s.Link).ToString();
        }

        public async Task AddGallery(Gallery gallery)
        {
            await _context.AddAsync(gallery);
            await _context.SaveChangesAsync();
            
        }

        public void RemoveGallery(Gallery gallery)
        {
            throw new NotImplementedException();
        }

        public void EditGallery(Gallery gallery)
        {
            throw new NotImplementedException();
        }

        public async Task AddImage(Image image)
        {
            await _context.AddAsync(image);
            await _context.SaveChangesAsync();
        }

        public Task RemoveImage(Image gallery)
        {
            throw new NotImplementedException();
        }
    }
}
