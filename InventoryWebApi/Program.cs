using Framwork;
using Framwork.Interface;
using INV.Domin;
using INV.Infastructure;
using INV.Services.Intertface;
using INV.Services.Intertface.CostumReposetpory;
using INV.Services.Reposetory;
using INV.Services.Reposetory.CostumReposetpory;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var conectionstringAdress = builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(FileNames.Applicationstting).Build();
//Dbcontext
builder.Services.AddControllers();
//Identity
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.getconection(conectionstringAdress);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
    {
        opt.Password.RequireDigit = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequireUppercase = false;
    }).AddRoles<ApplicationRole>()
    .AddRoleValidator<RoleValidator<ApplicationRole>>()
    .AddRoleManager<RoleManager<ApplicationRole>>()
    .AddEntityFrameworkStores<ApplicationDbcointext>()
    .AddSignInManager<SignInManager<ApplicationUser>>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJWTTokenGenrator, JWTTokenGenrator>();
builder.Services.AddScoped<IFisicalReposetory, FisicalReposetory>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IInventoryreposetory, Inventoryreposetory>();
var app = builder.Build();

if (app.Environment.IsDevelopment())

{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();