

namespace Wondwear.Infrastructure;

public static class Dependencies
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient(typeof(IUserRepository<>), typeof(UserRepository<>));
        services.AddTransient<IPushService, PushService>();
        services.AddTransient<IJwtProvider, JwtProvider>();
        services.AddTransient<TokenServices>();

        string path = Path.Combine(
           Directory.GetCurrentDirectory(),
           "nursing-home-a0e5c-firebase-adminsdk-fbsvc-09dbce4e85.json"
        );
        FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile(path) });

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
            options.User.AllowedUserNameCharacters = "1234567890abcedfghijklmnopqrstuvwxzyABCDEFGHIJKLMNOBQRSTUVWXZYabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -أاإآلىئبتثجحخعغرزقفصضسشدذرزؤطظهكمنوية";
        })
         .AddEntityFrameworkStores<AppDbContext>()
         .AddDefaultTokenProviders();

        services.Configure<DataProtectionTokenProviderOptions>(op =>
          op.TokenLifespan = TimeSpan.FromHours(6));

        return services;
    }
}
