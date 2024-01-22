using System.ComponentModel.DataAnnotations;
namespace GJApples.Models.DTOs;

public class TreeDTO
{
    public int Id { get; set; }
    public int AppleVarietyId { get; set; }
    public AppleVarietyDTO? AppleVariety { get; set; }
    public DateTime DatePlanted { get; set; }
    public DateTime? DateRemoved { get; set; }
    public List<TreeHarvestReportDTO>? TreeHarvestReports { get; set; }
}