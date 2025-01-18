using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCommunitySite.Models;
using MyCommunitySite.Models.DataLayer;
using MySqlConnector;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);

// build connection string
var conStrBuilder = new MySqlConnectionStringBuilder(
    builder.Configuration.GetConnectionString("MySqlConnection"));
conStrBuilder.Password = builder.Configuration["DbPassword"];
var connection = conStrBuilder.ConnectionString;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connection, ServerVersion.AutoDetect(connection));
});

// Add other services to the container.
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddHttpContextAccessor();
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// temporary scope for retrieving userManager and seeding data
using (var scope = app.Services.CreateScope())
{
    //await SeedUsers.CreateUsers(scope.ServiceProvider);
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    SeedData.Seed(dbContext, scope.ServiceProvider);
}

app.Run();
