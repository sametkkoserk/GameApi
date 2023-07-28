using Api.Models.DTOs;
using Api.Repositories.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        // POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.userName,
                Email = registerRequestDto.email
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.password);

            if (identityResult.Succeeded)
            {
                // Add roles to this User
                IEnumerable<string> roles=new List<string>() {"client"};
                identityResult = await userManager.AddToRolesAsync(identityUser,roles);

                if (identityResult.Succeeded)
                {
                    return Ok("User was registered! Please login.");
                }
                
            }

            return BadRequest("Something went wrong");
        }


        // POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.email);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.password);

                if (checkPasswordResult)
                {
                    // Get Roles for this user
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        // Create Token

                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        return Ok(jwtToken);
                    }
                }
            }

            return BadRequest("Username or password incorrect");
        }
    }
}
