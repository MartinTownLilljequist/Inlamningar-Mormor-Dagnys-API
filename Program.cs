using eshop.api;
using eshop.api.Data;
using eshop.api.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
  options.UseSqlite(builder.Configuration.GetConnectionString("DevConnection"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
try
{

  var context = services.GetRequiredService<DataContext>();
  await context.Database.MigrateAsync();
  await Seed.LoadProducts(context);
  await Seed.LoadSuppliers(context);
  await Seed.LoadSupplierProducts(context);
  await Seed.LoadAddressTypes(context);
}
catch (Exception ex)
{
  Console.WriteLine("{0}", ex.Message);
  throw;
}
app.MapControllers();

app.Run();
