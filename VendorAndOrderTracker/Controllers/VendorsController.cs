using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PierresBakery.Models;

namespace PierresBakery.Controllers
{
  public class VendorsController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }
    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName, string vendorDescription)
    {
      Vendor newVendor = new Vendor(vendorName, vendorDescription);
      return RedirectToAction("Index");
    }
    [HttpGet("/vendors/{vendorId}/")]
    public ActionResult Show(int vendorId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor targetVendor = Vendor.Find(vendorId);
      List<Order> vendorOrders = targetVendor.VenderOrders;
      model.Add("vendor", targetVendor);
      model.Add("orders", vendorOrders);
      return View(model);
    }
    [HttpPost()]
    public ActionResult Create(int vendorId, string title, string description, int price, string date)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor targetVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(title, description, price, date);
      targetVendor.AddOrder(newOrder);
      List<Order> vendorOrders = targetVendor.VenderOrders;
      model.Add("vendor", targetVendor);
      model.Add("orders", vendorOrders);
      return View("Show", model);
    }
  }
}