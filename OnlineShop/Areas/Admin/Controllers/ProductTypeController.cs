using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repository;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeController : Controller
    {
        private Repository<ProductTypes> repo = null;
        public ProductTypeController(ApplicationDbContext db)
        {
            //_db = db;
            repo = new Repository<ProductTypes>(db);
        }
        public IActionResult Index()
        {
            return View(repo.All());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes prdtType)
        {
            if (ModelState.IsValid)
            {
                repo.Create(prdtType);
                await repo.save();
                TempData["save"] = "Product Type has been saved succesfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(prdtType);
        }
        public ActionResult Edit(int ID)
        {
            if (ID == 0)
                return NotFound();
            else
            {
                ProductTypes prdtType = repo.GetByID(ID);

                return View(prdtType);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductTypes prdtType)
        {
            repo.Edit(prdtType);
            await repo.save();
            TempData["edit"] = "Product Type has been edited succesfully.";
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int ID)
        {
            ProductTypes prdtType = repo.GetByID(ID);
            return View(prdtType);

        }

        public ActionResult Delete(int ID, ProductTypes prdtTypes)
        {
            ProductTypes prdtType = repo.GetByID(ID);
            return View(prdtType);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(int ID)
        {
            if (ID == 0)
            {
                return NotFound();
            }
            else
            {
                repo.Delete(ID);
                await repo.save();
                TempData["delete"] = "Product Type has been deletd succesfully.";
                return RedirectToAction(nameof(Index));
            }
        }

    }
}