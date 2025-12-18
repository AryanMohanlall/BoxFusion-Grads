using ClubHouse.Backend.DTOs;
using ClubHouse.Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ClubHouse.Backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.signInManager= signInManager;
            this.userManager= userManager;
        }


        //Register endpoint
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            //Ensure required fields not empty
            if(string.IsNullOrWhiteSpace(registerDTO.Email)
                || string.IsNullOrWhiteSpace(registerDTO.Password)
                || string.IsNullOrWhiteSpace(registerDTO.Name)
                || string.IsNullOrWhiteSpace(registerDTO.Surname))
            {
                return BadRequest("Required field(s) empty");
            }

            //Check if the user already exists
            if (userManager.FindByEmailAsync(registerDTO.Email) != null)
            {
                return Conflict("Email already exists, try resetting password");
            }

            //Create the new user
            AppUser newUser = new AppUser
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                DateOfBirth = registerDTO.DateOfBirth,
                IsMale = registerDTO.IsMale,
                Longitude = registerDTO.Longitude,
                Latitude = registerDTO.Latitude,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow,
                IsBanned = false
            };
            var result = await userManager.CreateAsync(newUser, registerDTO.Password);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    message = "Registration successful",
                    userId = newUser.Id
                });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        
    }
}
