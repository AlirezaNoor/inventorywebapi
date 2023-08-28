using INV.Applicationcontract.Viewmodels;
using INV.Domin.Supplier;
using INV.Services.Intertface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public SupplierController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("suppliers")]
        public IEnumerable<SupplierAgg> getAll()
        {
            try
            {
                return _context.supplierAggUw.get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception();

            }
        }
        [HttpGet("supplier")]
        public IActionResult Getbyid(long id)
        {
            if (id==null)
            {
                return BadRequest("NotFound!");
            }

            var model= _context.supplierAggUw.Getbyid(id);
            return model != null ? Ok() : BadRequest();
        }
        [HttpPost]
        [Route("createsupplier")]
        public IActionResult Insertsuppliers([FromForm]CreateSuppliers models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(models);
            }

            try
            {
                var count = _context.supplierAggUw.get(x => x.name == models.name || x.website == models.website);
                if (count.Count()>0)
                {
                    return BadRequest(models);
                }

                SupplierAgg s = new()
                {
                    name = models.name,
                    website = models.website,
                    telephone = models.telephone
                };
                _context.supplierAggUw.insert(s);
                _context.save();
                return Ok(models);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception();
            }
        }
        [HttpPut]
        [Route("Updatesuplier")]
        public IActionResult UpdateSupplier([FromBody]EditSupplier models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(models);
            }

            try
            {
                var result = _context.supplierAggUw.get(x => x.name == models.name || x.telephone == models.telephone);
                if (result.Count()>0)
                {
                    return BadRequest(models);
                }

                SupplierAgg s = new()
                {
                    Id = models.Id,
                    name = models.name,
                    website = models.website,
                    telephone = models.telephone
                };

                _context.supplierAggUw.update(s);
                _context.save();
                return Ok(models);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
