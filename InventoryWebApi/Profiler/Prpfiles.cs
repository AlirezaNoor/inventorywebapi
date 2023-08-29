using AutoMapper;
using INV.Applicationcontract.Applicationuser;
using INV.Domin;

namespace InventoryWebApi.Profiler
{
    public class Prpfiles:Profile
    {
        public Prpfiles()
        {
            CreateMap<ApplicationUser, EditedUSer>().ReverseMap();
        }
    }
}
