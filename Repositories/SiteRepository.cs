using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Policy;
using Dapper;

namespace kitchenex.Repositories
{
  public class SiteRepository
  {

    private readonly IDbConnection _db;
    public SiteRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Site> GetAll()
    {
      try
      {
        return _db.Query<Site>("SELECT * FROM sites");
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Site GetById(int id)
    {
      try
      {
        string query = "SELECT * FROM sites WHERE id = @Id";
        Site data = _db.QueryFirstOrDefault<Site>(query, new { id });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Site Create(Site value)
    {
      try
      {
        string query = @"INSERT INTO users (name, userId)
                        VALUES (@Name, @UserId);
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

    public Site Update(Site value)
    {
      try
      {
        string query = @"
      UPDATE sites
      SET
          name = @Name,
         userId = @UserId
      WHERE id = @Id;
      SELECT * FROM sites WHERE id = @Id
      ";
        return _db.QueryFirstOrDefault<Site>(query, value);
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
        string query = "DELETE FROM sites WHERE id = @Id";
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