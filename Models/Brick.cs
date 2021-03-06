using System;
using System.ComponentModel.DataAnnotations;

namespace legoapi.Models
{
  public class Brick
  {

    public Brick()
    {

    }
    public Brick(string description, string color)
    { 
      Color = color;
      Description = description;
    }

    [Required]
    public string Description { get; set; }
    public string Color { get; set; }
    public int Id { get; set; }
  }
}