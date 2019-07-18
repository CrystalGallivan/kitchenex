using System.ComponentModel.DataAnnotations;

namespace kitchenex.Models
{
  public class Ingredient
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Distributor { get; set; }
    public int Quantity { get; set; }
    public int PackageCost { get; set; }
    public string PackageSize { get; set; }
    public int UnitId { get; set; }
    public int CategoryId { get; set; }
    public int RecipeId { get; set; }
    public int InventoryId { get; set; }
  }
}