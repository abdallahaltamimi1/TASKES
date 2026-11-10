
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_CafeteriaTASK6.Data;
using University_CafeteriaTASK6.Models;

namespace University_CafeteriaTASK6.Controllers
{
    [Authorize]
    public class SupplyRequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SupplyRequestController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);

            var requests = _context.SupplyRequests
                .Include(r => r.RequestItems)
                .AsQueryable();

            if (!User.IsInRole("Admin") &&
                !User.IsInRole("SuperAdmin"))
            {
                requests = requests.Where(r => r.UserId == userId);
            }

            return View(requests.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        [HttpPost]
        
        public IActionResult Create(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);

            if (product == null || quantity <= 0)
                return BadRequest();

            var request = new SupplyRequest
            {
                UserId = _userManager.GetUserId(User)!,
                RequestDate = DateTime.Now,
                Status = "Pending",
                TotalPrice = product.Price * quantity
            };

            var item = new RequestItem
            {
                ProductId = productId,
                Quantity = quantity,
                Price = product.Price
            };

            request.RequestItems = new List<RequestItem> { item };

            _context.SupplyRequests.Add(request);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var request = _context.SupplyRequests
                .Include(r => r.RequestItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(r => r.Id == id);

            if (request == null)
                return NotFound();

            if (!CanAccess(request))
                return Forbid();

            return View(request);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var request = _context.SupplyRequests
                .Include(r => r.RequestItems)
                .FirstOrDefault(r => r.Id == id);

            if (request == null)
                return NotFound();

            if (!CanAccess(request))
                return Forbid();

            if (request.Status != "Pending")
                return BadRequest("Only pending requests can be edited.");

            ViewBag.Products = _context.Products.ToList();

            return View(request);
        }

        [HttpPost]
        
        public IActionResult Edit(int id, int productId, int quantity)
        {
            var request = _context.SupplyRequests
                .Include(r => r.RequestItems)
                .FirstOrDefault(r => r.Id == id);

            if (request == null)
                return NotFound();

            if (!CanAccess(request))
                return Forbid();

            if (request.Status != "Pending")
                return BadRequest("Request cannot be edited.");

            var product = _context.Products.Find(productId);

            if (product == null || quantity <= 0)
                return BadRequest();

            _context.RequestItems.RemoveRange(request.RequestItems);

            request.RequestItems = new List<RequestItem>
            {
                new RequestItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.Price
                }
            };

            request.TotalPrice = product.Price * quantity;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        
        public IActionResult Delete(int id)
        {
            var request = _context.SupplyRequests
                .Include(r => r.RequestItems)
                .FirstOrDefault(r => r.Id == id);

            if (request == null)
                return NotFound();

            if (!CanAccess(request))
                return Forbid();

            if (request.Status != "Pending")
                return BadRequest("Only pending requests can be deleted.");

            _context.RequestItems.RemoveRange(request.RequestItems);
            _context.SupplyRequests.Remove(request);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        
        public IActionResult Approve(int id)
        {
            var request = _context.SupplyRequests.Find(id);

            if (request == null)
                return NotFound();

            if (request.Status != "Pending")
                return BadRequest();

            request.Status = "Approved";
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        
        public IActionResult Reject(int id)
        {
            var request = _context.SupplyRequests.Find(id);

            if (request == null)
                return NotFound();

            if (request.Status != "Pending")
                return BadRequest();

            request.Status = "Rejected";
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private bool CanAccess(SupplyRequest request)
        {
            return User.IsInRole("Admin")
                || User.IsInRole("SuperAdmin")
                || request.UserId == _userManager.GetUserId(User);
        }
    }
}
