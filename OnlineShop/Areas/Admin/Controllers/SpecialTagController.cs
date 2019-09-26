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
    public class SpecialTagController : Controller
    {
        Repository<SpecialTag> repo;
        public SpecialTagController(ApplicationDbContext _db)
        {
            repo = new Repository<SpecialTag>(_db);
        }

        public IActionResult Index()
        {
            return View(repo.All());
        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(SpecialTag sTag)
        {
            if (sTag == null)
            {
                return NotFound();
            }
            else
            {
                repo.Create(sTag);
                await repo.save();
                TempData["save"] = "Special Tag has been saved succesfully.";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Details(int ID)
        {
            SpecialTag sTag = repo.GetByID(ID);
            return View(sTag);
        }

        public IActionResult Edit(int ID)
        {
            SpecialTag sTag = repo.GetByID(ID);
            return View(sTag);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(SpecialTag sTag)
        {
            repo.Edit(sTag);
            await repo.save();
            TempData["edit"] = "Special Tag has been edited succesfully.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int ID, SpecialTag sTags)
        {
            SpecialTag sTag = repo.GetByID(ID);
            return View(sTag);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(int ID)
        {
            repo.Delete(ID);
            await repo.save();
            TempData["delete"] = "Special Tag has been deleteed succesfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}