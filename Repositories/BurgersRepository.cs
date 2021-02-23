using System;
using System.Collections.Generic;
using System.Data;
using burgerapi.Models;
using Dapper;

namespace burgerapi.Repositories
{
  public class BurgersRepository
  {
    public readonly IDbConnection _db;

    public BurgersRepository(IDbConnection db)
    {
      _db = db;
    }
    //NOTE dotnet add package dapper - to be able to communicate with db
    public IEnumerable<Burger> GetAll()
    {
      string sql = "SELECT * FROM burgers;";
      return _db.Query<Burger>(sql);
    }

    internal Burger GetById(int id)
    {
      string sql = "SELECT * FROM burgers WHERE id = @id;";
      return _db.QueryFirstOrDefault<Burger>(sql, new { id });
    }


    internal Burger Create(Burger newBurger)
    {
      string sql = @"
            INSERT INTO burgers
            (name, description, price)
            VALUES
            (@Name, @Description, @Price);
            SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newBurger);
      newBurger.Id = id;
      return newBurger;
    }



    internal void Delete(Burger burger)
    {
      string sql = "DELETE FROM burgers WHERE id = @Id";
      _db.Execute(sql, burger);
    }

    internal Burger Edit(Burger original)
    {
      string sql = @"
        UPDATE burgers
        SET
            description = @Description,
            price = @Price
        WHERE id = @Id;
        SELECT * FROM burgers WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Burger>(sql, original);
    }
  }
}