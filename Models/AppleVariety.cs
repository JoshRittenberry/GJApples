using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace GJApples.Models;

public class AppleVariety
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    public string ImageUrl { get; set; }
    [Required]
    public decimal? PoundsOnHand
    {
        get
        {
            decimal HarvestedTotal = Trees.Sum(t => t.TreeHarvestReports.Sum(th => th.PoundsHarvested));
            decimal OrderedTotal = OrderItems.Sum(oi => oi.Pounds);
            return HarvestedTotal - OrderedTotal;
        }
    }
    [Required]
    public decimal CostPerPound { get; set; }
    public List<Tree> Trees { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}