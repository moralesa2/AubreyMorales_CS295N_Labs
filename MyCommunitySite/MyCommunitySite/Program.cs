using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyCommunitySite.Models;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var conStrBuilder = new MySqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("MessageContext"));
conStrBuilder.Password = builder.Configuration["DbPassword"];
var connection = conStrBuilder.ConnectionString;

builder.Services.AddDbContext<MessageContext>(options =>
{
    var serverVersion = ServerVersion.AutoDetect(connection); 
    options.UseMySql(connection, serverVersion);
});

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
