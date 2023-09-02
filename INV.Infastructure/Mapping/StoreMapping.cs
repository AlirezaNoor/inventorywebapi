using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INV.Domin.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INV.Infastructure.Mapping
{
    public class StoreMapping:IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Store");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.user).WithMany().HasForeignKey(x => x.userid);
        }
    }
}
