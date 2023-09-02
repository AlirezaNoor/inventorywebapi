using System.Text.Json.Serialization;
using INV.Applicationcontract.DrowpdownDTo;
using INV.Applicationcontract.Viewmodels.Fisicalyear;
using INV.Domin.FisicalYear;
using INV.Services.Intertface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FisicqalController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public FisicqalController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Fisicalyears")]
        public IEnumerable<FisicalYear> fisicalyearList()
        {

            return _context.fisiscalyearuw.get();

        }

        [HttpPost]
        [Route("createfisicalyear")]

        public IActionResult CreateFisicalyear([FromForm] CreateFisicalYear e)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(e);
            }

            try
            {
                FisicalYear f = new()
                {
                    Createfiscalyear = DateTime.Now,
                    StartDateTime = e.StartDateTime,
                    EndDateTime = e.EndDateTime,
                    UserId = "",
                    FisicalFlag = false
                };
                _context.fisiscalyearuw.insert(f);
                _context.save();
                return Ok(f);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return BadRequest(exception);

            }
        }


        [HttpGet]
        [Route("ForDrowpdown")]
        public IActionResult DropDown()
        {
            var fis = _context.fisiscalyearuw.get().Select(x => new DToDD()
            {
                Id = x.Id,
                name = x.description
            }).ToList();

            return Ok(fis);
        }
    }

}
