using System.ComponentModel.DataAnnotations;
namespace GJApples.Models;

public class AppleVariety
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    public string ImageUrl { get; set; }
    [Required]
    public decimal PoundsOnHand
    {
        get
        {
            return Trees.Sum(t => t.TreeHarvestReports.Sum(th => th.PoundsHarvested)) - OrderItems.Sum(oi => oi.Pounds);
        }
    }
    [Required]
    public decimal CostPerPound { get; set; }
    public List<Tree> Trees { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}