using INV.Applicationcontract.Inventory;
using INV.Infastructure;
using INV.Services.Intertface.CostumReposetpory;

namespace INV.Services.Reposetory.CostumReposetpory
{
    public  class Inventoryreposetory: IInventoryreposetory
    {
        private readonly ApplicationDbcointext _context;

        public Inventoryreposetory(ApplicationDbcointext context)
        {
            _context = context;
        }

        public IEnumerable<InventoryQueryModel> getproductstock(inventoryQuerymaker e)
        {
            var lst = (from p in _context.Products
                select new InventoryQueryModel()
                {
                    productcode =p.code,
                    productid = p.id,
                    productname = p.name,
                    productmaincount = _context.inventory.Where(
                        x=>x.productId==p.id&& x.FisicalyearId==e.fisicalyear &&x.storeId==e.store
                        &&x.prductcountmain>0 &&(x.oprationtype==1|| x.oprationtype == 2 || x.oprationtype == 5 || x.oprationtype == 6 )
                        ).Sum(x=>x.prductcountmain),
                    productwesagecount = _context.inventory.Where(
                        x => x.productId == p.id && x.FisicalyearId == e.fisicalyear && x.storeId == e.store
                             && x.prductcountmain > 0 && (x.oprationtype == 3 || x.oprationtype == 4)
                    ).Sum(x => x.productcountwestage),

                }).ToList();
            return lst;
        }
    }
}
