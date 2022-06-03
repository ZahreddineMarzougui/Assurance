using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assurance.AuthManager;
using Microsoft.AspNetCore.Authorization;
using Assurance.Models.EF;

namespace Assurance.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jwtAuthencationManager;

        public AccountController(IJWTAuthenticationManager jwtAuthencationManager)
        {
            this.jwtAuthencationManager = jwtAuthencationManager;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Account Account)
        {
            var token = jwtAuthencationManager.Authenticate(Account.username, Account.password);
            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            //return Unauthorized();
            return Ok(token);

        }
    }
}
