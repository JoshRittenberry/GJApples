using System.ComponentModel.DataAnnotations;
namespace GJApples.Models.DTO;

public class TreeDTO
{
    public int Id { get; set; }
    public int AppleVarietyId { get; set; }
    public AppleVariety AppleVariety { get; set; }
    public DateOnly DatePlanted { get; set; }
    public DateOnly? DateRemoved { get; set; }
    public List<TreeHarvestReportDTO> TreeHarvestReports { get; set; }
}