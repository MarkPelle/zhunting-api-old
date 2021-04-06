using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zhunting.api.Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(IdentityUser user);
    }
}
