using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repository;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        readonly Repository<Products> repo;
        readonly ApplicationDbContext db;
        readonly Repository<ProductTypes> repoprdtyType;
        readonly Repository<SpecialTag> reposTag;
        public ProductController(ApplicationDbContext _db)
        {
            db = _db;

            repo = new Repository<Products>(_db);
            repoprdtyType = new Repository<ProductTypes>(_db);
            reposTag = new Repository<SpecialTag>(_db);
        }
        public IActionResult Index()
        {
            return View(db.products.Include(v => v.ProductType).Include(a => a.specialTag));
        }

        public IActionResult Create()
        {

            ViewData["productTypeId"] = new SelectList(db.productTypes.ToList(), "ID", "ProductType");
            ViewData["TagId"] = new SelectList(db.SpecialTags.ToList(), "ID", "Name");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Products product)
        {
            repo.Create(product);
            await repo.save();
            TempData["save"] = "Product has been saved Successfully.";
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int ID)
        {

            ViewData["productTypeId"] = new SelectList(db.productTypes.ToList(), "ID", "ProductType");
            ViewData["TagId"] = new SelectList(db.SpecialTags.ToList(), "ID", "Name");
            Products lst = repo.GetByID(ID);
            return View(lst);
        }

        public IActionResult Details(int ID)
        {
            Products av = db.products.Include(v => v.ProductType).Include(a => a.specialTag).Where(a => a.ID == ID).FirstOrDefault() as Products;
            return View(av);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(Products product)
        {
            repo.Edit(product);
            await repo.save();
            TempData["edit"] = "Product has been updated Successfully.";
            return RedirectToAction(nameof(Index));
            //return View(product);

        }

        public IActionResult Delete(int ID)
        {
            Products av = db.products.Include(v => v.ProductType).Include(a => a.specialTag).Where(a => a.ID == ID).FirstOrDefault() as Products;
            return View(av);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(int ID, Products prdt)
        {

            ViewData["productTypeId"] = new SelectList(db.productTypes.ToList(), "ID", "ProductType");
            ViewData["TagId"] = new SelectList(db.SpecialTags.ToList(), "ID", "Name");
            repo.Delete(ID);
            await repo.save();
            TempData["delete"] = "Product has been updated Successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}