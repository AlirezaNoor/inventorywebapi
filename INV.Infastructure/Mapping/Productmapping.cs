using INV.Domin.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INV.Infastructure.Mapping
{
    public  class Productmapping:IEntityTypeConfiguration<product>
    {
        public void Configure(EntityTypeBuilder<product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Supplier).WithMany(x => x.Products).HasForeignKey(x => x.supplierid);
            builder.HasOne(x => x.Country).WithMany(x => x.Products).HasForeignKey(x => x.countryid);
        }
    }
}
