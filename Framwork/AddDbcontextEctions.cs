using INV.Infastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Framwork;

public static class AddDbcontextEctions
{
    public static IServiceCollection getconection(this IServiceCollection Services, IConfiguration config)
    {
        Services.AddDbContext<ApplicationDbcointext>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("InventoryDb"));
        });

        return Services;
    }
}