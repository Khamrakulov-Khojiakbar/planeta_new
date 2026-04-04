using Microsoft.EntityFrameworkCore;
using Planeta.Domain.Auth;
using Planeta.Domain.Entities;

namespace Planeta.Infrastructure.Persistence;

public class PlanetaDbContext : DbContext
{
    public PlanetaDbContext(DbContextOptions<PlanetaDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    
    
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Brand> Brands => Set<Brand>();
    
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    
    public DbSet<PhoneOptions> PhoneOptions => Set<PhoneOptions>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // role and permissioss
        modelBuilder.Entity<Role>()
            .HasMany(r => r.Permissions)
            .WithMany(p => p.Roles)
            .UsingEntity(j => j.ToTable("RolePermission"));

        
        // users
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.UserName).IsRequired().HasMaxLength(50);
        });

        // productlar
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Price).HasPrecision(18, 2);
            entity.Property(p => p.Imei).HasMaxLength(15);
        });
        
        //order zakaz
        
        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.PriceAtPurchase)
            .HasPrecision(18, 2);
        
        
        

    }
    
    
}