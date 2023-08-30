using Framwork.Interface;
using INV.Applicationcontract.Applicationuser;
using INV.Applicationcontract.Viewmodels;
using INV.Domin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJWTTokenGenrator _jwtTokenGenrator;

        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJWTTokenGenrator jwtTokenGenrator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenGenrator = jwtTokenGenrator;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewmodels model)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();

            }

            try
            {

                var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == model.username);

                if (user == null)
                {
                    return Unauthorized("invalid user or password");
                }

                var userpasswor = await _signInManager.CheckPasswordSignInAsync(user, model.password, false);
                if (!userpasswor.Succeeded)
                {
                    return Unauthorized(" useror password is in valid");
                }

                var userrole = await _userManager.GetRolesAsync(user);
                var usertoken = new TokenSenderViewModel()
                {
                    username = user.UserName,
                    Token = await _jwtTokenGenrator.CreateToken(user),
                    Roles = await _userManager.GetRolesAsync(user)
                };
                return Ok(usertoken);

            }
            catch (Exception e)
            {
                return StatusCode(505);
            }

        }
    }
}
