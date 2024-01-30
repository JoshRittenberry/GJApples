using GJApples.Data;
using GJApples.Models;
using GJApples.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GJApples.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfilesController : ControllerBase
{
    private GJApplesDbContext _dbContext;

    public UserProfilesController(GJApplesDbContext context)
    {
        _dbContext = context;
    }

    // Get all UserProfiles
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Get()
    {
        return Ok(_dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .Select(up => new UserProfileDTO
            {
                Id = up.Id,
                FirstName = up.FirstName,
                LastName = up.LastName,
                Address = up.Address,
                IdentityUserId = up.IdentityUserId,
                Email = up.IdentityUser.Email,
                UserName = up.IdentityUser.UserName
            })
            .ToList());
    }

    // Get UserProfile by Id
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Get(int id)
    {
        var foundUP = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .SingleOrDefault(up => up.Id == id);

        if (foundUP == null)
        {
            return NotFound();
        }

        return Ok(new UserProfileDTO
        {
            Id = foundUP.Id,
            FirstName = foundUP.FirstName,
            LastName = foundUP.LastName,
            Address = foundUP.Address,
            Email = foundUP.IdentityUser.Email,
            UserName = foundUP.IdentityUser.UserName,
            IdentityUserId = foundUP.IdentityUserId,
            IdentityUser = foundUP.IdentityUser
        });
    }

    // Get UserProfiles with Roles
    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .Select(up => new UserProfileDTO
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Address = up.Address,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList()
        }));
    }

    // Promote UserProfile
    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Promote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");
        // This will create a new row in the many-to-many UserRoles table.
        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = id
        });
        _dbContext.SaveChanges();
        return NoContent();
    }

    // Demote UserProfile
    [HttpPost("demote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Demote(string id)
    {
        IdentityRole role = _dbContext.Roles
            .SingleOrDefault(r => r.Name == "Admin");
        IdentityUserRole<string> userRole = _dbContext
            .UserRoles
            .SingleOrDefault(ur =>
                ur.RoleId == role.Id &&
                ur.UserId == id);

        _dbContext.UserRoles.Remove(userRole);
        _dbContext.SaveChanges();
        return NoContent();
    }

    // Edit UserProfile
    [HttpPut("{id}")]
    [Authorize]
    public IActionResult UpdateUserProfile(UserProfileDTO update, int id)
    {
        var foundUP = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .SingleOrDefault(up => up.Id == id);

        if (foundUP == null)
        {
            return NotFound();
        }

        bool isUpdated = false;

        // Update FirstName
        if (!string.IsNullOrWhiteSpace(update.FirstName) && update.FirstName != foundUP.FirstName)
        {
            foundUP.FirstName = update.FirstName.Trim();
            isUpdated = true;
        }
        // Update LastName
        if (!string.IsNullOrWhiteSpace(update.LastName) && update.LastName != foundUP.LastName)
        {
            foundUP.LastName = update.LastName.Trim();
            isUpdated = true;
        }
        // Update Email
        if (!string.IsNullOrWhiteSpace(update.Email) && update.Email != foundUP.IdentityUser.Email)
        {
            foundUP.IdentityUser.Email = update.Email.Trim();
            isUpdated = true;
        }
        // Update UserName
        if (!string.IsNullOrWhiteSpace(update.UserName) && update.UserName != foundUP.IdentityUser.UserName)
        {
            foundUP.IdentityUser.UserName = update.UserName.Trim();
            isUpdated = true;
        }
        // Update Address
        if (!string.IsNullOrWhiteSpace(update.Address) && update.Address != foundUP.Address)
        {
            foundUP.Address = update.Address.Trim();
            isUpdated = true;
        }

        if (isUpdated)
        {
            _dbContext.SaveChanges();
            return Ok();
        }

        return NoContent();
    }
}