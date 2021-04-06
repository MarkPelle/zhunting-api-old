using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhunting.Data.DTOs;
using zhunting.Data.Models;
using zhunting.DataAccess.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zhunting.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public GalleryController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        [HttpGet("{name}")]
        public async Task<List<string>> Get(string name)
        {
            return await _imageRepository.GetGallery(name);
        }
        [HttpGet]
        public async Task<List<GalleryDTO>> Get()
        {
            return await _imageRepository.GetGalleries();
        }
        [HttpPost]
        public async Task<ActionResult> NewGallery(Gallery gallery)
        {
            await _imageRepository.AddGallery(gallery);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> NewImage(Image image)
        {
            await _imageRepository.AddImage(image);
            return Ok();
        }
    }
}
