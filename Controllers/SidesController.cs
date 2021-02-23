using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using burgerapi.db;
using burgerapi.Models;
using burgerapi.Services;

namespace burgerapi.Controllers
{
  [ApiController]
  [Route("api/sides")]
  public class SidesController : ControllerBase
  {

    private readonly SidesService _ds;
    public SidesController(SidesService ds)
    {
      _ds = ds;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Side>> Get()
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
    public ActionResult<Side> GetSideById(int id)
    {
      try
      {
        Side side = _ds.Get(id);
        return Ok(side);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    //frombody will create a new blank object with the properties set to null or their defaults
    //move data from the object sent to create your new class as long as it passes data sanitization.
    [HttpPost]
    public ActionResult<Burger> Create([FromBody] Side newSide)
    {
      try
      {
        Side side = _ds.Create(newSide);
        return Ok(side);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpDelete("{id}")]
    public ActionResult<string> BuySide(int id)
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
    public ActionResult<string> UpdateSide([FromBody] Side updated, int id) {  
      try
      { 
        updated.Id = id;
        Side side = _ds.Edit(updated);
        return Ok(side);
      }
      catch (System.Exception err)
      {  
          return BadRequest(err.Message);
      }
      
    }  
  }
}