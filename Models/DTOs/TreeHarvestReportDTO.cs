using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GJApples.Models.DTOs;

public class TreeHarvestReportDTO
{
    public int Id { get; set; }
    [Required]
    public int TreeId { get; set; }
    public Tree Tree { get; set; }
    [Required]
    [ForeignKey("Employee")]
    public int EmployeeUserProfileId { get; set; }
    public UserProfileDTO Employee { get; set; }
    [Required]
    public DateTime HarvestDate { get; set; }
    [Required]
    public decimal PoundsHarvested { get; set; }
}