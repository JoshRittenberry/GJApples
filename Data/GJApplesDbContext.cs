using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GJApples.Models;
using Microsoft.AspNetCore.Identity;

namespace GJApples.Data;

public class GJApplesDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<AppleVariety> AppleVarieties { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Tree> Trees { get; set; }
    public DbSet<TreeHarvestReport> TreeHarvestReports { get; set; }

    public GJApplesDbContext(DbContextOptions<GJApplesDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole[]
        {
            new IdentityRole
            {
                Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                Name = "Admin",
                NormalizedName = "admin"
            },
            new IdentityRole
            {
                Id = "8b2b3a2d-62f6-4f2b-8b3d-45b6a1f3b5b4",
                Name = "Harvester",
                NormalizedName = "harvester"
            },
            new IdentityRole
            {
                Id = "f65f1f30-d0b1-4f59-a3c8-eb1f2e6757d3",
                Name = "OrderPicker",
                NormalizedName = "orderpicker"
            },
            new IdentityRole
            {
                Id = "d4f146bf-70c8-4d02-98ec-0b5f4b9d213f",
                Name = "Customer",
                NormalizedName = "customer"
            }
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admin@gjapples.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        });

        // dotnet ef migrations add InitialCreate
        // dotnet ef database update

        // Seed Database

    }
}