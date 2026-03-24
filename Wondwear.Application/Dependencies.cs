

using Wondwear.Domain.Options;

namespace Wondwear.Application;

public static class Dependencies
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginRequest).Assembly));
        services.AddSignalR(hubOptions =>
        {
            hubOptions.ClientTimeoutInterval = TimeSpan.FromSeconds(30); // Default: 30s
            hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(15);      // Default: 15s
            hubOptions.HandshakeTimeout = TimeSpan.FromSeconds(15);
            hubOptions.MaximumReceiveMessageSize = 128 * 1024; // 128KB
        });
        services.AddHttpClient();

        services.AddSingleton<TokenValidationParameters>();
        services.Configure<JwtOptions>(configuration.GetSection("JWT"));
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"] ?? string.Empty)),
                ValidateIssuer = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidateAudience = true,
                ValidAudience = configuration["JWT:Audience"],
                ValidateLifetime = true,
                RequireExpirationTime = true,
                ClockSkew =  TimeSpan.Zero
            };
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["access_token"];
                    var path = context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
                    {
                        context.Token = accessToken;
                    }
                    return Task.CompletedTask;
                }
            }; 
        });


        return services;


    }
}
        