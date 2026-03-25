using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wondwear.Domain.Entities;
using Wondwear.Infrastructure.Database;
using Wondwear.Infrastructure.Repository.Users;
using Wondwear.Infrastructure.Services.JWT;
using Wondwear.Infrastructure.Services.Push;

namespace Wondwear.Infrastructure;

public static class Dependencies
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(typeof(IUserRepository<>), typeof(UserRepository<>));
        services.AddTransient<IPushService, PushService>();
        services.AddTransient<IJwtProvider, JwtProvider>();
        services.AddTransient<TokenServices>();

        var firebaseJson = Environment.GetEnvironmentVariable("FIREBASE_CREDENTIALS");

        if (string.IsNullOrWhiteSpace(firebaseJson))
        {
            throw new Exception("FIREBASE_CREDENTIALS is missing.");
        }

        try
        {
            _ = FirebaseApp.DefaultInstance;
        }
        catch
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromJson(firebaseJson)
            });
        }

        services.AddDbContext<AppDbContext>(o =>
        {
            o.UseLazyLoadingProxies();
            o.UseSqlServer(configuration.GetConnectionString("Default"));
        })
        .AddIdentity<User, IdentityRole<int>>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.User.AllowedUserNameCharacters =
                "1234567890abcedfghijklmnopqrstuvwxzyABCDEFGHIJKLMNOBQRSTUVWXZYabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -أاإآلىئبتثجحخعغرزقفصضسشدذرزؤطظهكمنوية";
        })
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

        services.Configure<DataProtectionTokenProviderOptions>(op =>
            op.TokenLifespan = TimeSpan.FromHours(6));

        return services;
    }
}