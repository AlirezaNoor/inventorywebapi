using INV.Applicationcontract.produtcprice;
using INV.Domin.productsPrice;
using INV.Services.Intertface;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productPriceController : ControllerBase
    {
        private readonly IUnitOfWork _cotext;

        public productPriceController(IUnitOfWork cotext)
        {
            _cotext = cotext;
        }
        [HttpGet]
        [Route("produtcPrices")]
        public IEnumerable<ProductPrice> getall()
        {
            return _cotext.productpriceuw.get();
        }
        [HttpGet]
        [Route("produtcprice")]
        public ProductPrice Getbyid(long id)
        {

        }
        [HttpPost]
        [Route("create")]
        public IActionResult Createprice(createproductprice e)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var price = _cotext.productpriceuw.get(x =>
                x.productid == e.productid && x.Fisicalyearid == e.Fisicalyearid &&
                x.actiondate > e.actiondate);
            if (price.Count()>0)
            {

                return StatusCode(504);
            }

            try
            {
                ProductPrice p = new()
                {
                    Fisicalyearid = e.Fisicalyearid,
                    OpertaionDateTime = e.OpertaionDateTime,
                    Purchaseprice = e.Purchaseprice,
                    actiondate = e.actiondate,
                    coverprice = e.coverprice,
                    productid = e.productid,
                    salesprice = e.salesprice,
                    userid = e.userid,
                };
                _cotext.productpriceuw.insert(p);
                _cotext.save();
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
