using System.ComponentModel.DataAnnotations;
namespace GJApples.Models.DTO;

public class AppleVarietyDTO
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string ImageUrl { get; set; }
    public decimal PoundsOnHand { get; set; }
    public decimal CostPerPound { get; set; }
    public List<TreeDTO> Trees { get; set; }
}