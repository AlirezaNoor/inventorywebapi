using INV.Applicationcontract.StoreLocation;
using INV.Domin.StoreLocations;
using INV.Services.Intertface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StroeLocationController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public StroeLocationController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("productlocation")]

        public IActionResult productlocation(long storeid)
        {
            var loc = _context.storelocationUW.Getbyid(storeid);
            if (loc == null)
            {
                return BadRequest();
            }

            return Ok(loc);
        }

        [HttpPost]
        [Route("createlocation")]
        public IActionResult cratelocation(StoreLocationViewmodel e)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var checklocation = _context.storelocationUW.get(x => x.StorId == e.StorId && x.Location == e.Location);
            if (checklocation.Count()>0)
            {
                return BadRequest();
            }

            Storelocation s = new()
            {
                Location = e.Location,
                ProductId = e.ProductId,
                StorId = e.StorId,
                UserId = e.UserId,
                createiontime = DateTime.Now,
            };
            _context.storelocationUW.insert(s);
            _context.save();

            return Ok(s);

        }
    }
}
