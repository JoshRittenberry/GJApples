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
                    ForcePasswordChange = table.Column<bool>(type: "boolean", nullable: false),
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
                    HarvestDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PoundsHarvested = table.Column<decimal>(type: "numeric", nullable: true)
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
                    { 1, 1.20m, "https://i.ibb.co/ZMDrZFH/Honey-Crisp-Apple.jpg", true, "Honeycrisp" },
                    { 2, 0.95m, "https://i.ibb.co/8bq7xWW/Granny-Smith-Apple.jpg", true, "Granny Smith" },
                    { 3, 1.10m, "https://i.ibb.co/WBtxpKf/Fuji-Apple.webp", true, "Fuji" },
                    { 4, 0.85m, "https://i.ibb.co/SNp02bf/Gala-Apple.jpg", true, "Gala" },
                    { 5, 1.15m, "https://i.ibb.co/8XjJ88T/Pink-Lady-Apple.jpg", true, "Pink Lady" },
                    { 6, 0.90m, "https://i.ibb.co/5rW7k1s/Braeburn-Apple.jpg", true, "Braeburn" },
                    { 7, 0.80m, "https://i.ibb.co/C9GyMDj/Red-Delicious-Apple.jpg", true, "Red Delicious" },
                    { 8, 0.85m, "https://i.ibb.co/Bz1tZ16/Golden-Delicious-Apple.jpg", true, "Golden Delicious" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8b2b3a2d-62f6-4f2b-8b3d-45b6a1f3b5b4", "ded8f7c8-cfc4-4b9b-bebb-db1d02eb3419", "Harvester", "harvester" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "2b1a2b07-1de7-46b9-8e03-7c0e1b3e7cbe", "Admin", "admin" },
                    { "d4f146bf-70c8-4d02-98ec-0b5f4b9d213f", "5a286ac9-6065-4fac-8141-23c8e52470f0", "Customer", "customer" },
                    { "f65f1f30-d0b1-4f59-a3c8-eb1f2e6757d3", "11b2eb1e-b7ac-4913-8009-237712a4126f", "OrderPicker", "orderpicker" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "03d8deac-3687-4274-82c1-e1d32392d2de", 0, "c44e2260-a0e5-4f17-98d3-0e7f95bf6b65", "kyle@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAED/IuNcFACRXEQAv/QPr8x+YKfSi/y6iuJ3fzPLh/V81/mLkg2C2SbNQW3tJLsCmbw==", null, false, "00ff7c46-7593-4a3d-b5dd-8c99bb23075b", false, "Kyle" },
                    { "3a64b2c1-7780-40f1-a393-8edb30c4b2ab", 0, "528a6b2f-8308-43a6-a7dc-c730f760f378", "haley@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEFLjyZeNuHTYB9o9mjcnT/PsIfI/zmOuFDYIqugyat19OSmi/HAjNZ2sx+Fr9oBYEw==", null, false, "599e3ef4-b44f-4a82-b499-c60b14183032", false, "Haley" },
                    { "83aab5f4-67ba-4da9-940e-fef0ce8597bd", 0, "6cbf4380-febc-4921-be02-7dab3812f7cf", "chris@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEFzaSaL3yMiDQf68cxnJMhQ5VYFD+AHb5bGC/dlSm/IWkScMoRPFIYvEpthfBwmxyA==", null, false, "46c2ad12-7239-4c70-990f-7870c8052684", false, "Chris" },
                    { "8c3605d2-c0da-4592-8879-0c71dc3c02c4", 0, "285068fd-bd6b-4aa9-9d65-205282bda7c6", "josh@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENcd3h1hIVWKLgvWRHitxvNmw5XgfspxqwBI5yg5JY1w/xfV2xe52KFfEKSOyA2JnA==", null, false, "b1b8841a-bd3b-4476-9466-3023d1ba4386", false, "Josh" },
                    { "bc3a3871-4800-4061-8182-b965c9c109bc", 0, "66f4a328-2cc1-4b08-b65a-c9768e6c9e4b", "aaron@yahoo.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEKUgAV8ggNUaW8m5UHsDfcWVHqmfMXErzSE0VTPHIddqbRAvQ981wp77JYSxD7YKKg==", null, false, "22d1c546-a573-4666-bf3d-10ea39cf6e53", false, "Aaron" },
                    { "c8c02266-41e6-414d-a1fc-14bbefef86a0", 0, "0f69fcef-ecd6-43e6-88bf-ffd1a1651bc8", "debbie@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEKqItYvuhYadiUb3uLA4wRCIEGZpQTNgH42U/cQkhpZVsQ3ZCCYxyMM0gNX6chLF+Q==", null, false, "c4750c51-d12c-45ee-bc7c-561b21ac78b3", false, "Debbie" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "5f51d50c-2fb2-42b0-9a17-ce62d55ffeae", "admin@gjapples.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEFgCbagNMwYFUFkyRFqDRDiNo6GvsHfeBGy1U4O7JIaXFdwGUvmMK35lKcPad83jiQ==", null, false, "db722b5f-080a-4056-a765-45e43bf31f82", false, "Administrator" }
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
                columns: new[] { "Id", "Address", "FirstName", "ForcePasswordChange", "IdentityUserId", "LastName" },
                values: new object[,]
                {
                    { 1, "101 Main Street", "Garry", false, "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Jones" },
                    { 2, "102 Harvest Lane", "Josh", false, "8c3605d2-c0da-4592-8879-0c71dc3c02c4", "Harvester" },
                    { 3, "103 Harvest Lane", "Haley", false, "3a64b2c1-7780-40f1-a393-8edb30c4b2ab", "Harvester" },
                    { 4, "104 Picker Street", "Chris", false, "83aab5f4-67ba-4da9-940e-fef0ce8597bd", "Picker" },
                    { 5, "105 Picker Street", "Kyle", false, "03d8deac-3687-4274-82c1-e1d32392d2de", "Picker" },
                    { 6, "106 Customer Road", "Debbie", false, "c8c02266-41e6-414d-a1fc-14bbefef86a0", "Customer" },
                    { 7, "107 Customer Road", "Aaron", false, "bc3a3871-4800-4061-8182-b965c9c109bc", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Canceled", "CustomerUserProfileId", "DateCompleted", "DateOrdered", "EmployeeUserProfileId" },
                values: new object[,]
                {
                    { 1, true, 6, null, new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, true, 6, null, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, true, 7, null, new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, false, 6, new DateTime(2023, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, false, 7, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, false, 7, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 7, false, 7, new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 8, false, 7, new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 9, false, 6, null, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
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
                    { 3, 4, 1, 1.0m },
                    { 4, 6, 1, 2.5m },
                    { 5, 2, 2, 2.0m },
                    { 6, 8, 2, 3.0m },
                    { 7, 4, 2, 1.0m },
                    { 8, 6, 2, 1.0m },
                    { 9, 7, 3, 4.0m },
                    { 10, 4, 3, 1.5m },
                    { 11, 2, 3, 1.0m },
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
                    { 26, 3, 7, 1.0m },
                    { 27, 4, 7, 1.0m },
                    { 28, 8, 8, 1.0m },
                    { 29, 3, 8, 3.0m },
                    { 30, 2, 8, 2.5m },
                    { 31, 4, 8, 4.0m },
                    { 32, 1, 8, 4.5m },
                    { 33, 6, 8, 1.0m },
                    { 34, 5, 8, 2.0m },
                    { 35, 7, 8, 1.0m },
                    { 36, 3, 9, 1.0m },
                    { 37, 8, 9, 1.0m },
                    { 38, 5, 9, 2.5m },
                    { 39, 7, 9, 1.0m },
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
                    { 50, 6, 11, 1.0m }
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
