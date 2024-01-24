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

    // Get all Orders
    [HttpGet]
    [Authorize]
    public IActionResult GetSubmittedOrders()
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

    // Get Order by Id
    [HttpGet("{id}")]
    [Authorize]
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

    // Create new Order
    [HttpPost]
    [Authorize(Roles = "Customer")]
    public IActionResult CreateNewOrder()
    {
        var customerUserName = User.Identity.Name;
        UserProfile customer = _dbContext
            .UserProfiles
            .SingleOrDefault(u => u.IdentityUser.UserName == customerUserName);

        if (customer == null)
        {
            return BadRequest();
        }

        Order order = new Order
        {
            CustomerUserProfileId = customer.Id,
            Canceled = false
        };

        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();

        return Ok();
    }

    // Submit Order (Add a DateOrdered Value)
    [HttpPut("{id}/submit")]
    [Authorize(Roles = "Customer")]
    public IActionResult SubmitOrder(int id)
    {
        // Find Order
        var orderToUpdate = _dbContext
            .Orders
            .SingleOrDefault(o => o.Id == id);

        // Find Customer UserName
        var customerUserName = User.Identity.Name;

        // Find Customer UserProfile
        UserProfile customer = _dbContext
            .UserProfiles
            .SingleOrDefault(u => u.IdentityUser.UserName == customerUserName);

        if (orderToUpdate == null || customer == null)
        {
            return NotFound();
        }

        if (customer.Id != orderToUpdate.CustomerUserProfileId)
        {
            return BadRequest();
        }

        orderToUpdate.DateOrdered = DateTime.Now;
        _dbContext.SaveChanges();

        return Ok(orderToUpdate);
    }

    // Cancel an Order
    [HttpPut("{id}/cancel")]
    [Authorize(Roles = "Customer")]
    public IActionResult CancelOrder(int id)
    {
        // Find Order
        var orderToUpdate = _dbContext
            .Orders
            .SingleOrDefault(o => o.Id == id);

        // Find Customer UserName
        var customerUserName = User.Identity.Name;

        // Find Customer UserProfile
        UserProfile customer = _dbContext
            .UserProfiles
            .SingleOrDefault(u => u.IdentityUser.UserName == customerUserName);

        if (orderToUpdate == null || customer == null)
        {
            return NotFound();
        }

        if (customer.Id != orderToUpdate.CustomerUserProfileId)
        {
            return BadRequest();
        }

        orderToUpdate.Canceled = true;
        _dbContext.SaveChanges();

        return Ok(orderToUpdate);
    }

    // Assign an Order to an Order Picker
    [HttpPut("{id}/assignorderpicker")]
    [Authorize(Roles = "Admin,AssignOrderPicker")]
    public IActionResult AssignOrderPicker(int id, [FromQuery] int? employeeId)
    {
        // Find Order
        var orderToUpdate = _dbContext
            .Orders
            .SingleOrDefault(o => o.Id == id);

        // Find Customer UserProfile
        UserProfile orderPicker = _dbContext
            .UserProfiles
            .SingleOrDefault(u => u.Id == employeeId);

        if (orderToUpdate == null || orderPicker == null)
        {
            return NotFound();
        }

        orderToUpdate.EmployeeUserProfileId = employeeId;
        _dbContext.SaveChanges();

        return Ok(orderToUpdate);
    }

    // Complete an Order (Add a DateCompleted Value)
    [HttpPut("{id}/complete")]
    [Authorize(Roles = "Admin,OrderPicker")]
    public IActionResult CompleteOrder(int id)
    {
        // Find Order
        var orderToUpdate = _dbContext
            .Orders
            .SingleOrDefault(o => o.Id == id);

        // Find Customer UserName
        var employeeUserName = User.Identity.Name;

        // Find Customer UserProfile
        UserProfile employee = _dbContext
            .UserProfiles
            .SingleOrDefault(u => u.IdentityUser.UserName == employeeUserName);

        bool isEmployeeAdmin = User.IsInRole("Admin");

        if (orderToUpdate == null || employee == null)
        {
            return NotFound();
        }

        if (employee.Id != orderToUpdate.EmployeeUserProfileId || !isEmployeeAdmin)
        {
            return BadRequest();
        }

        orderToUpdate.DateCompleted = DateTime.Now;
        _dbContext.SaveChanges();

        return Ok(orderToUpdate);
    }

    // Complete OrderItems
}