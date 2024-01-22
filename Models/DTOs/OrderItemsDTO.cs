using System.ComponentModel.DataAnnotations;
namespace GJApples.Models.DTO;

public class OrderItemDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int AppleVarietyId { get; set; }
    public AppleVarietyDTO AppleVariety { get; set; }
    public decimal Pounds { get; set; }
}