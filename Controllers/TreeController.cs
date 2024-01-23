using GJApples.Data;
using GJApples.Models;
using GJApples.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GJApples.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreeController : ControllerBase
{
    private GJApplesDbContext _dbContext;

    public TreeController(GJApplesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
        bool isAuthorized = User.Identity.IsAuthenticated && User.IsInRole("Admin");

        return Ok(_dbContext
            .Trees
            .Include(t => t.AppleVariety)
            .Include(t => t.TreeHarvestReports)
                .ThenInclude(thr => thr.Employee)
                .ThenInclude(e => e.IdentityUser)
            .Select(t => new TreeDTO
            {
                Id = t.Id,
                AppleVarietyId = t.AppleVarietyId,
                AppleVariety = new AppleVarietyDTO
                {
                    Id = t.AppleVariety.Id,
                    Type = t.AppleVariety.Type,
                    ImageUrl = t.AppleVariety.ImageUrl,
                    CostPerPound = t.AppleVariety.CostPerPound,
                    IsActive = t.AppleVariety.IsActive,
                    Trees = null,
                    OrderItems = null
                },
                DatePlanted = t.DatePlanted,
                DateRemoved = t.DateRemoved,
                TreeHarvestReports = t.TreeHarvestReports.Select(thr => new TreeHarvestReportDTO
                {
                    Id = thr.Id,
                    TreeId = thr.TreeId,
                    Tree = null,
                    EmployeeUserProfileId = thr.EmployeeUserProfileId,
                    Employee = new UserProfileDTO
                    {
                        Id = thr.Employee.Id,
                        FirstName = thr.Employee.FirstName,
                        LastName = thr.Employee.LastName,
                        Address = isAuthorized ? thr.Employee.Address : null,
                        Email = isAuthorized ? thr.Employee.IdentityUser.Email : null,
                        UserName = isAuthorized ? thr.Employee.IdentityUser.UserName : null,
                    },
                    HarvestDate = thr.HarvestDate,
                    PoundsHarvested = thr.PoundsHarvested
                }).ToList()
            }).ToList()
        );
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult Get(int id)
    {
        var tree = _dbContext
            .Trees
            .Include(t => t.AppleVariety)
            .Include(t => t.TreeHarvestReports)
                .ThenInclude(thr => thr.Employee)
                .ThenInclude(e => e.IdentityUser)
            .SingleOrDefault(t => t.Id == id);

        if (tree == null)
        {
            return NotFound();
        }

        return Ok(new TreeDTO
        {
            Id = tree.Id,
            AppleVarietyId = tree.AppleVarietyId,
            AppleVariety = new AppleVarietyDTO
            {
                Id = tree.AppleVariety.Id,
                Type = tree.AppleVariety.Type,
                ImageUrl = tree.AppleVariety.ImageUrl,
                CostPerPound = tree.AppleVariety.CostPerPound,
                IsActive = tree.AppleVariety.IsActive,
                Trees = null,
                OrderItems = null
            },
            DatePlanted = tree.DatePlanted,
            DateRemoved = tree.DateRemoved,
            TreeHarvestReports = tree.TreeHarvestReports.Select(thr => new TreeHarvestReportDTO
            {
                Id = thr.Id,
                TreeId = thr.TreeId,
                Tree = null,
                EmployeeUserProfileId = thr.EmployeeUserProfileId,
                Employee = new UserProfileDTO
                {
                    Id = thr.Employee.Id,
                    FirstName = thr.Employee.FirstName,
                    LastName = thr.Employee.LastName,
                    Address = thr.Employee.Address,
                    Email = thr.Employee.IdentityUser.Email,
                    UserName = thr.Employee.IdentityUser.UserName,
                },
                HarvestDate = thr.HarvestDate,
                PoundsHarvested = thr.PoundsHarvested
            }).ToList()
        });
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateNewTree(Tree tree)
    {
        _dbContext.Trees.Add(tree);
        _dbContext.SaveChanges();

        return Created($"/api/tree/{tree.Id}", tree);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult EditTree(Tree tree, int id)
    {
        var treeToUpdate = _dbContext
            .Trees
            .SingleOrDefault(t => t.Id == id);

        if (treeToUpdate == null)
        {
            return NotFound();
        }

        bool isUpdated = false;

        // Update AppleVarietyId
        if (tree.AppleVarietyId != null && tree.AppleVarietyId != treeToUpdate.AppleVarietyId)
        {
            treeToUpdate.AppleVarietyId = tree.AppleVarietyId;
            isUpdated = true;
        }
        // Update DatePlanted
        if (tree.DatePlanted != null && tree.DatePlanted != treeToUpdate.DatePlanted)
        {
            if (tree.DatePlanted == DateTime.MinValue)
            {
                treeToUpdate.DatePlanted = treeToUpdate.DatePlanted;
            }
            else
            {
                treeToUpdate.DatePlanted = tree.DatePlanted;
                isUpdated = true;
            }
        }
        // Update DateRemoved
        if (tree.DateRemoved != null && tree.DateRemoved != treeToUpdate.DateRemoved)
        {
            if (tree.DatePlanted == DateTime.MinValue)
            {
                treeToUpdate.DateRemoved = treeToUpdate.DateRemoved;
            }
            else
            {
                treeToUpdate.DateRemoved = tree.DateRemoved;
                isUpdated = true;
            }
        }
        // Save Changes
        if (isUpdated)
        {
            _dbContext.SaveChanges();
            return Ok(treeToUpdate);
        }
        // Cancel Changes (if everything matches)
        else
        {
            return NoContent();
        }
    }

    [HttpPut("{id}/remove")]
    [Authorize(Roles = "Admin")]
    public IActionResult RemoveTree(int id)
    {
        var treeToUpdate = _dbContext
            .Trees
            .SingleOrDefault(t => t.Id == id);

        if (treeToUpdate == null)
        {
            return NotFound();
        }

        treeToUpdate.DateRemoved = DateTime.Today;
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteTree(int id)
    {
        var treeToUpdate = _dbContext
            .Trees
            .SingleOrDefault(t => t.Id == id);

        if (treeToUpdate == null)
        {
            return NotFound();
        }

        _dbContext.Remove(treeToUpdate);
        _dbContext.SaveChanges();

        return NoContent();
    }
}