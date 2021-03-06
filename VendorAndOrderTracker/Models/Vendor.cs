using System.Collections.Generic;

namespace PierresBakery.Models
{
  public class Vendor
  {
    private static List<Vendor> _instances = new List<Vendor>{};
    public int Id {get;}
    public string Name {get; set;}
    public string Description {get; set;}
    public List<Order> VenderOrders {get; set;}

    public Vendor(string name, string description)
    {
      Name = name;
      Description = description;
      _instances.Add(this);
      Id = _instances.Count;
      VenderOrders = new List<Order>{};
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Vendor Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public void AddOrder(Order order)
    {
      VenderOrders.Add(order);
    }
  }
}