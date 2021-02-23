using System.Collections.Generic;
using burgerapi.Models;

namespace burgerapi.db
{
  public class FAKEDB
  {
    public static List<Burger> Burgers { get; set; } = new List<Burger>();
  }
}