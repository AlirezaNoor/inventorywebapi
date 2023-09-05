using System.Collections.Immutable;
using INV.Domin.StoreLocations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INV.Infastructure.Mapping
{
    public class StoreLocationMapping:IEntityTypeConfiguration<Storelocation>
    {
        public void Configure(EntityTypeBuilder<Storelocation> builder)
        {
            builder.ToTable("StoreLocation");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Store).WithMany().HasForeignKey(x => x.StorId);
        }
    }
}
