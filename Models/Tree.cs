using System.ComponentModel.DataAnnotations;
namespace HouseRules.Models;

public class Tree
{
    public int Id { get; set; }
    [Required]
    public int AppleVarietyId { get; set; }
    [Required]
    public AppleVariety AppleVariety { get; set; }
    [Required]
    public DateOnly DatePlanted { get; set; }
    public DateOnly? DateRemoved { get; set; }
    public List<TreeHarvestReport> TreeHarvestReports { get; set; }
}