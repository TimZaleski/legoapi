using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using burgerapi.db;
using burgerapi.Models;
using burgerapi.Services;

namespace burgerapi.Controllers
{
  [ApiController]
  [Route("api/drinks")]
  public class DrinksController : ControllerBase
  {

    private readonly DrinksService _ds;
    public DrinksController(DrinksService ds)
    {
      _ds = ds;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Drink>> Get()
    {
      try
      {
        return Ok(_ds.Get());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<Side> GetDrinkById(int id)
    {
      try
      {
        Drink drink = _ds.Get(id);
        return Ok(drink);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    //frombody will create a new blank object with the properties set to null or their defaults
    //move data from the object sent to create your new class as long as it passes data sanitization.
    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Drink newDrink)
    {
      try
      {
        Drink drink = _ds.Create(newDrink);
        return Ok(drink);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpDelete("{id}")]
    public ActionResult<string> BuyDrink(int id)
    {
      try
      {
        _ds.Delete(id);
        return Ok("Bought");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]  
    public ActionResult<string> UpdateDrink([FromBody] Drink updated, int id) {  
      try
      { 
        updated.Id = id;
        Drink drink = _ds.Edit(updated);
        return Ok(drink);
      }
      catch (System.Exception err)
      {  
          return BadRequest(err.Message);
      }
      
    }  
  }
}