using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NzWalks.API.Models.DTO;
using NzWalks.API.Repositories;
using System.Runtime.CompilerServices;

namespace NzWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepositery tokenRepositery;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepositery tokenRepositery)
        {
            this.userManager = userManager;
            this.tokenRepositery = tokenRepositery;
        }

        //Post : api/Auth/Register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.Username,
                Email = registerRequestDTO.Username,
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                //Add Roles to this User
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User Registered Successfully");
                    }
                }

            }

            return BadRequest("User Registration Failed");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var identityUser = await userManager.FindByEmailAsync(loginRequestDTO.Username);

            if(identityUser != null)
            {
                var isPasswordValid = await userManager.CheckPasswordAsync(identityUser, loginRequestDTO.Password);
                if (isPasswordValid)
                {
                    //Get Role of this User
                    var roles = await userManager.GetRolesAsync(identityUser);
                    if(roles != null && roles.Any())
                    {
                        //Create Token With the Role
                        var jwtToken = tokenRepositery.CreateJWTToken(identityUser, roles.ToList());
                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response); 
                    }
                }
            }
            return BadRequest("User name or Email not Valid");

        }

    }
}
