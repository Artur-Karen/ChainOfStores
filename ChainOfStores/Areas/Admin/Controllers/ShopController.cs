using ChainOfStores.DataAccess.Data;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfStores.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ShopController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Shop> objShopsList = _db.Shops.ToList();
            return View(objShopsList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Shop obj)
        {
            if (ModelState.IsValid)
            {
                _db.Shops.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Shop created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0)
                return NotFound();
            Shop shopFromDb = _db.Shops.FirstOrDefault(x => x.Id == id);
            if (shopFromDb == null)
                return NotFound();
            return View(shopFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Shop obj)
        {
            if (ModelState.IsValid)
            {
                _db.Shops.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Shop updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0)
                return NotFound();
            Shop shopFromDb = _db.Shops.FirstOrDefault(u => u.Id == id);
            if (shopFromDb == null)
                return NotFound();
            return View(shopFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Shop? obj = _db.Shops.FirstOrDefault(s => s.Id == id);
            if (obj == null)
                return NotFound();
            _db.Shops.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Shop deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
