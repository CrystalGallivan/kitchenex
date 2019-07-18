using System.ComponentModel.DataAnnotations;

namespace kitchenex.Models
{
  public class Menu
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int KitchenId { get; set; }
    public int SiteId { get; set; }
  }
}