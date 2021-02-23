using System;
using System.Collections.Generic;
using System.Data;
using legoapi.Models;
using Dapper;

namespace legoapi.Repositories
{
  public class BricksRepository
  {
    public readonly IDbConnection _db;

    public BricksRepository(IDbConnection db)
    {
      _db = db;
    }
    //NOTE dotnet add package dapper - to be able to communicate with db
    public IEnumerable<Brick> GetAll()
    {
      string sql = "SELECT * FROM bricks;";
      return _db.Query<Brick>(sql);
    }

    internal Brick GetById(int id)
    {
      string sql = "SELECT * FROM bricks WHERE id = @id;";
      return _db.QueryFirstOrDefault<Brick>(sql, new { id });
    }


    internal Brick Create(Brick newBrick)
    {
      string sql = @"
            INSERT INTO bricks
            (description, color)
            VALUES
            (@Description, @Color);
            SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newBrick);
      newBrick.Id = id;
      return newBrick;
    }



    internal void Delete(Brick brick)
    {
      string sql = "DELETE FROM bricks WHERE id = @Id";
      _db.Execute(sql, brick);
    }

    internal Brick Edit(Brick original)
    {
      string sql = @"
        UPDATE bricks
        SET
            description = @Description,
            color = @Color
        WHERE id = @Id;
        SELECT * FROM bricks WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Brick>(sql, original);
    }
  }
}