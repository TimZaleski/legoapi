using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using burgerapi.db;
using burgerapi.Models;
using burgerapi.Services;

namespace burgerapi.Controllers
{
  [ApiController]
  [Route("api/burgers")]
  public class BurgersController : ControllerBase
  {

    private readonly BurgersService _ds;
    public BurgersController(BurgersService ds)
    {
      _ds = ds;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Burger>> Get()
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
    public ActionResult<Burger> GetBurgerById(int id)
    {
      try
      {
        Burger burger = _ds.Get(id);
        return Ok(burger);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    //frombody will create a new blank object with the properties set to null or their defaults
    //move data from the object sent to create your new class as long as it passes data sanitization.
    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Burger newBurger)
    {
      try
      {
        Burger burger = _ds.Create(newBurger);
        return Ok(burger);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpDelete("{burgerId}")]
    public ActionResult<string> BuyBurger(int burgerId)
    {
      try
      {
        _ds.Delete(burgerId);
        return Ok("Bought");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{burgerId}")]  
    public ActionResult<string> UpdateBurger([FromBody] Burger updated, int id) {  
      try
      { 
        updated.Id = id;
        Burger burger = _ds.Edit(updated);
        return Ok(burger);
      }
      catch (System.Exception err)
      {  
          return BadRequest(err.Message);
      }
      
    }  
  }
}