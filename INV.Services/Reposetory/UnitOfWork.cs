using INV.Domin;
using INV.Domin.Counteries;
using INV.Domin.FisicalYear;
using INV.Domin.Products;
using INV.Domin.Supplier;
using INV.Infastructure;
using INV.Services.Intertface;

namespace INV.Services.Reposetory
{
    public class UnitOfWork : IDisposable, IUnitOfWork 
    {
        private readonly ApplicationDbcointext _context;

        public UnitOfWork(ApplicationDbcointext context)
        {
            _context = context;
        }

        private genricReposetory<ApplicationUser> _applicationuser;
        private genricReposetory<ApplicationRole> _applicationRole;
        private genricReposetory<Country> _coiuntrie;
        private genricReposetory<SupplierAgg> _supplier;
        private genricReposetory<product> _product;
         private  genricReposetory<FisicalYear> _fisicalYear;

        public genricReposetory<ApplicationUser> applicationuserUw
        {
            get
            {
                if (_applicationuser == null)
                {
                    _applicationuser = new genricReposetory<ApplicationUser>(_context);
                }
                return _applicationuser;
            }
        }


        public genricReposetory<ApplicationRole> applicationRoleUw
        {
            get
            {
                if (_applicationRole == null)
                {
                    _applicationRole = new genricReposetory<ApplicationRole>(_context);
                }
                return _applicationRole;
            }
        }
        public genricReposetory<Country> countryUW
        {
            get
            {
                if (_coiuntrie == null)
                {
                    _coiuntrie = new genricReposetory<Country>(_context);
                }
                return _coiuntrie;
            }
        }

        public genricReposetory<SupplierAgg> supplierAggUw
        {
            get
            {
                if (_supplier == null)
                {
                    _supplier = new genricReposetory<SupplierAgg>(_context);
                }
                return _supplier;
            }
        }

        public genricReposetory<product> productUw
        {
            get
            {
                if (_product == null)
                {
                    _product = new genricReposetory<product>(_context);

                }
                return _product;
            }
        }

        public ITransaction transaction()
        {
            return new Transaction(_context);
        }



        public genricReposetory<FisicalYear> fisiscalyearuw
        {
            get
            {
                if (_fisicalYear==null)
                {
                    _fisicalYear = new genricReposetory<FisicalYear>(_context);
                }

                return _fisicalYear;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public void SaveAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
