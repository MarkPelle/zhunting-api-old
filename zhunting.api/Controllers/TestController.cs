using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhunting.Data.Models;
using zhunting.DataAccess;
using zhunting.DataAccess.Repositories;

namespace zhunting.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public TestController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpGet("{id}")]
        public async Task<List<string>> Get(Guid id)
        {
            return await _imageRepository.GetImageLinksFromGallery(id);
        }
    }
}
