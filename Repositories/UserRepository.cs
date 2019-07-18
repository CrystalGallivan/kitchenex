using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using kitchenex.Models;

namespace kitchenex.Repositories
{
  public class UserRepository
  {
    private readonly IDbConnection _db;
    public UserRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<User> GetAll()
    {

      try
      {
        return _db.Query<User>("SELECT * FROM users");
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public User GetById(int id)
    {
      try
      {
        string query = "SELECT * FROM users WHERE id = @Id";
        User data = _db.QueryFirstOrDefault<User>(query, new { id });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public User Create(User value)
    {
      try
      {
        string query = @"INSERT INTO users (name, email, password) VALUES (@Name, @Email, @Password);
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

    public User Update(User value)
    {
      try
      {
        string query = @"
      UPDATE users
      SET
          name = @Name,
          email = @Email,
          password = @Password
      WHERE id = @Id;
      SELECT * FROM users WHERE id = @Id
      ";
        return _db.QueryFirstOrDefault<User>(query, value);
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
        string query = "DELETE FROM users WHERE id = @Id";
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