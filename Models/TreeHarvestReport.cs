using System.ComponentModel.DataAnnotations;
using GJApples.Models;
namespace HouseRules.Models;

public class TreeHarvestReport
{
    public int Id { get; set; }
    [Required]
    public int TreeId { get; set; }
    public Tree Tree { get; set; }
    [Required]
    public int UserProfileId { get; set; }
    public UserProfile Employee { get; set; }
    [Required]
    public DateTime HarvestDate { get; set; }
    [Required]
    public decimal PoundsHarvested { get; set; }
}