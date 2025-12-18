using ClubHouse.Backend.DTOs;
using ClubHouse.Backend.Models;
using ClubHouse.Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClubHouse.Backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly AppDbContext dbContext;

        public AuthController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, AppDbContext dbContext)
        {
            this.signInManager= signInManager;
            this.userManager= userManager;
            this.dbContext= dbContext;
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
            var existingUser = await userManager.FindByEmailAsync(registerDTO.Email);

            if (existingUser!=null)
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
                PrefferedRadiusKm = registerDTO.PrefferedRadiusKm,
                PrefferedCategories = registerDTO.PrefferedCategories,
                AcceptedTermsAndConditions = registerDTO.AcceptedTermsAndConditions,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow,
                IsBanned = false
            };

            var result = await userManager.CreateAsync(newUser, registerDTO.Password);

            if (result.Succeeded)
            {
                //Create initial profile snapshot
                var snapshot =new ProfileSnapshot
                {
                    AppUserId = newUser.Id,
                    Name = newUser.Name,
                    Surname = newUser.Surname,
                    UserName = newUser.UserName,
                    DateOfBirth = newUser.DateOfBirth,
                    Longitude = newUser.Longitude,
                    Latitude = newUser.Latitude,
                    PrefferedRadiusKm = newUser.PrefferedRadiusKm,
                    PrefferedCategories = newUser.PrefferedCategories,
                    SnapshotTakenAt = DateTime.UtcNow,
                    Reason = "Initial profile snapshot at registration"
                };

                dbContext.ProfileSnapshots.Add(snapshot);
                await dbContext.SaveChangesAsync();


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
