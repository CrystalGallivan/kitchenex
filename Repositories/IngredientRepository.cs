using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using kitchenex.Models;

namespace kitchenex.Repositories
{
  public class IngredientRepository
  {
    private readonly IDbConnection _db;
    public IngredientRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Ingredient> GetAll()
    {
      try
      {
        return _db.Query<Ingredient>("SELECT * FROM ingredients");
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Ingredient GetById(int id)
    {
      try
      {
        string query = "SELECT * FROM ingredients WHERE id = @Id";
        Ingredient data = _db.QueryFirstOrDefault<Ingredient>(query, new { id });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Ingredient Create(Ingredient value)
    {
      try
      {
        string query = @"INSERT INTO ingredients (name, brand, distributor, quantity, packageCost, packageSize, unitId, categoryId, recipeId, inventoryId)
                        VALUES (@Name, @Brand, @Distributor, @Quantity, @PackageCost, @PackageSize, @UnitId, @CategoryId, @RecipeId, @InventoryId);
                SELECT LAST_INSERT_ID();";
        int id = _db.ExecuteScalar<int>(query, value);
        value.Id = id;
        return value;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Ingredient Update(Ingredient value)
    {
      try
      {
        string query = @"
      UPDATE ingredients
      SET
          name = @Name,
          brand = @Brand,
          distributor = @Distributor,
          quantity = @Quantity,
          packageCost = @PackageCost,
          packageSize = @PackageSize,
          unitId = @UnitId,
          categoryId = @CategoryId,
          recipeId = @RecipeId,
          inventoryId = @InventoryId
      WHERE id = @Id;
      SELECT * FROM ingredients WHERE id = @Id
      ";
        return _db.QueryFirstOrDefault<Ingredient>(query, value);
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public string Delete(int id)
    {
      try
      {
        string query = "DELETE FROM ingredients WHERE id = @Id";
        int changedRows = _db.Execute(query, new { id });
        if (changedRows < 1) throw new Exception("Invalid Id");
        return "Successfully Deleted";
      }
      catch (Exception e)
      {
        throw e;
      }
    }
  }
}