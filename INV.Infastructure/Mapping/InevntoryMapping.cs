using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INV.Domin.Inventories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INV.Infastructure.Mapping
{
    public class InevntoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(x => x.InventoryId);
            builder.ToTable("Inventory");
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.product).WithMany().HasForeignKey(x => x.productId);
            builder.HasOne(x => x.store).WithMany().HasForeignKey(x => x.storeId);
            builder.HasOne(x => x.FisicalYear).WithMany().HasForeignKey(x => x.FisicalyearId);

        }
    }
}
