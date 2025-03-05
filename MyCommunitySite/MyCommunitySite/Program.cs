using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCommunitySite.Models;
using MyCommunitySite.Models.DataLayer;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// build connection string
var connection = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connection, ServerVersion.AutoDetect(connection));
});

// Add other services to the container.
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// authenticate before authorization
app.UseAuthentication();
app.UseAuthorization();

// temporary scope for retrieving userManager and seeding data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await SeedData.Seed(dbContext, scope.ServiceProvider);
    await SeedUsers.CreateAdminUserAsync(scope.ServiceProvider);
}
app.Run();
