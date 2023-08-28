﻿using INV.Domin;
using INV.Domin.Counteries;
using INV.Domin.Products;
using INV.Domin.Supplier;
using INV.Infastructure.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace INV.Infastructure;

public class ApplicationDbcointext:IdentityDbContext<ApplicationUser,ApplicationRole,string>
{
    public DbSet<SupplierAgg> Supplier { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<product> Products { get; set; }
    public ApplicationDbcointext(DbContextOptions<ApplicationDbcointext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationuserMapping());
        builder.ApplyConfiguration(new ApplicatonRoleMapping());
        builder.ApplyConfiguration(new supplierMapping());
        builder.ApplyConfiguration(new Counterymapping());
        builder.ApplyConfiguration(new Productmapping());
    }
}