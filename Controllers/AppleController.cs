using GJApples.Data;
using GJApples.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GJApples.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppleController : ControllerBase
{
    private GJApplesDbContext _dbContext;

    public AppleController(GJApplesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
        bool isAuthorized = User.Identity.IsAuthenticated;

        return Ok(_dbContext
            .AppleVarieties
                .Include(a => a.Trees)
                    .ThenInclude(t => t.TreeHarvestReports)
                .Include(a => a.OrderItems)
            .Select(a => new AppleVarietyDTO
            {
                Id = a.Id,
                Type = a.Type,
                ImageUrl = a.ImageUrl,
                CostPerPound = a.CostPerPound,
                Trees = isAuthorized ? a.Trees
                    .Where(t => t.DateRemoved == null)
                    .Select(t => new TreeDTO
                    {
                        Id = t.Id,
                        AppleVarietyId = t.AppleVarietyId,
                        AppleVariety = null,
                        DatePlanted = t.DatePlanted,
                        DateRemoved = t.DateRemoved,
                        TreeHarvestReports = t.TreeHarvestReports.Select(thr => new TreeHarvestReportDTO
                        {
                            Id = thr.Id,
                            TreeId = thr.TreeId,
                            Tree = null,
                            EmployeeUserProfileId = thr.EmployeeUserProfileId,
                            Employee = null,
                            HarvestDate = thr.HarvestDate,
                            PoundsHarvested = thr.PoundsHarvested
                        }).ToList()
                    }).ToList() : null,
                OrderItems = isAuthorized ? a.OrderItems.Select(oi => new OrderItemDTO
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    AppleVarietyId = oi.AppleVarietyId,
                    AppleVariety = null,
                    Pounds = oi.Pounds
                }).ToList() : null
            }).ToList()
        );
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult Get(int id)
    {
        var appleVariety = _dbContext
            .AppleVarieties
                .Include(a => a.Trees)
                    .ThenInclude(t => t.TreeHarvestReports)
                .Include(a => a.OrderItems)
            .SingleOrDefault(a => a.Id == id);

        if (appleVariety == null)
        {
            return NotFound();
        }

        return Ok(new AppleVarietyDTO
        {
            Id = appleVariety.Id,
            Type = appleVariety.Type,
            ImageUrl = appleVariety.ImageUrl,
            CostPerPound = appleVariety.CostPerPound,
            Trees = appleVariety.Trees
                    .Where(t => t.DateRemoved == null)
                    .Select(t => new TreeDTO
                    {
                        Id = t.Id,
                        AppleVarietyId = t.AppleVarietyId,
                        AppleVariety = null,
                        DatePlanted = t.DatePlanted,
                        DateRemoved = t.DateRemoved,
                        TreeHarvestReports = t.TreeHarvestReports.Select(thr => new TreeHarvestReportDTO
                        {
                            Id = thr.Id,
                            TreeId = thr.TreeId,
                            Tree = null,
                            EmployeeUserProfileId = thr.EmployeeUserProfileId,
                            Employee = null,
                            HarvestDate = thr.HarvestDate,
                            PoundsHarvested = thr.PoundsHarvested
                        }).ToList()
                    }).ToList(),
            OrderItems = appleVariety.OrderItems.Select(oi => new OrderItemDTO
            {
                Id = oi.Id,
                OrderId = oi.OrderId,
                AppleVarietyId = oi.AppleVarietyId,
                AppleVariety = null,
                Pounds = oi.Pounds
            }).ToList()
        });
    }
}