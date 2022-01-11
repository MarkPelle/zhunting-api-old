using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.DTOs;
using zhunting.Data.Models;
using zhunting.DataAccess.Repositories.Interfaces;

namespace zhunting.DataAccess.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly ZhuntingDbContext _context;
        private readonly IMapper _mapper; 

        public GalleryRepository(ZhuntingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region READ
        public async Task<List<GalleryDTO>> GetGalleries()
        {
            return _mapper.Map<List<GalleryDTO>>(await _context.Galleries.Include(e => e.GalleryImages).Where(e => e.IsDeleted == false).ToListAsync());
        }


        public async Task<GalleryDTO> GetGallery(string name)
        {
            return _mapper.Map<GalleryDTO>(await _context.Galleries.Include(e => e.GalleryImages)
                .Where(e => e.IsDeleted == false)
                .SingleAsync(e => e.Name == name));
        }
        #endregion
        #region CREATE
        public async Task CreateGallery(Gallery gallery)
        {
            _context.Add(gallery);
            await _context.SaveChangesAsync();
        }
        #endregion
        #region delete
        public async Task DeleteGallery(Gallery gallery)
        {
            _context.Remove(gallery);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
