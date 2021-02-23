using System;
using System.ComponentModel.DataAnnotations;

namespace legoapi.Models
{
  public class Kit
  {

    public Kit()
    {

    }
    public Kit(string name, string instructions, float price)
    { 
      Name = name;
      Instructions = instructions;
      Price = price;
    }

    public string Name { get; set; }
    public string Instructions { get; set; }
    public float Price { get; set; }
    public int Id { get; set; }
  }
}