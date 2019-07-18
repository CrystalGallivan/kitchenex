using System.ComponentModel.DataAnnotations;

namespace kitchenex.Models
{
  public class Inventory
  {
    public int Id { get; set; }
    [Required]
    public int KitchenId { get; set; }

  }
}