using Microsoft.AspNetCore.Mvc;
using University_CafeteriaTASK6.Data;
using University_CafeteriaTASK6.Models;

namespace University_CafeteriaTASK6.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SupplierController(ApplicationDbContext context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var supolier = _context.supplier.ToList();
            return View(supolier);
        }
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(Supplier supplier)
        {

            _context.supplier.Add(supplier);
            _context.SaveChanges();
           return RedirectToAction("Index");
        }

    }
}
