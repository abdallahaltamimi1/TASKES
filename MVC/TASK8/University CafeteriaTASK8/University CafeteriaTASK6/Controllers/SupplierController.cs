using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using University_CafeteriaTASK6.Data;
using University_CafeteriaTASK6.Models;

namespace University_CafeteriaTASK6.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var supplier = _context.Suppliers.ToList();
            var supplierCount = _context.Suppliers.Count();
            ViewBag.SupplierCount = supplierCount;
            return View(supplier);
        }
        [HttpGet]
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
           return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
        [HttpPost]
        public IActionResult DeleteAll( )
        {
            var supplier = _context.Suppliers.ToList();
            if (supplier == null)
            {
                return NotFound();
            }
            _context.Suppliers.RemoveRange(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
