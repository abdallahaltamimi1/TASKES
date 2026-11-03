using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using WebApplication1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Controllers
{
    public class SupplyController : Controller
    {
        public IActionResult Index()
        {
                    List<string> product=new List<string> {"Drinks", "Food", "Snacks", "Hot Drinks", "Cold Drinks"};
                 ViewBag.Products = product;
            return View();
        }
        public IActionResult Products()
        {
           string Title = "Cafeteria Products";
           string ManagerName = "Ahmad Ali";
           int NumberOfProducts = 5;
            string[] Products = { "Water", "Orange Juice", "Coffee", "Sandwich", "Chocolate" };
            ViewData["Title"] = Title;
            ViewData["ManagerName"] = ManagerName;
            ViewData["NumberOfProducts"] = NumberOfProducts;
            ViewData["Products"] = Products;
            return View();
        }
        public IActionResult Suppliers()
        {
            ViewBag.Title = "Our Suppliers";
            ViewBag.NumberOfSuppliers = 3;

            string[] Suppliers = {"Fresh Food Company", "Happy Drinks Company", "Daily Supplies Company"};
            ViewBag.Suppliers = Suppliers;

            return View();
        }
        [HttpGet]
        public IActionResult CreateRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitRequest(productinfo productInfo)
        {
            productInfo.EmployeeName = Request.Form["EmployeeName"];
            if (string.IsNullOrWhiteSpace(productInfo.EmployeeName))
            {
                return Content("Employee Name is required.");
            }
            productInfo.ProductName = Request.Form["ProductName"];
            productInfo.Quantity = int.Parse(Request.Form["Quantity"]);
            productInfo.Date = DateTime.Parse(Request.Form["Date"]);

            TempData["message"] = "Supply request created successfully.";
            return RedirectToAction("About");
        }
        public IActionResult About()
        {
            return View();
        }
      
    }
}

   