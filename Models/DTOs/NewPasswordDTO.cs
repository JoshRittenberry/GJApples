using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GJApples.Models.DTOs;

public class NewPasswordDTO
{
    public string IdentityUserId { get; set; }
    public string Password { get; set; }
}