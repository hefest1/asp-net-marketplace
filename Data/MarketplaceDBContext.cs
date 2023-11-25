using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class MarketplaceDBContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Categories { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Marketplace;Trusted_Connection=True;");
        optionsBuilder.UseSqlServer("Server=localhost;Database=Marketplace;User Id=sa;Password=QWErt12345;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureModelComment(modelBuilder);
        ConfigureModelOrder(modelBuilder);
        ConfigureModelProduct(modelBuilder);
        ConfigureModelShop(modelBuilder);
        ConfigureModelImage(modelBuilder);
    }

    private void ConfigureModelComment(ModelBuilder builder)
    {
        builder
            .Entity<Comment>()
            .HasOne(c => c.Product)
            .WithMany(c => c.Comments)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.Entity<Comment>().Property(c => c.Text).HasMaxLength(2000);
    }

    private void ConfigureModelOrder(ModelBuilder builder)
    {
        builder
            .Entity<Order>()
            .HasMany(c => c.Products)
            .WithMany();

        builder
            .Entity<Order>().Property(o => o.Status).HasConversion<byte>();
    }

    private void ConfigureModelProduct(ModelBuilder builder)
    {
        builder
            .Entity<Product>()
            .HasOne(p => p.Shop)
            .WithMany(s => s.Products)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();

        builder.Entity<Product>().Property(p => p.Name).HasMaxLength(200);
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(3000);
    }

    private void ConfigureModelShop(ModelBuilder builder)
    {
        builder.Entity<Shop>().Property(s => s.Name).HasMaxLength(100);
        builder.Entity<Shop>().Property(s => s.Description).HasMaxLength(1000);
    }

    private void ConfigureModelImage(ModelBuilder builder)
    {
        builder.Entity<Image>().Property(i => i.Path).HasMaxLength(400);
    }
}