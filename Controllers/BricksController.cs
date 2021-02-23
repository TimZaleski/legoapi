using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using legoapi.Models;
using legoapi.Services;

namespace legoapi.Controllers
{
  [ApiController]
  [Route("api/bricks")]
  public class BricksController : ControllerBase
  {

    private readonly BricksService _ds;
    public BricksController(BricksService ds)
    {
      _ds = ds;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Brick>> Get()
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
    public ActionResult<Brick> GetBrickById(int id)
    {
      try
      {
        Brick brick = _ds.Get(id);
        return Ok(brick);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    //frombody will create a new blank object with the properties set to null or their defaults
    //move data from the object sent to create your new class as long as it passes data sanitization.
    [HttpPost]
    public ActionResult<Brick> Create([FromBody] Brick newBrick)
    {
      try
      {
        Brick brick = _ds.Create(newBrick);
        return Ok(brick);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _ds.Delete(id);
        return Ok("Deleted");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]  
    public ActionResult<string> UpdateBurger([FromBody] Brick updated, int id) {  
      try
      { 
        updated.Id = id;
        Brick brick = _ds.Edit(updated);
        return Ok(brick);
      }
      catch (System.Exception err)
      {  
          return BadRequest(err.Message);
      }
      
    }  
  }
}