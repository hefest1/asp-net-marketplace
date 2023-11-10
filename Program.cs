using Data;
using Data.Repositories.EFCore;
using Data.Repositories.Interfaces;
using Services;
using Services.Interfaces;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers()
            .AddNewtonsoftJson();

        builder.Services.AddScoped<MarketplaceDBContext, MarketplaceDBContext>();
        builder.Services.AddScoped<IUserRepository, UsersEFCoreRepository>();
        builder.Services.AddScoped<IUsersService, UsersService>();

        var app = builder.Build();

        //test
        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();

        
        app.MapGet("/", () => "Hello World!");

        app.MapControllers();

        app.Run();
    }
}