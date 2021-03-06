using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakery.Models;
using System.Collections.Generic;
using System;

namespace PierresBakery.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreateInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("Suzie's Cafe", "Long time vendor! Priority order for good relations.");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }
    [TestMethod]
    public void GetAll_ReturnAllInstancesOfVendor_VendorList()
    {
      Vendor vendor1 = new Vendor("Vendor 1", "This is the first vendor");
      Vendor vendor2 = new Vendor("Vendor 2", "This is the second vendor");
      Vendor vendor3 = new Vendor("Vendor 3", "This is the third vendor");
      List<Vendor> vendorList = new List<Vendor>{vendor1, vendor2, vendor3};

      List<Vendor> getAllVendors = Vendor.GetAll();

      CollectionAssert.AreEqual(vendorList, getAllVendors);
    }
    [TestMethod]
    public void ClearAll_RemovesAllInstancesOfVendor_VendorList()
    {
      Vendor vendor1 = new Vendor("Vendor 1", "This is the first vendor");
      Vendor vendor2 = new Vendor("Vendor 2", "This is the second vendor");
      Vendor vendor3 = new Vendor("Vendor 3", "This is the third vendor");
      List<Vendor> vendorList = new List<Vendor>{vendor1, vendor2, vendor3};
      List<Vendor> emptyList = new List<Vendor> {};
      Vendor.ClearAll();
      List<Vendor> getAllVendors = Vendor.GetAll();

      CollectionAssert.AreEqual(emptyList, getAllVendors);
    }
    [TestMethod]
    public void Find_ReturnSpecificInstanceOfVendor_Vendor()
    {
      Vendor vendor1 = new Vendor("Vendor 1", "This is the first vendor");
      Vendor vendor2 = new Vendor("Vendor 2", "This is the second vendor");
      Vendor vendor3 = new Vendor("Vendor 3", "This is the third vendor");

      Vendor shouldFindVendor2 = Vendor.Find(2);

      Assert.AreEqual(vendor2, shouldFindVendor2);
    }
    [TestMethod]
    public void AddOrder_AddOrderToOrderListProperty_OrderList()
    {
      Vendor vendor1 = new Vendor("Burgerking", "They sell burgers and are the kings of it");
      Order order = new Order("Buncha Buns", "500 buns", 250, "Tomorrow");
      List<Order> orders = new List<Order>{order};
      vendor1.AddOrder(order);
      List<Order> vender1Orders = vendor1.VenderOrders;
      CollectionAssert.AreEqual(orders, vendor1.VenderOrders);
    }
  }
}