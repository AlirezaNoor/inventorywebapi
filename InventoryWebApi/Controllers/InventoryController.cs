using INV.Applicationcontract.Inventory;
using INV.Domin.Inventories;
using INV.Services.Intertface;
using INV.Services.Intertface.CostumReposetpory;
using Microsoft.AspNetCore.Http;
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

    }
}
