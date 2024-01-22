using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GJApples.Models;

public class Order
{
    public int Id { get; set; }

    [ForeignKey("Customer")]
    public int CustomerUserProfileId { get; set; }

    public UserProfile Customer { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeUserProfileId { get; set; }

    public UserProfile Employee { get; set; }

    public DateTime DateOrdered { get; set; }
    public DateTime? DateCompleted { get; set; }

    public decimal TotalCost
    {
        get
        {
            return OrderItems.Sum(oi => oi.Pounds * oi.AppleVariety.CostPerPound);
        }
    }

    public List<OrderItem> OrderItems { get; set; }
}