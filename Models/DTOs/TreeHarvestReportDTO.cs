using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GJApples.Models.DTOs;

public class TreeHarvestReportDTO
{
    public int Id { get; set; }
    [Required]
    public int TreeId { get; set; }
    public TreeDTO Tree { get; set; }
    [Required]
    [ForeignKey("Employee")]
    public int EmployeeUserProfileId { get; set; }
    public UserProfileDTO Employee { get; set; }
    [Required]
    public DateTime HarvestDate { get; set; }
    [Required]
    [Range(0, 999)]
    public decimal PoundsHarvested { get; set; }
}