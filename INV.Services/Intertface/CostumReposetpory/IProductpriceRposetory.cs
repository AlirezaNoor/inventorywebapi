using INV.Applicationcontract.produtcprice;

namespace INV.Services.Intertface.CostumReposetpory
{
    public  interface IProductpriceRposetory
    {
        IEnumerable<ProductPriceViewmodel> getprice(long fisicalyarid);
    }
}
