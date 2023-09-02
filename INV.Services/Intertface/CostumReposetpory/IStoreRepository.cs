using INV.Applicationcontract.Store;
using INV.Domin.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.Services.Intertface.CostumReposetpory
{
    public interface IStoreRepository
    {
        Store Editedt(EditedStore e);
    }
}
