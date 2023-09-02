using System.Text.Json.Serialization;
using INV.Applicationcontract.Store;
using INV.Domin.Stores;
using INV.Services.Intertface;
using INV.Services.Intertface.CostumReposetpory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly IStoreRepository _repository;

        public StoreController(IUnitOfWork context, IStoreRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        [Route("stores")]
        public IEnumerable<Store> GetAll()
        {
            return _context.storeuw.get();
        }

        [HttpGet]
        [Route("store")]
        public IActionResult Getbyid(long id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var store = _context.storeuw.Getbyid(id);
            return store == null ? NotFound() : Ok(store);
        }

        [HttpPost]
        [Route("createstore")]
        public IActionResult Createstore(CreateStore e)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(e);
            }

            var stroe = _context.storeuw.get(x => x.storename == e.storename);

            if (stroe.Count() > 0)
            {
                return BadRequest();
            }

            Store store = new()
            {
                CreationDateTime = e.CreationDateTime,
                userid = e.userid,
                Telephone = e.Telephone,
                address = e.address,
                storename = e.storename
            };
            _context.storeuw.insert(store);
            _context.save();

            return Ok(store);
        }

        [HttpPut]
        [Route("EditStroe")]
        public IActionResult EditedStore(EditedStore e)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(e);
            }

            var store = _context.storeuw.Getbyid(e.Id);
            if (store == null)
            {
                return BadRequest();
            }

            try
            {
                _repository.Editedt(e);
                return Ok(e);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return BadRequest();
            }
        }
    }
}
