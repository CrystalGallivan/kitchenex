using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using kitchenex.Models;

namespace kitchenex.Repositories
{
  public class RecipeRepository
  {
    private readonly IDbConnection _db;
    public RecipeRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Recipe> GetAll()
    {
      try
      {
        return _db.Query<Recipe>("SELECT * FROM recipes");
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Recipe GetById(int id)
    {
      try
      {
        string query = "SELECT * FROM recipes WHERE id = @Id";
        Recipe data = _db.QueryFirstOrDefault<Recipe>(query, new { id });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Recipe Create(Recipe value)
    {
      try
      {
        string query = @"INSERT INTO users (name, portions, portionSize, calories, side, allergensId,
                          stationId, unitId, kitchenId, menuId, dayId)
                        VALUES (@Name, @Portions, @PortionSize, @Calories, @Side, @AllergensId,
                         @StationId, @UnitId, @KitchenId, @MenuId, @DayId);
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

    public Recipe Update(Recipe value)
    {
      try
      {
        string query = @"
      UPDATE recipes
      SET
          name = @Name,
          portions = @Portions,
          portionSize = @PortionSize,
          calories = @Calories,
          side = @Side,
          allergensId = @AllergensId,
          stationsId = @StationsId,
          unitId = @UnitId,
          kitchenId = @KitchenId,
          menuId = @MenuId,
          dayId = @dayId
      WHERE id = @Id;
      SELECT * FROM recipes WHERE id = @Id
      ";
        return _db.QueryFirstOrDefault<Recipe>(query, value);
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
        string query = "DELETE FROM recipes WHERE id = @Id";
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