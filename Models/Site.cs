using System.ComponentModel.DataAnnotations;

namespace kitchenex.Models
{
  public class Site
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int userId { get; set; }
  }
}