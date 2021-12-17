using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;
using System.Collections.Generic;
using System;

namespace PierresBakery.Tests
{
  [TestClass]
  public class OrderTests
  {
    [TestMethod]
    public void OrderConstructor_CreateInstanceOfOrder_Order()
    {
      Order newOrder = new Order("Suzie's Cafe", "100 Croissant, 30 Sourdough, 30 Brioche", 300, "Every Tuesday");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
  }
}