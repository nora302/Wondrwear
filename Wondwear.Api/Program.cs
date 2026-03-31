using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wondwear.Api;
using Wondwear.Application;
using Wondwear.Domain.Entities;
using Wondwear.Infrastructure;
using Wondwear.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPresentation();

var app = builder.Build();

app.UseCors("Default");

app.UseSwagger();
app.UseSwaggerUI(o =>
{
    o.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<AlertHub>("/hubs/Alert");

// Redirection racine vers Swagger
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger/index.html");
    return Task.CompletedTask;
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var dbContext = services.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();

    var userManager = services.GetRequiredService<UserManager<User>>();
    var existingUser = await userManager.FindByNameAsync("admin");

    if (existingUser == null)
    {
        var user = new User
        {
            UserName = "admin",
            Email = "admin@wondwear.local"
        };

        var result = await userManager.CreateAsync(user, "12345678");

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Admin user creation failed: {errors}");
        }
    }
}

app.Run();