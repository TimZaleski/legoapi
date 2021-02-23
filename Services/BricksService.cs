using System;
using System.Collections.Generic;
using legoapi.Models;
using legoapi.Repositories;

namespace legoapi.Services
{
  public class BricksService
  {

    private readonly BricksRepository _repo;

    public BricksService(BricksRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Brick> Get()
    {
      return _repo.GetAll();
    }

    internal Brick Get(int id)
    {
      Brick brick = _repo.GetById(id);
      if (brick == null)
      {
        throw new Exception("invalid Id");
      }
      return brick;
    }

    internal Brick Create(Brick newBrick)
    {
      return _repo.Create(newBrick);
    }

    internal Brick Edit(Brick editBrick)
    {
      Brick original = Get(editBrick.Id);

      original.Description = editBrick.Description != null ? editBrick.Description : original.Description;
      original.Color = editBrick.Color != null ? editBrick.Color : original.Color;

      return _repo.Edit(original);


    }

    internal Brick Delete(int id)
    {

      Brick brick = Get(id);
      _repo.Delete(brick);
      return brick;
    }
  }
}