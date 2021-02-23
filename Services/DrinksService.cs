using System;
using System.Collections.Generic;
using burgerapi.db;
using burgerapi.Models;
using burgerapi.Repositories;

namespace burgerapi.Services
{
  public class DrinksService
  {

    private readonly DrinksRepository _repo;

    public DrinksService(DrinksRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Drink> Get()
    {
      return _repo.GetAll();
    }

    internal Drink Get(int id)
    {
      Drink drink = _repo.GetById(id);
      if (drink == null)
      {
        throw new Exception("invalid Id");
      }
      return drink;
    }

    internal Drink Create(Drink newDrink)
    {
      return _repo.Create(newDrink);
    }

    internal Drink Edit(Drink editDrink)
    {
      Drink original = Get(editDrink.Id);

      original.Title = editDrink.Title != null ? editDrink.Title : original.Title;
      original.Description = editDrink.Description != null ? editDrink.Description : original.Description;
      original.Price = editDrink.Price > 0 ? editDrink.Price : original.Price;

      return _repo.Edit(original);
    }

    internal Drink Delete(int id)
    {

      Drink drink = Get(id);
      _repo.Delete(drink);
      return drink;
    }
  }
}