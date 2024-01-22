using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GJApples.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppleVarieties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CostPerPound = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppleVarieties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppleVarietyId = table.Column<int>(type: "integer", nullable: false),
                    DatePlanted = table.Column<DateOnly>(type: "date", nullable: false),
                    DateRemoved = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trees_AppleVarieties_AppleVarietyId",
                        column: x => x.AppleVarietyId,
                        principalTable: "AppleVarieties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerUserProfileId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeUserProfileId = table.Column<int>(type: "integer", nullable: true),
                    DateOrdered = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Canceled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_CustomerUserProfileId",
                        column: x => x.CustomerUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_EmployeeUserProfileId",
                        column: x => x.EmployeeUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TreeHarvestReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TreeId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeUserProfileId = table.Column<int>(type: "integer", nullable: false),
                    HarvestDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PoundsHarvested = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeHarvestReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeHarvestReports_Trees_TreeId",
                        column: x => x.TreeId,
                        principalTable: "Trees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreeHarvestReports_UserProfiles_EmployeeUserProfileId",
                        column: x => x.EmployeeUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    AppleVarietyId = table.Column<int>(type: "integer", nullable: false),
                    Pounds = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_AppleVarieties_AppleVarietyId",
                        column: x => x.AppleVarietyId,
                        principalTable: "AppleVarieties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppleVarieties",
                columns: new[] { "Id", "CostPerPound", "ImageUrl", "Type" },
                values: new object[,]
                {
                    { 1, 1.20m, "url_to_honeycrisp_image", "Honeycrisp" },
                    { 2, 0.95m, "url_to_granny_smith_image", "Granny Smith" },
                    { 3, 1.10m, "url_to_fuji_image", "Fuji" },
                    { 4, 0.85m, "url_to_gala_image", "Gala" },
                    { 5, 1.15m, "url_to_pink_lady_image", "Pink Lady" },
                    { 6, 0.90m, "url_to_braeburn_image", "Braeburn" },
                    { 7, 0.80m, "url_to_red_delicious_image", "Red Delicious" },
                    { 8, 0.85m, "url_to_golden_delicious_image", "Golden Delicious" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8b2b3a2d-62f6-4f2b-8b3d-45b6a1f3b5b4", "589a696d-6443-4e27-a5e6-c0f73dfc3aeb", "Harvester", "harvester" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "9f6224a8-8547-4199-963b-0806c68006ff", "Admin", "admin" },
                    { "d4f146bf-70c8-4d02-98ec-0b5f4b9d213f", "01aeb43a-c1c6-487b-b360-8cffdea30a35", "Customer", "customer" },
                    { "f65f1f30-d0b1-4f59-a3c8-eb1f2e6757d3", "aec6329e-cdfb-486a-a378-94016e344c32", "OrderPicker", "orderpicker" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "03d8deac-3687-4274-82c1-e1d32392d2de", 0, "6d72324f-3fdf-4531-9678-56f9f664bfe5", "kyle@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEGZ1II+6L/4Td4sQYT3gwRtpfEEzChT8qltZ83+453UFLHCxAbbZMOjWY/kj2bSzgw==", null, false, "a20d6647-bd28-41ed-a3c0-52791df89c6e", false, "Kyle" },
                    { "3a64b2c1-7780-40f1-a393-8edb30c4b2ab", 0, "2c0e9b72-0c2b-41c3-ae1c-bcaa6d1dfb15", "haley@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJNJe9DoKE893oJ1tm4/gHwsit3K8Pptyis9SL9Ru79w+SEL1QFiqIlgrmODmDoFfA==", null, false, "e8b6db6e-ce09-4fbc-9e88-4f7a17f65261", false, "Haley" },
                    { "83aab5f4-67ba-4da9-940e-fef0ce8597bd", 0, "e7dcbf3b-d1fe-4893-8257-524d19a33bd9", "chris@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBcO4XdbYKFzo3q8XKThEwDq2wod4lHcgoSkSMbX7m4+1VfO0N6z//ItNMT/1LDFlQ==", null, false, "ffcdd47e-ce46-4e5a-87af-09b42fe4a52b", false, "Chris" },
                    { "8c3605d2-c0da-4592-8879-0c71dc3c02c4", 0, "da54327d-bf84-4577-8451-3e42fa770bb1", "josh@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENLHy1KrjKcWtIt4+B6gH6YBR5AF6XxFwEwngVqE7YJVimeoblECKUsnGGp45QsXDA==", null, false, "19ddc7a5-c342-4c80-84eb-da379d8f1495", false, "Josh" },
                    { "bc3a3871-4800-4061-8182-b965c9c109bc", 0, "c82fb5dd-6c75-4f7d-b990-8d82526cce07", "aaron@yahoo.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEK+XHgca2jOapPUzmDky21wVCf7ys+3tPanLqQjtsrN+8cLHqEYJA9fi3cU8bqPQ1A==", null, false, "1bc94f82-c6a4-447d-b78a-45fbd4f3f511", false, "Aaron" },
                    { "c8c02266-41e6-414d-a1fc-14bbefef86a0", 0, "05e7c0da-cb02-4ca1-a581-caccfad110cd", "debbie@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEHfBMIPqQNtlVYddXOrhTkDOAXYe7CNRNofV72wMS8W4xBeJGOpUEyShEex+JeKGqQ==", null, false, "a3f1f837-3445-4e5a-b420-caae346bc065", false, "Debbie" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "44b4f84b-0e55-4ffa-9a70-9e7203cc7366", "admin@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAECGDIcd//XK0Z5D/ed1JnyfeGSUIgM/B77UeMevW4KFO3NHSl5yfwdAKZKz6GoTmSA==", null, false, "5fcf96c6-8770-45f0-ac46-f13d7196fc9f", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f65f1f30-d0b1-4f59-a3c8-eb1f2e6757d3", "03d8deac-3687-4274-82c1-e1d32392d2de" },
                    { "8b2b3a2d-62f6-4f2b-8b3d-45b6a1f3b5b4", "3a64b2c1-7780-40f1-a393-8edb30c4b2ab" },
                    { "f65f1f30-d0b1-4f59-a3c8-eb1f2e6757d3", "83aab5f4-67ba-4da9-940e-fef0ce8597bd" },
                    { "8b2b3a2d-62f6-4f2b-8b3d-45b6a1f3b5b4", "8c3605d2-c0da-4592-8879-0c71dc3c02c4" },
                    { "d4f146bf-70c8-4d02-98ec-0b5f4b9d213f", "bc3a3871-4800-4061-8182-b965c9c109bc" },
                    { "d4f146bf-70c8-4d02-98ec-0b5f4b9d213f", "c8c02266-41e6-414d-a1fc-14bbefef86a0" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" }
                });

            migrationBuilder.InsertData(
                table: "Trees",
                columns: new[] { "Id", "AppleVarietyId", "DatePlanted", "DateRemoved" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2015, 5, 10), null },
                    { 2, 1, new DateOnly(2016, 6, 15), null },
                    { 3, 2, new DateOnly(2017, 7, 20), null },
                    { 4, 2, new DateOnly(2018, 8, 25), new DateOnly(2023, 1, 30) },
                    { 5, 3, new DateOnly(2019, 9, 30), null },
                    { 6, 3, new DateOnly(2020, 10, 5), null },
                    { 7, 4, new DateOnly(2021, 11, 10), null },
                    { 8, 4, new DateOnly(2022, 12, 15), null },
                    { 9, 5, new DateOnly(2016, 3, 20), null },
                    { 10, 5, new DateOnly(2017, 4, 25), null },
                    { 11, 6, new DateOnly(2018, 5, 30), null },
                    { 12, 6, new DateOnly(2019, 6, 5), null },
                    { 13, 7, new DateOnly(2020, 7, 10), null },
                    { 14, 7, new DateOnly(2021, 8, 15), null },
                    { 15, 8, new DateOnly(2022, 9, 20), null },
                    { 16, 8, new DateOnly(2023, 10, 25), null },
                    { 17, 1, new DateOnly(2017, 11, 30), null },
                    { 18, 2, new DateOnly(2018, 12, 5), new DateOnly(2023, 2, 10) },
                    { 19, 3, new DateOnly(2019, 1, 10), null },
                    { 20, 4, new DateOnly(2020, 2, 15), null }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "FirstName", "IdentityUserId", "LastName" },
                values: new object[,]
                {
                    { 1, "101 Main Street", "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator" },
                    { 2, "102 Harvest Lane", "Josh", "8c3605d2-c0da-4592-8879-0c71dc3c02c4", "Harvester" },
                    { 3, "103 Harvest Lane", "Haley", "3a64b2c1-7780-40f1-a393-8edb30c4b2ab", "Harvester" },
                    { 4, "104 Picker Street", "Chris", "83aab5f4-67ba-4da9-940e-fef0ce8597bd", "Picker" },
                    { 5, "105 Picker Street", "Kyle", "03d8deac-3687-4274-82c1-e1d32392d2de", "Picker" },
                    { 6, "106 Customer Road", "Debbie", "c8c02266-41e6-414d-a1fc-14bbefef86a0", "Customer" },
                    { 7, "107 Customer Road", "Aaron", "bc3a3871-4800-4061-8182-b965c9c109bc", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Canceled", "CustomerUserProfileId", "DateCompleted", "DateOrdered", "EmployeeUserProfileId" },
                values: new object[,]
                {
                    { 1, true, 6, null, new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, true, 6, null, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, true, 7, null, new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, true, 6, null, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, true, 7, null, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, false, 7, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, false, 7, new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, false, 7, new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, false, 6, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, false, 7, new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, false, 6, new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, false, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 13, false, 7, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, false, 6, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, false, 7, new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 16, false, 6, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 17, false, 7, new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 18, false, 6, null, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 19, false, 7, null, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 20, false, 6, null, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 21, false, 7, null, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 22, false, 7, null, new DateTime(2023, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 23, false, 7, null, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 24, false, 6, null, new DateTime(2023, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 25, false, 6, null, new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "TreeHarvestReports",
                columns: new[] { "Id", "EmployeeUserProfileId", "HarvestDate", "PoundsHarvested", "TreeId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.5m, 1 },
                    { 2, 3, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 23m, 1 },
                    { 3, 2, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.25m, 2 },
                    { 4, 3, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, 2 },
                    { 5, 2, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.75m, 3 },
                    { 6, 3, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 54m, 3 },
                    { 7, 2, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 57m, 4 },
                    { 8, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 28m, 5 },
                    { 9, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 38m, 5 },
                    { 10, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 28m, 6 },
                    { 11, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 45m, 6 },
                    { 12, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 30m, 7 },
                    { 13, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 49m, 7 },
                    { 14, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 52m, 8 },
                    { 15, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 38m, 8 },
                    { 16, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 56m, 9 },
                    { 17, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 27m, 9 },
                    { 18, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, 10 },
                    { 19, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 16m, 10 },
                    { 20, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 15m, 11 },
                    { 21, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 35m, 11 },
                    { 22, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 26m, 12 },
                    { 23, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 56m, 12 },
                    { 24, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 31m, 13 },
                    { 25, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, 13 },
                    { 26, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 40m, 14 },
                    { 27, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 38m, 14 },
                    { 28, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 46m, 15 },
                    { 29, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 24m, 15 },
                    { 30, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 41m, 16 },
                    { 31, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 46m, 16 },
                    { 32, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 42m, 17 },
                    { 33, 2, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 52m, 17 },
                    { 34, 3, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 55m, 18 },
                    { 35, 2, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 51m, 19 },
                    { 36, 3, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 19m, 19 },
                    { 37, 2, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 26m, 20 },
                    { 38, 3, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, 20 },
                    { 39, 2, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 16m, 1 },
                    { 40, 3, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 43m, 1 },
                    { 41, 2, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 26m, 2 },
                    { 42, 3, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 18m, 2 },
                    { 43, 2, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, 3 },
                    { 44, 3, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 56m, 3 },
                    { 45, 2, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 58m, 4 },
                    { 46, 3, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 31m, 5 },
                    { 47, 2, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 28m, 6 },
                    { 48, 3, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 51m, 7 },
                    { 49, 2, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 41m, 8 },
                    { 50, 3, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 27m, 9 },
                    { 51, 2, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 10 },
                    { 52, 3, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 16m, 11 },
                    { 53, 2, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 41m, 12 },
                    { 54, 3, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 19m, 13 },
                    { 55, 2, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 42m, 14 },
                    { 56, 3, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 37m, 15 },
                    { 57, 2, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 20m, 16 },
                    { 58, 3, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 26m, 17 },
                    { 59, 2, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 23m, 18 },
                    { 60, 3, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 17m, 19 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "AppleVarietyId", "OrderId", "Pounds" },
                values: new object[,]
                {
                    { 1, 1, 1, 1.5m },
                    { 2, 3, 1, 1.0m },
                    { 3, 4, 1, 0.5m },
                    { 4, 6, 1, 2.5m },
                    { 5, 2, 2, 2.0m },
                    { 6, 8, 2, 3.0m },
                    { 7, 4, 2, 0.5m },
                    { 8, 6, 2, 1.0m },
                    { 9, 7, 3, 4.0m },
                    { 10, 4, 3, 1.5m },
                    { 11, 2, 3, 0.5m },
                    { 12, 1, 3, 1.5m },
                    { 13, 3, 4, 4.5m },
                    { 14, 8, 4, 3.0m },
                    { 15, 5, 4, 1.0m },
                    { 16, 1, 4, 4.5m },
                    { 17, 2, 4, 4.5m },
                    { 18, 7, 4, 3.0m },
                    { 19, 6, 5, 3.5m },
                    { 20, 7, 5, 1.5m },
                    { 21, 1, 5, 4.0m },
                    { 22, 4, 5, 2.5m },
                    { 23, 1, 6, 1.0m },
                    { 24, 8, 6, 4.0m },
                    { 25, 2, 6, 4.5m },
                    { 26, 3, 7, 0.5m },
                    { 27, 4, 7, 1.0m },
                    { 28, 8, 8, 0.5m },
                    { 29, 3, 8, 3.0m },
                    { 30, 2, 8, 2.5m },
                    { 31, 4, 8, 4.0m },
                    { 32, 1, 8, 4.5m },
                    { 33, 6, 8, 1.0m },
                    { 34, 5, 8, 2.0m },
                    { 35, 7, 8, 0.5m },
                    { 36, 3, 9, 0.5m },
                    { 37, 8, 9, 0.5m },
                    { 38, 5, 9, 2.5m },
                    { 39, 7, 9, 0.5m },
                    { 40, 6, 9, 3.5m },
                    { 41, 5, 10, 3.0m },
                    { 42, 3, 10, 4.0m },
                    { 43, 1, 10, 4.0m },
                    { 44, 7, 10, 4.0m },
                    { 45, 4, 10, 4.5m },
                    { 46, 6, 10, 4.5m },
                    { 47, 8, 10, 2.0m },
                    { 48, 1, 11, 2.0m },
                    { 49, 8, 11, 2.5m },
                    { 50, 6, 11, 0.5m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_AppleVarietyId",
                table: "OrderItems",
                column: "AppleVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerUserProfileId",
                table: "Orders",
                column: "CustomerUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeUserProfileId",
                table: "Orders",
                column: "EmployeeUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeHarvestReports_EmployeeUserProfileId",
                table: "TreeHarvestReports",
                column: "EmployeeUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_TreeHarvestReports_TreeId",
                table: "TreeHarvestReports",
                column: "TreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_AppleVarietyId",
                table: "Trees",
                column: "AppleVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "TreeHarvestReports");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AppleVarieties");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
