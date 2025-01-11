using Microsoft.AspNetCore.Identity;

namespace MyCommunitySite.Models.DataLayer
{
    public class SeedUsers
    {
        private static RoleManager<IdentityRole> roleManager;
        private static UserManager<AppUser> userManager;

        public static async Task CreateUsers(IServiceProvider provider)
        {
            roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            userManager = provider.GetRequiredService<UserManager<AppUser>>();

            const string MEMBER = "Member";
            const string ADMIN = "Admin";
            await CreateRole(MEMBER);
            await CreateRole(ADMIN);

            const string SECRET_PASSWORD = "?Password1";
            await CreateUser("admin", SECRET_PASSWORD, ADMIN);

            await CreateUser("Naru", SECRET_PASSWORD, MEMBER);
            await CreateUser("Lila Crane", SECRET_PASSWORD, MEMBER);
            await CreateUser("Marion Crane", SECRET_PASSWORD, MEMBER);
            await CreateUser("Aubrey M", SECRET_PASSWORD, ADMIN);
        }

        private static async Task CreateRole(string role)
        {
            if (await roleManager.FindByNameAsync(role) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private static async Task CreateUser(string userName, string password, string role)
        {
            var user = new AppUser
            {
                UserName = userName,
            };

            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded) await userManager.AddToRoleAsync(user, role);
        }
    }
}
