using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using kitchenex.Models;

namespace kitchenex.Repositories
{
  public class KitchenRepository
  {
    private readonly IDbConnection _db;
    public KitchenRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Kitchen> GetAll()
    {
      try
      {
        return _db.Query<Kitchen>("SELECT * FROM kitchens");
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Kitchen GetById(int id)
    {
      try
      {
        string query = "SELECT * FROM kitchens WHERE id = @Id";
        Kitchen data = _db.QueryFirstOrDefault<Kitchen>(query, new { id });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Kitchen Create(Kitchen value)
    {
      try
      {
        string query = @"INSERT INTO kitchens (name, siteId)
                        VALUES (@Name, @SiteId);
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

    public Kitchen Update(Kitchen value)
    {
      try
      {
        string query = @"
      UPDATE kitchens
      SET
          name = @Name,
          siteId = @SiteId
      WHERE id = @Id;
      SELECT * FROM kitchens WHERE id = @Id
      ";
        return _db.QueryFirstOrDefault<Kitchen>(query, value);
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
        string query = "DELETE FROM kitchens WHERE id = @Id";
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