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
    public void Find_ReturnSpecificInstanceOfVendor_Vendor()
    {
      Vendor vendor1 = new Vendor("Vendor 1", "This is the first vendor");
      Vendor vendor2 = new Vendor("Vendor 2", "This is the second vendor");
      Vendor vendor3 = new Vendor("Vendor 3", "This is the third vendor");

      Vendor shouldFindVendor2 = Vendor.Find(2);

      Assert.AreEqual(vendor2, shouldFindVendor2);
    }
  }
}