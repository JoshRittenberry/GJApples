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
                    CostPerPound = table.Column<decimal>(type: "numeric", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
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
                    DatePlanted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateRemoved = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
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
                    DateOrdered = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
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
                        principalColumn: "Id");
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
                        principalColumn: "Id");
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
                columns: new[] { "Id", "CostPerPound", "ImageUrl", "IsActive", "Type" },
                values: new object[,]
                {
                    { 1, 1.20m, "url_to_honeycrisp_image", true, "Honeycrisp" },
                    { 2, 0.95m, "url_to_granny_smith_image", true, "Granny Smith" },
                    { 3, 1.10m, "url_to_fuji_image", true, "Fuji" },
                    { 4, 0.85m, "url_to_gala_image", true, "Gala" },
                    { 5, 1.15m, "url_to_pink_lady_image", true, "Pink Lady" },
                    { 6, 0.90m, "url_to_braeburn_image", true, "Braeburn" },
                    { 7, 0.80m, "url_to_red_delicious_image", true, "Red Delicious" },
                    { 8, 0.85m, "url_to_golden_delicious_image", true, "Golden Delicious" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8b2b3a2d-62f6-4f2b-8b3d-45b6a1f3b5b4", "e89659a2-cb07-45b7-b9dc-64ed3cb6e0d6", "Harvester", "harvester" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "68d0ec58-b9d4-479d-b14d-796d62c04f4d", "Admin", "admin" },
                    { "d4f146bf-70c8-4d02-98ec-0b5f4b9d213f", "47290448-b467-4117-aed8-5698379931e4", "Customer", "customer" },
                    { "f65f1f30-d0b1-4f59-a3c8-eb1f2e6757d3", "aa13af35-ef5e-4a92-8a75-1660338d1362", "OrderPicker", "orderpicker" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "03d8deac-3687-4274-82c1-e1d32392d2de", 0, "51768077-11e9-403c-b604-16215a35bee0", "kyle@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEE6VTE6t90kN6fAVXWKGRxMHIbmXZRbwl+VpbGqgL1PwSUmYsgG95F9GBdm00DT5lQ==", null, false, "40fbf890-a0c5-4a1e-8496-7f509a4f6cf8", false, "Kyle" },
                    { "3a64b2c1-7780-40f1-a393-8edb30c4b2ab", 0, "5b179555-a8ba-46da-94c2-e6e857a27f0b", "haley@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBaR6GiaHZ8reDEQ0EFYFLGvjLnUa1LgSD9PRTco4RvrGea/dvwZxTGXwY4k/x3UPw==", null, false, "0237d710-d329-480c-9f49-86ee5530c96b", false, "Haley" },
                    { "83aab5f4-67ba-4da9-940e-fef0ce8597bd", 0, "46cb3169-3d68-4020-9e14-8b708e2e434d", "chris@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEG8lZCwT8YOIDv0hYhtYqNaRpLTUVrsCTpDeQXYFg1246dsEaIU5DeQMDx98U8UEWQ==", null, false, "d63dc9fd-9c45-406a-b805-9d7d18d3e057", false, "Chris" },
                    { "8c3605d2-c0da-4592-8879-0c71dc3c02c4", 0, "577d932f-bd08-47cc-b2bf-d4f79b886cd3", "josh@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOR4D9YwMiZ9/GS6kshKm9BihOm5TnMVymj19h0d63wh6eHE7rE8+D62lWw7S/oD/w==", null, false, "91253897-9bdc-4f65-b55c-bf3424bc2f10", false, "Josh" },
                    { "bc3a3871-4800-4061-8182-b965c9c109bc", 0, "79763919-a3c4-4201-84a5-5fade5e0366e", "aaron@yahoo.com", false, false, null, null, null, "AQAAAAEAACcQAAAAELfZOgYzA+5yVmN5V+WPfpRGQUa/Zm00DGsetoG/3/oy8+rJO6xvymYCdUGzl2mSJg==", null, false, "36169bbc-2da1-4f99-861f-727cadaff9a2", false, "Aaron" },
                    { "c8c02266-41e6-414d-a1fc-14bbefef86a0", 0, "e2cb7433-85dc-42a2-a66f-77a49d5babba", "debbie@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOdd96CVrcpCd6HgBBL7fOTudXGKBsl6RQR9a1xz0bS3OCF4rCS+Tyopru5J7klKQw==", null, false, "bca2a15b-ed9a-421e-8d1e-7defe8cefecc", false, "Debbie" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "9d0b23bf-2603-4d6a-a820-1ba12a0332a5", "admin@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBwxXDznBI/w60hskp/5cr8a1+hOamTAVmG+ccGVT17sXEX8qSKYNV6Cw6afU2khyQ==", null, false, "038b10b1-3a12-4f6b-b2ab-7ec83eab56e4", false, "Administrator" }
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
                    { 1, 1, new DateTime(2015, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 1, new DateTime(2016, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 2, new DateTime(2017, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, 2, new DateTime(2018, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, 3, new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, 4, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, 4, new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, 5, new DateTime(2016, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, 5, new DateTime(2017, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, 6, new DateTime(2018, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, 6, new DateTime(2019, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, 7, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, 7, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, 8, new DateTime(2022, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 16, 8, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 17, 1, new DateTime(2017, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 18, 2, new DateTime(2018, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 3, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 20, 4, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
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
                    { 9, false, 6, null, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, false, 7, null, new DateTime(2023, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, false, 6, null, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
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
