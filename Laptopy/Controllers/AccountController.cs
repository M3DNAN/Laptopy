using Laptopy.DTOs;
using Laptopy.Models;
using Laptopy.utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Laptopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser>userManager,SignInManager<ApplicationUser> signInManager , RoleManager<IdentityRole>roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(ApplicationUserDTOs userDTOs)
        {
            if (roleManager.Roles.IsNullOrEmpty())
            {
                await roleManager.CreateAsync(new(SD.AdminRole));
                await roleManager.CreateAsync(new(SD.UserRole));
            }
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    UserName = userDTOs.FirstName+" "+ userDTOs.LastName,   
                    Email = userDTOs.Email,
                };
                var Result = await userManager.CreateAsync(user, userDTOs.Password);
                if (Result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, SD.UserRole);
                    await signInManager.SignInAsync(user, false);
                    return Ok();
                }
                return BadRequest(Result.Errors);

            }
            else return BadRequest(userDTOs);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LogInDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);

            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, loginDTO.Password);

                if (result)
                {
                    await signInManager.SignInAsync(user, loginDTO.RememberMe);

                    return Ok();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "There are errors");
                }
            }

            return NotFound();
        }

        [HttpDelete("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }


    }
}
