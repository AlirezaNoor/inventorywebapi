using INV.Applicationcontract.DrowpdownDTo;
using INV.Applicationcontract.Inventory;
using INV.Domin.Inventories;
using INV.Services.Intertface;
using INV.Services.Intertface.CostumReposetpory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IInventoryreposetory _inventoryreposetory;

        public InventoryController(IUnitOfWork context, IInventoryreposetory inventoryreposetory)
        {
            _context = context;
            _inventoryreposetory = inventoryreposetory;
        }

        [HttpGet]
        [Route("Inventories")]
        public IEnumerable<Inventory> getall()
        {
            return _context.InvenetoryUW.get();
        }

        [HttpGet]
        [Route("Inventoriestock")]
        public IEnumerable<InventoryQueryModel> getstock(inventoryQuerymaker e)
        {
            return _inventoryreposetory.getproductstock(e);
        }

        [HttpPost]
        [Route("addstock")]
        public IActionResult addtostock([FromForm] inventoryStock s)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Inventory inventory = new()
            {
                description = s.description,
                UserId = s.UserId,
                oprationtype = 1,
                prductcountmain = s.prductcountmain,
                productcountwestage = 0,
                FisicalyearId = s.FisicalyearId,
                productId = s.productId,
                storeId = s.storeId,
                Expirtiondate = s.Expirtiondate,
                Tyoprationdatepe = s.Tyoprationdatepe,
            };
            _context.InvenetoryUW.insert(inventory);
            _context.save();
            return Ok();
        }

        public IEnumerable<DToDD> expireddate(long productid, long storeid, long fisiscalyear)
        {
            var inventory = _context.InvenetoryUW.get(x =>
                x.productId == productid && x.storeId == storeid && x.FisicalyearId == fisiscalyear);

           var result= inventory.Select(x => new DToDD()
            {
Id = x.InventoryId,
name = x.Expirtiondate.ToString()
            }).ToList();

           return result;
        }
    }
}