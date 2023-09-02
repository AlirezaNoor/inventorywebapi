using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV.Services.Intertface.CostumReposetpory
{
    public interface IFisicalReposetory
    {
        bool checkeddate(DateTime startdate, DateTime eDateTime);
    }
}
