using INV.Domin;
using INV.Domin.Counteries;
using INV.Domin.FisicalYear;
using INV.Domin.Products;
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


        void save();
         void SaveAsync();



    }
}
