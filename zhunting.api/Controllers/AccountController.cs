using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhunting.api.Services.Interfaces;
using zhunting.Data.DTOs;

namespace zhunting.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task Register(UserRegister userRegister)
        {
            await _userManager.CreateAsync(new IdentityUser(userRegister.UserName),userRegister.Password);
        } 

        [HttpPost]
        public async Task<ActionResult<User>> Login(UserLogin userLogin)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == userLogin.UserName);
            if (user == null) return Unauthorized("Valamit nem jól írtál be papa!");

            var result = await _signInManager.CheckPasswordSignInAsync(user,userLogin.Password,false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            return new User
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
            };
        }
    }
}
