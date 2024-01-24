using System.ComponentModel.DataAnnotations;
namespace GJApples.Models;

public class OrderItem
{
    public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int AppleVarietyId { get; set; }
    public AppleVariety? AppleVariety { get; set; }
    [Required]
    public decimal Pounds { get; set; }
    public decimal? TotalItemCost
    {
        get
        {
            if (AppleVariety == null)
            {
                return null;
            }

            return AppleVariety.CostPerPound * Pounds;
        }
    }
}