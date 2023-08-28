using INV.Domin.Counteries;
using INV.Services.Intertface;
using INV.Services.Reposetory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Countrys : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public Countrys(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("countries")]
        public IEnumerable<INV.Domin.Counteries.Country> GetAll()
        {
            try
            {
                var model = _unitOfWork.countryUW.get();
                return _unitOfWork.countryUW.get();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception();
            }
        }
        [HttpGet]
        [Route("getcountery")]
        public IActionResult Getbyid(long id)
        {
            if (id == null || id == 0)
            {
                return BadRequest(504);
            }
            var country = _unitOfWork.countryUW.Getbyid(id);

            return country == null ? NotFound() : Ok(country);

        }

        [HttpPost]
        [Route("create")]
        public IActionResult Insert(Country entity)
        {

            try
            {
                Country c = new Country();
                var result = _unitOfWork.countryUW.get(x => x.name == entity.name);
                if (result.Count() > 0)
                {
                    return NoContent();
                }
                _unitOfWork.countryUW.insert(entity);
                _unitOfWork.save();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception();
            }

        }
        [HttpPut]
        [Route("countryupdate")]
        public IActionResult update(Country entity)
        {


            try
            {
                var rersult = _unitOfWork.countryUW.get(x => x.name == entity.name);
                if (rersult.Count()>0)
                {
                    return BadRequest("doblicate information");
                }
                _unitOfWork.countryUW.update(entity);
                _unitOfWork.save();
                return Ok(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception();
            }
        }
    }
}

