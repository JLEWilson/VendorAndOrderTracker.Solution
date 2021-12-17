using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;
using System.Collections.Generic;
using System;

namespace PierresBakery.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }
    [TestMethod]
    public void OrderConstructor_CreateInstanceOfOrder_Order()
    {
      Order newOrder = new Order("Suzie's Cafe Weekly", "100 Croissant, 30 Sourdough, 30 Brioche", 300, "Every Tuesday");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
    [TestMethod]
    public void GetAll_ReturnAllInstances_OrderList()
    {
      Order order1 = new Order("Suzie's Cafe Weekly", "100 Croissant, 30 Sourdough, 30 Brioche", 300, "Every Tuesday");
      Order order2 = new Order("Buncha Buns", "500 buns", 250, "Tomorrow");
      List <Order> orderList = new List<Order> {order1, order2};
      
      List <Order> returnList = Order.GetAll();
      CollectionAssert.AreEqual(orderList, returnList);
    }
  }
}