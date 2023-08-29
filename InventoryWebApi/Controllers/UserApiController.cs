using AutoMapper;
using INV.Applicationcontract.Applicationuser;
using INV.Domin;
using INV.Services.Intertface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly IMapper _mapper;

        public UserApiController(IUnitOfWork context, UserManager<ApplicationUser> user, IMapper mapper)
        {
            _context = context;
            _user = user;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Users")]
        public IEnumerable<ApplicationUser> Getall()
        {
            return _context.applicationuserUw.get();
        }

        [HttpGet]
        [Route("User")]
        public IActionResult Get(string id)
        {
            if (id == null)
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
        public async Task<IActionResult> create(Createuser u)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _context.applicationuserUw.get(x =>
                x.FirstName == u.FirstName || x.Email == u.Email || x.UserName == u.UserName);

            if (result.Count() > 0)
            {
                return BadRequest("Doublicated user");
            }

            try
            {
                ApplicationUser user = new()
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
                };
                var re = await _user.CreateAsync(user, "123456789");
                if (re.Succeeded)
                {
                    if (u.UserType == 1)
                    {
                        await _user.AddToRoleAsync(user, "admin");

                    }

                    if (u.UserType == 2)
                    {
                        await _user.AddToRoleAsync(user, "user");

                    }

                }
                _context.SaveAsync();
                return Ok(user);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut]
        [Route("updateusers")]
        public async Task<IActionResult> update(EditedUSer u)
        {
            if (u.Id == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var user = await _user.FindByIdAsync(u.Id);
                if (user == null)
                {
                    return BadRequest();
                }

                var userformap = _mapper.Map(u, user);
                var test = await _user.UpdateAsync(userformap);
                if (!test.Succeeded)
                {
                    return BadRequest();
                }

                return Ok(u);
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }
    }
}
