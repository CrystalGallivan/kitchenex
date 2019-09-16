using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using kitchenex.Models;

namespace kitchenex.Repositories
{
  public class InventoryRepository
  {
    private readonly IDbConnection _db;
    public InventoryRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Inventory> GetAll()
    {
      try
      {
        return _db.Query<Inventory>("SELECT * FROM inventory");
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Inventory GetById(int id)
    {
      try
      {
        string query = "SELECT * FROM inventory WHERE id = @Id";
        Inventory data = _db.QueryFirstOrDefault<Inventory>(query, new { id });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Inventory Create(Inventory value)
    {
      try
      {
        string query = @"INSERT INTO inventory (kitchenId)
                        VALUES (@KitchenId);
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

    public Inventory Update(Inventory value)
    {
      try
      {
        string query = @"
      UPDATE inventory
      SET
         kitchenId = @KitchenId
      WHERE id = @Id;
      SELECT * FROM inventory WHERE id = @Id
      ";
        return _db.QueryFirstOrDefault<Inventory>(query, value);
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
        string query = "DELETE FROM inventory WHERE id = @Id";
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