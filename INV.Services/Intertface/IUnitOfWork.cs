using INV.Domin;

using INV.Domin;
using INV.Domin.Counteries;
using INV.Domin.FisicalYear;
using INV.Domin.Inventories;
using INV.Domin.Products;
using INV.Domin.productsPrice;
using INV.Domin.StoreLocations;
using INV.Domin.Stores;
using INV.Domin.Supplier;
using INV.Services.Reposetory;

namespace INV.Services.Intertface
{
    public interface IUnitOfWork
    {
        genricReposetory<ApplicationUser> applicationuserUw { get; }
        genricReposetory<ApplicationRole> applicationRoleUw { get; }
        genricReposetory<Country> countryUW { get; }
        genricReposetory<SupplierAgg> supplierAggUw { get; }
        genricReposetory<product> productUw { get; }
        public genricReposetory<FisicalYear> fisiscalyearuw { get; }
        genricReposetory<Store> storeuw { get; }
        genricReposetory<Inventory> InvenetoryUW { get; }
        genricReposetory<ProductPrice> productpriceuw { get; }
        genricReposetory<Storelocation> storelocationUW { get; }
        void save();
        void SaveAsync();



    }
}
