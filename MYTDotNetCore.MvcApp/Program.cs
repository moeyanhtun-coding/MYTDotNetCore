using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MYTDotNetCore.MvcApp;
using MYTDotNetCore.MvcApp.Db;
using MYTDotNetCore.Shared;
using System.Data.SqlClient;
using System.Transactions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    //opt.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
}, ServiceLifetime.Transient, ServiceLifetime.Transient);
builder.Services.AddScoped(n => new AdoDotNetService(builder.Configuration.GetConnectionString("DbConnection")!));
builder.Services.AddScoped(n => new DapperService(builder.Configuration.GetConnectionString("DbConnection")!));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
