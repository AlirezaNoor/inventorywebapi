using INV.Infastructure;
using INV.Services.Intertface.CostumReposetpory;

namespace INV.Services.Reposetory.CostumReposetpory
{
    public class FisicalReposetory: IFisicalReposetory
    {

        private readonly ApplicationDbcointext _conDbcointext;

        public FisicalReposetory(ApplicationDbcointext conDbcointext)
        {
            _conDbcointext = conDbcointext;
        }

        public bool checkeddate(DateTime startdate, DateTime eDateTime)
        {
            if (startdate>=eDateTime)
            {
                return false;
            }

            if (startdate<=_conDbcointext.FisicalYears.Max(x=>x.EndDateTime))
            {
                return false;
            }

            return true;
        }
    }
}
