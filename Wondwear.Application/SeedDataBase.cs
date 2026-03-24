using Microsoft.AspNetCore.Builder;

namespace Wondwear.Application;

public class SeedDataBase
{
    public static async Task Seed(IApplicationBuilder app)
    {
        var services = app.ApplicationServices.CreateScope().ServiceProvider;
        var context = services.GetService<AppDbContext>()!;
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();
        await SeedRoles(context, roleManager);
    }

    private static async Task SeedRoles(
       AppDbContext context,
       RoleManager<IdentityRole<int>> roleManager
   )
    {
        if (roleManager.Roles.Any())
            return;

        var Roles = Enum.GetValues(typeof(Roles)).Cast<Roles>().Select(a => a.ToString());

        foreach (var Role in Roles)
        {
            await roleManager.CreateAsync(
                new IdentityRole<int> { Name = Role }
            );
        }
        await context.SaveChangesAsync();
    }
}