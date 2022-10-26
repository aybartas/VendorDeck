using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using VendorDeck.Entities.Concrete;
using VendorDeck.Entities.Dtos;

namespace VendorDeck.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;

        private readonly SignInManager<AppUser> signInManager;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterUserDto userDto)
        {
            var user = new AppUser
            {
                Email = userDto.Email,
                UserName = userDto.Username,
            };

            var result = await userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                var claim = new Claim("Department", "adsf");
                await userManager.AddClaimAsync(user, claim);
            }
            return result.Succeeded ? Ok() : BadRequest(result.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await signInManager.PasswordSignInAsync(loginDto.UserName,loginDto.Password,true,false);
            
            return result.Succeeded ? Ok() : BadRequest();

        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

    }
}
