using INV.Domin.productsPrice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INV.Infastructure.Mapping
{
    public class ProductpriceMapping:IEntityTypeConfiguration<ProductPrice>
    {
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            builder.ToTable("productprice");
            builder.HasKey(x => x.ProductPriceid);
            builder.Property(x => x.ProductPriceid).ValueGeneratedOnAdd();
            builder.HasOne(x => x.user).WithMany().HasForeignKey(x => x.userid);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.productid);
            builder.HasOne(x => x.Fisical).WithMany().HasForeignKey(x => x.Fisicalyearid);
        }
    }
}
