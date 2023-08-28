using INV.Applicationcontract.Viewmodels.Productsmodels;
using INV.Domin.Products;
using INV.Services.Intertface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public ProductsController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet("produts")]
        public IEnumerable<product> getall()
        {
            return _context.productUw.get(null, "Country,Supplier");

        }
        [HttpGet("product")]

        public IActionResult getbyid(long id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var result = _context.productUw.Getbyid(id);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        [Route("createproduct")]
        public IActionResult Cretaeproduct(Createproducts e)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(e);
            }

            try
            {
                var result = _context.productUw.get(x => x.name == e.name);
                if (result.Count() > 0)
                {
                    return BadRequest("dublicated!");
                }
                product p = new()
                {
                    Isrefregertor = e.Isrefregertor,
                    Unit = e.Unit,
                    countryid = e.countryid,
                    inbox = e.inbox,
                    name = e.name,
                    supplierid = e.supplierid,
                    wight = e.wight,

                };
                _context.productUw.insert(p);
                _context.save();
                return Ok(p);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult Updateoprduts(Editeproducts e)
        {
            if (e.Id == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var result = _context.productUw.get(x => x.name == e.name);
                if (result.Count() > 0)
                {
                    return BadRequest("dublicated!");
                }
                product p = new()
                {
                    Isrefregertor = e.Isrefregertor,
                    Unit = e.Unit,
                    countryid = e.countryid,
                    inbox = e.inbox,
                    name = e.name,
                    supplierid = e.supplierid,
                    wight = e.wight,
 
                };
                _context.productUw.update(p);
                return Ok(e);
            }
            catch (Exception exception)
            {
                Console.Write(exception);
                throw new Exception();
            }
        }
    }
}
