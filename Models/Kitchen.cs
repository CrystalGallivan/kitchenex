using System.ComponentModel.DataAnnotations;

namespace kitchenex.Models
{
  public class Kitchen
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int SiteId { get; set; }
  }
}