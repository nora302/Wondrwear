using Wondwear.Api;
using Wondwear.Application;
using Wondwear.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPresentation();

var app = builder.Build();

app.MapControllers();
app.UseCors("Default");
app.UseSwagger();
app.UseSwaggerUI(o =>
{
    o.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});

app.MapHub<AlertHub>("/hubs/Alert");
app.UseStaticFiles();

app.Run();