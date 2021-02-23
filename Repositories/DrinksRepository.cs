using System;
using System.Collections.Generic;
using System.Data;
using burgerapi.Models;
using Dapper;

namespace burgerapi.Repositories
{
  public class DrinksRepository
  {
    public readonly IDbConnection _db;

    public DrinksRepository(IDbConnection db)
    {
      _db = db;
    }
    //NOTE dotnet add package dapper - to be able to communicate with db
    public IEnumerable<Drink> GetAll()
    {
      string sql = "SELECT * FROM drinks;";
      return _db.Query<Drink>(sql);
    }

    internal Drink GetById(int id)
    {
      string sql = "SELECT * FROM drinks WHERE id = @id;";
      return _db.QueryFirstOrDefault<Drink>(sql, new { id });
    }


    internal Drink Create(Drink newDrink)
    {
      string sql = @"
            INSERT INTO drinks
            (name, description, price)
            VALUES
            (@Name, @Description, @Price);
            SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newDrink);
      newDrink.Id = id;
      return newDrink;
    }



    internal void Delete(Drink drink)
    {
      string sql = "DELETE FROM drinks WHERE id = @Id";
      _db.Execute(sql, drink);
    }

    internal Drink Edit(Drink original)
    {
      string sql = @"
        UPDATE drinks
        SET
            description = @Description,
            price = @Price
        WHERE id = @Id;
        SELECT * FROM drinks WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Drink>(sql, original);
    }
  }
}