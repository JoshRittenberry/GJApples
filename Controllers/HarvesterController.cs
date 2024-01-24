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
public class HarvestersController : ControllerBase
{
    private GJApplesDbContext _dbContext;

    public HarvestersController(GJApplesDbContext context)
    {
        _dbContext = context;
    }

    // Get all Harvester Profiles
    [HttpGet]
    // [Authorize(Roles = "Admin,Harvester")]
    public IActionResult Get()
    {
        return Ok(_dbContext
            .UserProfiles
            .Include(u => u.IdentityUser)
            .Include(u => u.TreeHarvestReports)
                .ThenInclude(thr => thr.Tree)
                    .ThenInclude(t => t.AppleVariety)
            .Where(u => _dbContext.UserRoles
                .Any(ur => ur.UserId == u.IdentityUserId &&
                       _dbContext.Roles.Any(r => r.Id == ur.RoleId && r.Name == "Harvester")))
            .Select(harvester => new HarvesterDTO
            {
                Id = harvester.Id,
                FirstName = harvester.FirstName,
                LastName = harvester.LastName,
                Address = harvester.Address,
                Email = harvester.IdentityUser.Email,
                TreeHarvestReports = harvester.TreeHarvestReports.Select(thr => new TreeHarvestReportDTO
                {
                    Id = thr.Id,
                    TreeId = thr.TreeId,
                    Tree = new TreeDTO
                    {
                        Id = thr.Tree.Id,
                        AppleVarietyId = thr.Tree.AppleVarietyId,
                        AppleVariety = new AppleVarietyDTO
                        {
                            Id = thr.Tree.AppleVariety.Id,
                            Type = thr.Tree.AppleVariety.Type,
                            ImageUrl = thr.Tree.AppleVariety.ImageUrl,
                            CostPerPound = thr.Tree.AppleVariety.CostPerPound,
                            IsActive = thr.Tree.AppleVariety.IsActive,
                            Trees = null,
                            OrderItems = null
                        },
                        DatePlanted = thr.Tree.DatePlanted,
                        DateRemoved = thr.Tree.DateRemoved,
                        TreeHarvestReports = null
                    },
                    EmployeeUserProfileId = thr.EmployeeUserProfileId,
                    Employee = null,
                    HarvestDate = thr.HarvestDate,
                    PoundsHarvested = thr.PoundsHarvested
                }).ToList()
            }).ToList());
    }

    // // Get Harvester Profile by Id
    // [HttpGet("{id}")]
    // // [Authorize]
    // public IActionResult GetCustomerById(int id)
    // {
    //     var customer = _dbContext
    //         .UserProfiles
    //             .Include(u => u.IdentityUser)
    //             .Include(u => u.Orders)
    //                 .ThenInclude(o => o.Employee)
    //                     .ThenInclude(e => e.IdentityUser)
    //             .Include(u => u.Orders)
    //                 .ThenInclude(o => o.OrderItems)
    //                     .ThenInclude(oi => oi.AppleVariety)
    //         .Where(u => _dbContext.UserRoles
    //             .Any(ur => ur.UserId == u.IdentityUserId &&
    //                    _dbContext.Roles.Any(r => r.Id == ur.RoleId && r.Name == "Customer")))
    //         .SingleOrDefault(c => c.Id == id);

    //     if (customer == null)
    //     {
    //         return NotFound();
    //     }

    //     return Ok(new CustomerDTO
    //     {
    //         Id = customer.Id,
    //         FirstName = customer.FirstName,
    //         LastName = customer.LastName,
    //         Address = customer.Address,
    //         Email = customer.IdentityUser.Email,
    //         Orders = customer.Orders.Select(o => new OrderDTO
    //         {
    //             Id = o.Id,
    //             CustomerUserProfileId = o.CustomerUserProfileId,
    //             Customer = null,
    //             EmployeeUserProfileId = o.EmployeeUserProfileId,
    //             Employee = o.Employee == null ? null : new OrderPickerDTO
    //             {
    //                 Id = o.Employee.Id,
    //                 FirstName = o.Employee.FirstName,
    //                 LastName = o.Employee.LastName,
    //                 Address = o.Employee.Address,
    //                 Email = o.Employee.IdentityUser.Email,
    //                 CompletedOrders = null
    //             },
    //             DateOrdered = o.DateOrdered,
    //             DateCompleted = o.DateCompleted,
    //             Canceled = o.Canceled,
    //             OrderItems = o.OrderItems.Select(oi => new OrderItemDTO
    //             {
    //                 Id = oi.Id,
    //                 OrderId = oi.OrderId,
    //                 AppleVarietyId = oi.AppleVarietyId,
    //                 AppleVariety = new AppleVarietyDTO
    //                 {
    //                     Id = oi.AppleVariety.Id,
    //                     Type = oi.AppleVariety.Type,
    //                     ImageUrl = oi.AppleVariety.ImageUrl,
    //                     CostPerPound = oi.AppleVariety.CostPerPound,
    //                     IsActive = oi.AppleVariety.IsActive,
    //                     Trees = null,
    //                     OrderItems = null
    //                 },
    //                 Pounds = oi.Pounds
    //             }).ToList()
    //         }).ToList()
    //     });
    // }

}