using System;
using System.Collections.Generic;
using burgerapi.db;
using burgerapi.Models;
using burgerapi.Repositories;

namespace burgerapi.Services
{
  public class BurgersService
  {

    private readonly BurgersRepository _repo;

    public BurgersService(BurgersRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Burger> Get()
    {
      return _repo.GetAll();
    }

    internal Burger Get(int id)
    {
      Burger burger = _repo.GetById(id);
      if (burger == null)
      {
        throw new Exception("invalid Id");
      }
      return burger;
    }

    internal Burger Create(Burger newBurger)
    {
      return _repo.Create(newBurger);
    }

    internal Burger Edit(Burger editBurger)
    {
      Burger original = Get(editBurger.Id);

      original.Title = editBurger.Title != null ? editBurger.Title : original.Title;
      original.Description = editBurger.Description != null ? editBurger.Description : original.Description;
      original.Price = editBurger.Price > 0 ? editBurger.Price : original.Price;

      return _repo.Edit(original);


    }

    internal Burger Delete(int id)
    {

      Burger burger = Get(id);
      _repo.Delete(burger);
      return burger;
    }
  }
}