using Microsoft.AspNetCore.Mvc;
using University_CafeteriaTASK6.Data;
using University_CafeteriaTASK6.Models;

namespace University_CafeteriaTASK6.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            var ordersCount = _context.Orders.Count();
           
            ViewBag.OrdersCount = ordersCount;
            return View(orders);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Employee = _context.Employees.ToList();
            return View();

        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Index");

           
        }
        public IActionResult Details(int id)
        {
            var order = _context.Orders.Find(id);
            return View(order);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _context.Orders.Find(id);
            ViewBag.Employee = _context.Employees.ToList();
            return View(order);
        }
        [HttpPost]
        public IActionResult Edit(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public IActionResult DeleteAll()
        {
            var orders = _context.Orders.ToList();
            _context.Orders.RemoveRange(orders);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
