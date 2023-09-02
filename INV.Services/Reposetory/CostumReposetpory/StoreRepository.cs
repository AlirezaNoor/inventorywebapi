using INV.Applicationcontract.Store;
using INV.Domin.Stores;
using INV.Infastructure;
using INV.Services.Intertface.CostumReposetpory;

namespace INV.Services.Reposetory.CostumReposetpory
{
    public class StoreRepository : IStoreRepository
    {

        private readonly ApplicationDbcointext _context;

        public StoreRepository(ApplicationDbcointext context)
        {
            _context = context;
        }

        public Store Editedt(EditedStore e)
        {
            var myentity = _context.store.Where(x => x.Id == e.Id).FirstOrDefault();
            if (myentity != null)
            {
                myentity.Telephone = e.Telephone;
                myentity.address = e.address;
                myentity.storename = e.storename;
                _context.Attach(myentity);
                _context.Entry(myentity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return myentity;
            }

            return null;
        }
    }
}
