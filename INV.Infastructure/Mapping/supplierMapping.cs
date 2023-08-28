using INV.Domin.Supplier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INV.Infastructure.Mapping
{
    public  class supplierMapping:IEntityTypeConfiguration<SupplierAgg>
    {
        public void Configure(EntityTypeBuilder<SupplierAgg> builder)
        {
            builder.ToTable("Supplier");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

        }
    }
}
