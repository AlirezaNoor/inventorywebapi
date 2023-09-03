using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INV.Applicationcontract.produtcprice;
using INV.Infastructure;
using INV.Services.Intertface.CostumReposetpory;

namespace INV.Services.Reposetory.CostumReposetpory
{
    public class ProductpriceRposetory: IProductpriceRposetory
    {
        private readonly ApplicationDbcointext _application;

        public ProductpriceRposetory(ApplicationDbcointext application)
        {
            _application = application;
        }

        public virtual IEnumerable<ProductPriceViewmodel> getprice(long fisicalyarid)
        {
            var pricelst = _application.prductprice.AsEnumerable();
            var lst = (from p in _application.Products
                       select new ProductPriceViewmodel()
                       {
                           productname = p.name,
                           productcode = p.code,
                           productid = p.id,
                           fisicalyear = fisicalyarid,
                           Purchaseprice = pricelst.Where(x => x.Fisicalyearid == fisicalyarid &&
                                                               x.productid == p.id
                                   && x.actiondate <= DateTime.Now)
                               .OrderByDescending(x => x.actiondate).Take(1).Select(x => x.Purchaseprice)
                               .DefaultIfEmpty().Single(),
                           ProductPriceid = pricelst.Where(x => x.Fisicalyearid == fisicalyarid &&
                                                                x.productid == p.id
                                                                && x.actiondate <= DateTime.Now)
                               .OrderByDescending(x => x.actiondate).Take(1).Select(x => x.ProductPriceid)
                               .DefaultIfEmpty().Single(),
                           coverprice = pricelst.Where(x => x.Fisicalyearid == fisicalyarid &&
                                                            x.productid == p.id
                                                            && x.actiondate <= DateTime.Now)
                               .OrderByDescending(x => x.actiondate).Take(1).Select(x => x.coverprice)
                               .DefaultIfEmpty().Single(),
                           salesprice = pricelst.Where(x => x.Fisicalyearid == fisicalyarid &&
                                                            x.productid == p.id
                                                            && x.actiondate <= DateTime.Now)
                               .OrderByDescending(x => x.actiondate).Take(1).Select(x => x.salesprice)
                               .DefaultIfEmpty().Single(),
                           userid = pricelst.Where(x => x.Fisicalyearid == fisicalyarid &&
                                                        x.productid == p.id
                                                        && x.actiondate <= DateTime.Now)
                               .OrderByDescending(x => x.actiondate).Take(1).Select(x => x.userid)
                               .DefaultIfEmpty().Single(),
                           actiondate = pricelst.Where(x => x.Fisicalyearid == fisicalyarid &&
                                                            x.productid == p.id
                                                            && x.actiondate <= DateTime.Now)
                               .OrderByDescending(x => x.actiondate).Take(1).Select(x => x.actiondate)
                               .DefaultIfEmpty().Single(),

                       }
                );

            return lst;
        }

    }
}
