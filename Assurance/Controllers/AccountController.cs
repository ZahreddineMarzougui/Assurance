using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assurance.AuthManager;
using Microsoft.AspNetCore.Authorization;
using Assurance.Models.EF;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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
        public IActionResult Login([Required(ErrorMessage = "The username field is required")]
        [DefaultValue("admin")] string username,
            [Required(ErrorMessage = "The username field is required")]
            [DefaultValue("password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)] string password)
        {
            var token = jwtAuthencationManager.Authenticate(username, password);
            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            //return Unauthorized();
            return Ok(token);

        }
    }
}
