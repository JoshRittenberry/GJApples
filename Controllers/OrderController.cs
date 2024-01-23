using GJApples.Data;
using GJApples.Models;
using GJApples.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GJApples.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private GJApplesDbContext _dbContext;

    public OrderController(GJApplesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
            .Orders
            .Include(o => o.Customer)
                .ThenInclude(c => c.IdentityUser)
            .Include(o => o.Employee)
                .ThenInclude(e => e.IdentityUser)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.AppleVariety)
            .Select(o => new OrderDTO
            {
                Id = o.Id,
                CustomerUserProfileId = o.CustomerUserProfileId,
                Customer = null,
                EmployeeUserProfileId = o.EmployeeUserProfileId,
                Employee = null,
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
        );
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetOrderById(int id)
    {
        var order = _dbContext
            .Orders
            .Include(o => o.Customer)
                .ThenInclude(c => c.IdentityUser)
            .Include(o => o.Employee)
                .ThenInclude(e => e.IdentityUser)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.AppleVariety)
            .SingleOrDefault(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        return Ok(new OrderDTO
        {
            Id = order.Id,
            CustomerUserProfileId = order.CustomerUserProfileId,
            Customer = null,
            EmployeeUserProfileId = order.EmployeeUserProfileId,
            Employee = null,
            DateOrdered = order.DateOrdered,
            DateCompleted = order.DateCompleted,
            Canceled = order.Canceled,
            OrderItems = order.OrderItems.Select(oi => new OrderItemDTO
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
        });
    }
}