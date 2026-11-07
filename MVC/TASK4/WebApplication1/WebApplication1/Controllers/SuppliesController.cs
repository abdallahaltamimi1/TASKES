using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplication1.Models;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace WebApplication1.Controllers
{
    public class SuppliesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Offers(product products)
        {
            List<product> productList = new List<product>();
            if (products.certificateOffer == "A")
            {
                product supplierA = new product();
                supplierA.Supplier = "Supplier A";
                supplierA.OfferName = "Premium Certificate Package";
                supplierA.Quantity = 35;
                supplierA.UnitPrice = 2;
                productList.Add(supplierA);
            }
            else if (products.certificateOffer == "B")
            {
                product supplierB = new product();
                supplierB.Supplier = "Supplier B";
                supplierB.OfferName = "Standard Certificate Package";
                supplierB.Quantity = 35;
                supplierB.UnitPrice = 1.5m;
                productList.Add(supplierB);
            }
            else if (products.certificateOffer == "C")
            {
                product supplierC = new product();
                supplierC.Supplier = "Supplier C";
                supplierC.OfferName = "Luxury Certificate Package";
                supplierC.Quantity = 35;
                supplierC.UnitPrice = 2.5m;
                productList.Add(supplierC);
            }
             if(products.hospitalityOffer == "D")
            {
                product supplierD = new product();
                supplierD.Supplier = "Supplier D";
                supplierD.OfferName = "Coffee & Drinks Package";
                supplierD.Quantity = 100;
                supplierD.UnitPrice = 2;
                productList.Add(supplierD);
            }
            else if (products.hospitalityOffer == "E")
            {
                product supplierE = new product();
                supplierE.Supplier = "Supplier E";
                supplierE.OfferName = "Sandwiches & Snacks Packagee";
                supplierE.Quantity = 100;
                supplierE.UnitPrice = 3m;
                productList.Add(supplierE);
            }
            else if (products.hospitalityOffer == "F")
            {
                product supplierF = new product();
                supplierF.Supplier = "Supplier F";
                supplierF.OfferName = "Full Hospitality Package";
                supplierF.Quantity = 100;
                supplierF.UnitPrice = 4;
                productList.Add(supplierF);
            }
             if(products.giftOffer == "G")
            {
                product supplierG = new product();
                supplierG.Supplier = "Supplier G";
                supplierG.OfferName = "Customized Mugs Package";
                supplierG.Quantity = 35;
                supplierG.UnitPrice = 2;
                productList.Add(supplierG);
            }
            else if (products.giftOffer == "H")
            {
                product supplierH = new product();
                supplierH.Supplier = "Supplier H";
                supplierH.OfferName = "Graduation Bags Package";
                supplierH.Quantity = 35;
                supplierH.UnitPrice = 3;
                productList.Add(supplierH);
            }
            else if (products.giftOffer == "I")
            {
                product supplierI = new product();
                supplierI.Supplier = "Supplier I";
                supplierI.OfferName = "Premium Gift Boxes Package";
                supplierI.Quantity = 35;
                supplierI.UnitPrice = 4;
                productList.Add(supplierI);
            }
            string json = JsonSerializer.Serialize(productList);

            HttpContext.Session.SetString("SelectedOffers", json);

            ViewBag.Products = productList;

            

            decimal totalprice = 0;
            decimal discount = 0;
            decimal discountPercentage = 0;

            foreach (var product in productList)
            {
                totalprice += product.Quantity * product.UnitPrice;
            }

            if (totalprice > 500)
            {
                discountPercentage = 15;
            }
            else if (totalprice > 300)
            {
                discountPercentage = 10;
            }

            discount = totalprice * discountPercentage / 100;

            decimal finalTotal = totalprice - discount;

            HttpContext.Session.SetString("Total", totalprice.ToString());
            HttpContext.Session.SetString("DiscountPercentage", discountPercentage.ToString());
            HttpContext.Session.SetString("Discount", discount.ToString());
            HttpContext.Session.SetString("FinalTotal", finalTotal.ToString());
            return RedirectToAction("Review");
            
        }
        public IActionResult Review()
        {
           string total= HttpContext.Session.GetString("Total");
            string dicountpercentage=HttpContext.Session.GetString("DiscountPercentage");
            string discount=HttpContext.Session.GetString("Discount");
           string finaltotal= HttpContext.Session.GetString("FinalTotal");
            string json = HttpContext.Session.GetString("SelectedOffers");
            if (string.IsNullOrEmpty(json)) 
            {

                return RedirectToAction("Index");
            }
            List<product> productList = JsonSerializer.Deserialize<List<product>>(json);
            ViewBag.Products = productList;
            ViewBag.total = total;
            ViewBag.dicountpercentage = dicountpercentage;
            ViewBag.finaltotal = finaltotal;
            ViewBag.discount = discount;


            return View();
        }
        public IActionResult About()
        {
            return View();

        }
       
    }
}
