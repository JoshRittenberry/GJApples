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
    public IActionResult Get()
    {
        return Ok(_dbContext
            .AppleVarieties
                .Include(a => a.Trees)
                .Include(a => a.OrderItems)
            .Select(a => new AppleVarietyDTO
            {
                Id = a.Id,
                Type = a.Type,
                ImageUrl = a.ImageUrl,
                CostPerPound = a.CostPerPound,
                Trees = a.Trees
                    .Where(t => t.DateRemoved == null)
                    .Select(t => new TreeDTO
                    {
                        Id = t.Id,
                        AppleVarietyId = t.AppleVarietyId,
                        AppleVariety = null,
                        DatePlanted = t.DatePlanted,
                        DateRemoved = t.DateRemoved,
                        TreeHarvestReports = null
                    }).ToList(),
                OrderItems = a.OrderItems.Select(oi => new OrderItemDTO
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    AppleVarietyId = oi.AppleVarietyId,
                    AppleVariety = null,
                    Pounds = oi.Pounds
                }).ToList()
            }).ToList()
        );
    }
}