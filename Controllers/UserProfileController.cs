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
    [Authorize]
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
    [Authorize]
    public IActionResult Get(int id)
    {
        var foundUP = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .SingleOrDefault(up => up.Id == id);

        return Ok(new UserProfileDTO
        {
            Id = foundUP.Id,
            FirstName = foundUP.FirstName,
            LastName = foundUP.LastName,
            Address = foundUP.Address,
            IdentityUserId = foundUP.IdentityUserId,
            IdentityUser = foundUP.IdentityUser
        });
    }

    // Get Customer Profile by Id
    [HttpGet("customer/{id}")]
    // [Authorize]
    public IActionResult GetCustomerById(int id)
    {
        var customer = _dbContext
            .UserProfiles
                .Include(u => u.IdentityUser)
            .SingleOrDefault(c => c.Id == id);

        var orders = _dbContext
            .Orders
                .Include(o => o.Employee)
                    .ThenInclude(e => e.IdentityUser)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.AppleVariety)
            .Where(o => o.CustomerUserProfileId == id);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(new CustomerDTO
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Address = customer.Address,
            Email = customer.IdentityUser.Email,
            Orders = orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                CustomerUserProfileId = o.CustomerUserProfileId,
                Customer = null,
                EmployeeUserProfileId = o.EmployeeUserProfileId,
                Employee = null,
                // Employee = new OrderPickerDTO
                // {
                //     Id = o.Employee.Id,
                //     FirstName = o.Employee.FirstName,
                //     LastName = o.Employee.LastName,
                //     Address = o.Employee.Address,
                //     Email = o.Employee.IdentityUser.Email,
                //     CompletedOrders = null
                // },
                DateOrdered = o.DateOrdered,
                DateCompleted = o.DateCompleted,
                Canceled = o.Canceled,
                OrderItems = o.OrderItems.Select(oi => new OrderItemDTO
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    AppleVarietyId = oi.AppleVarietyId,
                    AppleVariety = new AppleVarietyDTO
                    {
                        Id = oi.AppleVariety.Id,
                        Type = oi.AppleVariety.Type,
                        ImageUrl = oi.AppleVariety.ImageUrl,
                        CostPerPound = oi.AppleVariety.CostPerPound,
                        IsActive = oi.AppleVariety.IsActive,
                        Trees = null,
                        OrderItems = null
                    },
                    Pounds = oi.Pounds
                }).ToList()
            }).ToList()
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
}