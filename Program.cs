using Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();


        //test
        var context = new MarketplaceDBContext();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();


        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}