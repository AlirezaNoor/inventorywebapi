using INV.Domin;

namespace Framwork.Interface
{
    public interface IJWTTokenGenrator
    {
        Task<string> CreateToken(ApplicationUser user);
    }
}
