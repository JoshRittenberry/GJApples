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

        // Assuming _configuration["HarvesterPassword"], _configuration["OrderPickerPassword"], and _configuration["CustomerPassword"] are set
        var passwordHasher = new PasswordHasher<IdentityUser>();

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Administrator",
                Email = "admin@gjapples.com",
                PasswordHash = passwordHasher.HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "8c3605d2-c0da-4592-8879-0c71dc3c02c4",
                UserName = "Josh",
                Email = "josh@gjapples.com",
                PasswordHash = passwordHasher.HashPassword(null, _configuration["HarvesterPassword"])
            },
            new IdentityUser
            {
                Id = "3a64b2c1-7780-40f1-a393-8edb30c4b2ab",
                UserName = "Haley",
                Email = "haley@gjapples.com",
                PasswordHash = passwordHasher.HashPassword(null, _configuration["HarvesterPassword"])
            },
            new IdentityUser
            {
                Id = "83aab5f4-67ba-4da9-940e-fef0ce8597bd",
                UserName = "Chris",
                Email = "chris@gjapples.com",
                PasswordHash = passwordHasher.HashPassword(null, _configuration["OrderPickerPassword"])
            },
            new IdentityUser
            {
                Id = "03d8deac-3687-4274-82c1-e1d32392d2de",
                UserName = "Kyle",
                Email = "kyle@gjapples.com",
                PasswordHash = passwordHasher.HashPassword(null, _configuration["OrderPickerPassword"])
            },
            new IdentityUser
            {
                Id = "c8c02266-41e6-414d-a1fc-14bbefef86a0",
                UserName = "Debbie",
                Email = "debbie@gmail.com",
                PasswordHash = passwordHasher.HashPassword(null, _configuration["CustomerPassword"])
            },
            new IdentityUser
            {
                Id = "bc3a3871-4800-4061-8182-b965c9c109bc",
                UserName = "Aaron",
                Email = "aaron@yahoo.com",
                PasswordHash = passwordHasher.HashPassword(null, _configuration["CustomerPassword"])
            }
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "8b2b3a2d-62f6-4f2b-8b3d-45b6a1f3b5b4",
                UserId = "8c3605d2-c0da-4592-8879-0c71dc3c02c4"
            },
            new IdentityUserRole<string>
            {
                RoleId = "8b2b3a2d-62f6-4f2b-8b3d-45b6a1f3b5b4",
                UserId = "3a64b2c1-7780-40f1-a393-8edb30c4b2ab"
            },
            new IdentityUserRole<string>
            {
                RoleId = "f65f1f30-d0b1-4f59-a3c8-eb1f2e6757d3",
                UserId = "83aab5f4-67ba-4da9-940e-fef0ce8597bd"
            },
            new IdentityUserRole<string>
            {
                RoleId = "f65f1f30-d0b1-4f59-a3c8-eb1f2e6757d3",
                UserId = "03d8deac-3687-4274-82c1-e1d32392d2de"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d4f146bf-70c8-4d02-98ec-0b5f4b9d213f",
                UserId = "c8c02266-41e6-414d-a1fc-14bbefef86a0"
            },
            new IdentityUserRole<string>
            {
                RoleId = "d4f146bf-70c8-4d02-98ec-0b5f4b9d213f",
                UserId = "bc3a3871-4800-4061-8182-b965c9c109bc"
            }
        );

        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Admina",
                LastName = "Strator",
                Address = "101 Main Street"
            },
            new UserProfile
            {
                Id = 2,
                IdentityUserId = "8c3605d2-c0da-4592-8879-0c71dc3c02c4",
                FirstName = "Josh",
                LastName = "Harvester",
                Address = "102 Harvest Lane"
            },
            new UserProfile
            {
                Id = 3,
                IdentityUserId = "3a64b2c1-7780-40f1-a393-8edb30c4b2ab",
                FirstName = "Haley",
                LastName = "Harvester",
                Address = "103 Harvest Lane"
            },
            new UserProfile
            {
                Id = 4,
                IdentityUserId = "83aab5f4-67ba-4da9-940e-fef0ce8597bd",
                FirstName = "Chris",
                LastName = "Picker",
                Address = "104 Picker Street"
            },
            new UserProfile
            {
                Id = 5,
                IdentityUserId = "03d8deac-3687-4274-82c1-e1d32392d2de",
                FirstName = "Kyle",
                LastName = "Picker",
                Address = "105 Picker Street"
            },
            new UserProfile
            {
                Id = 6,
                IdentityUserId = "c8c02266-41e6-414d-a1fc-14bbefef86a0",
                FirstName = "Debbie",
                LastName = "Customer",
                Address = "106 Customer Road"
            },
            new UserProfile
            {
                Id = 7,
                IdentityUserId = "bc3a3871-4800-4061-8182-b965c9c109bc",
                FirstName = "Aaron",
                LastName = "Customer",
                Address = "107 Customer Road"
            }
        );


        // dotnet ef migrations add InitialCreate
        // dotnet ef database update

        // Seed Database

    }
}