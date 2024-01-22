using System.ComponentModel.DataAnnotations;
namespace GJApples.Models.DTO;

public class AppleVarietyDTO
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string ImageUrl { get; set; }
    public decimal? PoundsOnHand
    {
        get
        {
            decimal HarvestedTotal = Trees.Sum(t => t.TreeHarvestReports.Sum(th => th.PoundsHarvested));
            decimal OrderedTotal = OrderItems.Sum(oi => oi.Pounds);
            return HarvestedTotal - OrderedTotal;
        }
    }
    public decimal CostPerPound { get; set; }
    public List<TreeDTO> Trees { get; set; }
    public List<OrderItemDTO> OrderItems { get; set; }
}