using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repository;
using OnlineShop.Utility;

namespace OnlineShop.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        Repository<Products> repo;

        public HomeController(ApplicationDbContext _db)
        {
            db = _db;
            repo = new Repository<Products>(_db);
        }
        public IActionResult Index()
        {
            var lst = db.products.Include(v => v.ProductType).Include(a => a.specialTag).ToList();
            return View(lst);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Details(int ID)
        {
            List<Products> products = new List<Products>();
            if (ID == 0)
            {
                return NotFound();
            }
            else
            {
                Products prdt = db.products.Include(v => v.ProductType).Include(a => a.specialTag).Where(av => av.ID == ID).FirstOrDefault() as Products;
                return View(prdt);
            }
        }

        [HttpPost]
        [ActionName("Details")]
        public IActionResult ProductDetails(int ID)
        {
            List<Products> products = new List<Products>();
            if (ID == 0)
            {
                return NotFound();
            }
            else
            {
                Products prdt = db.products.Include(v => v.ProductType).Include(a => a.specialTag).Where(av => av.ID == ID).FirstOrDefault() as Products;
                products = HttpContext.Session.Get<List<Products>>("products");
                if (products == null)
                {
                    products = new List<Products>();
                }
                products.Add(prdt);
                HttpContext.Session.Set("products", products);
                return View(prdt);
            }
        }


        //[ActionName("Remove")]
        //public IActionResult RemoveToCart(int id)
        //{
        //    List<Products> products = HttpContext.Session.Get<List<Products>>("products");
        //    if (products != null)
        //    {
        //        var product = products.FirstOrDefault(c => c.ID == id);
        //        if (product != null)
        //        {
        //            products.Remove(product);
        //            HttpContext.Session.Set("products", products);
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]
        [HttpPost]
        public IActionResult Remove(int ID)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.ID == ID);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Cart()
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if (products != null)
            {
                HttpContext.Session.Set("products", products);
            }
            else
            {
                products = new List<Products>();
            }
            return View(products);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
