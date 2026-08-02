using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProductApp.Domain.Entities;
using MyProductApp.Infrastructure.Identity;

namespace MyProductApp.Infrastructure.Persistence;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<MatriculaRole> MatriculaRoles { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>(b =>
        {
            b.HasKey(p => p.Id);
            b.Property(p => p.Name).IsRequired().HasMaxLength(200);
            b.Property(p => p.Description).HasMaxLength(2000);
            b.Property(p => p.Price).HasPrecision(18,2);
            b.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
    
}