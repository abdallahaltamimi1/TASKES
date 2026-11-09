using Microsoft.AspNetCore.Mvc;
using University_CafeteriaTASK6.Data;
using University_CafeteriaTASK6.Models;

namespace University_CafeteriaTASK6.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products=_context.Products.ToList();
            var productsCount = _context.Products.Count();
            ViewBag.ProductsCount = productsCount;
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Suppliers = _context.Suppliers.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Suppliers = _context.Suppliers.ToList();

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult DeleteAll()
        {
            var products = _context.Products.ToList();
            _context.Products.RemoveRange(products);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
