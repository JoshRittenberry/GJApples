using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using GJApples.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "GJApplesLoginCookie";
        options.Cookie.SameSite = SameSiteMode.None; // Set SameSite to None
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensure the cookie is Secure
        options.Cookie.HttpOnly = true;
        options.Cookie.MaxAge = new TimeSpan(7, 0, 0, 0);
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = new TimeSpan(24, 0, 0);
        options.Events.OnRedirectToLogin = (context) =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
        options.Events.OnRedirectToAccessDenied = (context) =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };
    });

builder.Services.AddIdentityCore<IdentityUser>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 8;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.User.RequireUniqueEmail = true;
            })
    .AddRoles<IdentityRole>()  //add the role service.  
    .AddEntityFrameworkStores<GJApplesDbContext>();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<GJApplesDbContext>(builder.Configuration["GJApplesDbConnectionString"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// these two calls are required to add auth to the pipeline for a request
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
