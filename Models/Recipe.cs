using System.ComponentModel.DataAnnotations;

namespace kitchenex.Models
{
  public class Recipe
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Portions { get; set; }
    public int PortionSize { get; set; }
    public int Calories { get; set; }
    public bool Side { get; set; }
    public int AllergensId { get; set; }
    public int StationsId { get; set; }
    public int UnitId { get; set; }
    public int KitchenId { get; set; }
    public int MenuId { get; set; }
    public int DayId { get; set; }
  }
}