using INV.Domin.FisicalYear;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INV.Infastructure.Mapping
{
    public  class FisicalyearMapping:IEntityTypeConfiguration<FisicalYear>
    {
        public void Configure(EntityTypeBuilder<FisicalYear> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("FisicalYear");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.user).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
