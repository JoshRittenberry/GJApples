using System.ComponentModel.DataAnnotations;
namespace HouseRules.Models;

public class AppleVariety
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    public string ImageUrl { get; set; }
    [Required]
    public decimal PoundsOnHand { get; set; }
    [Required]
    public decimal CostPerPound { get; set; }
    public List<Tree> Trees { get; set; }
}