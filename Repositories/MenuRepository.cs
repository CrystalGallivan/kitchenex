using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using kitchenex.Models;

namespace kitchenex.Repositories
{
  public class MenuRepository
  {
    private readonly IDbConnection _db;
    public MenuRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Menu> GetAll()
    {
      try
      {
        return _db.Query<Menu>("SELECT * FROM menus");
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Menu GetById(int id)
    {
      try
      {
        string query = "SELECT * FROM menus WHERE id = @Id";
        Menu data = _db.QueryFirstOrDefault<Menu>(query, new { id });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Menu Create(Menu value)
    {
      try
      {
        string query = @"INSERT INTO menus (name, kitchenId, siteId)
                        VALUES (@Name, @KitchenId, @SiteId);
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

    public Menu Update(Menu value)
    {
      try
      {
        string query = @"
      UPDATE menus
      SET
          name = @Name,
          kitchenId = @KitchenId,
          siteId = @SiteId
      WHERE id = @Id;
      SELECT * FROM menus WHERE id = @Id
      ";
        return _db.QueryFirstOrDefault<Menu>(query, value);
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
        string query = "DELETE FROM menus WHERE id = @Id";
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