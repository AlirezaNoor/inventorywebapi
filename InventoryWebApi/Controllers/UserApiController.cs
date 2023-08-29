using INV.Applicationcontract.Applicationuser;
using INV.Domin;
using INV.Services.Intertface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController:ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUser> _user;

        public UserApiController(IUnitOfWork context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        [HttpGet]
        [Route("Users")]
        public IEnumerable<ApplicationUser> Getall()
        {
            return _context.applicationuserUw.get();
        }

        [HttpGet]
        [Route("User")]
        public IActionResult Get(long id)
        {
            if (id==null)
            {
                return NotFound();
            }

            try
            {
                var result = _context.applicationuserUw.Getbyid(id);

                return result == null ? BadRequest() : Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpPost]
        [Route("cretae")]
        public async Task<IActionResult> create([FromForm]Createuser u)
        {
            if (!ModelState.IsValid)
            {
                return  BadRequest();
            }

            var result = _context.applicationuserUw.get(x =>
                x.FirstName == u.FirstName || x.Email == u.Email || x.UserName == u.UserName);

            if (result.Count()>0)
            {
                return BadRequest("Doublicated user");
            }

            try
            {
                ApplicationUser user=new()
                {
                    FirstName = u.FirstName,
                    Lastname = u.Lastname,
                    UserName = u.UserName,
                    Email = u.Email,
                    Birthday = DateTime.Now,
                    Gender = u.Gender,
                    UserType = u.UserType,
                    melicode = u.melicode,
                    personalcode = u.personalcode
                }
                var re=_user.CreateAsync()
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
