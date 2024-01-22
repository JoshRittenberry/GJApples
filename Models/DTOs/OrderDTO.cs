using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GJApples.Models.DTOs;
namespace GJApples.Models.DTO;

public class OrderDTO
{
    public int Id { get; set; }

    [ForeignKey("Customer")]
    public int CustomerUserProfileId { get; set; }

    public UserProfileDTO Customer { get; set; }

    [ForeignKey("Employee")]
    public int? EmployeeUserProfileId { get; set; }

    public UserProfileDTO Employee { get; set; }

    public DateTime DateOrdered { get; set; }
    public DateTime? DateCompleted { get; set; }
    public bool Canceled { get; set; }
    public decimal TotalCost
    {
        get
        {
            return OrderItems.Sum(oi => oi.Pounds * oi.AppleVariety.CostPerPound);
        }
    }

    public List<OrderItemDTO> OrderItems { get; set; }
}