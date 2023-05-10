using DataAccess;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Repository.Contracts;
using OrderManagement.Services.Contracts;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OMDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"), o =>
    {
        o.MigrationsAssembly(typeof(OMDbContext).Assembly.FullName);
    });
});

// repositories
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

// services
builder.Services.AddTransient<IOrderService, OrderService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
