using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhunting.Data.DTOs;
using zhunting.Data.Models;
using zhunting.DataAccess.Repositories.Interfaces;


namespace zhunting.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryRepository _galleryRepository;

        public GalleryController(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }

        [HttpGet]
        public async Task<List<GalleryDTO>> Get()
        {
            return await _galleryRepository.GetGalleries();
        }

        [HttpGet("{name}")]
        public async Task<GalleryDTO> Get(string name)
        {
            return await _galleryRepository.GetGallery(name);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Gallery gallery)
        {
            await _galleryRepository.CreateGallery(gallery);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Gallery gallery)
        {
            await _galleryRepository.DeleteGallery(gallery);
            return Ok();
        }

    }
}
