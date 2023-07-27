using ChainOfStores.Data;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace ChainOfStores.Controllers
{
    public class StorageController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StorageController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Shop> objShopsList = _db.Shops.ToList();
            List<Storage> objStorageList= _db.Storages.ToList();
            return View(objStorageList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Storage obj)
        {
            List<Shop> shops=_db.Shops.ToList();
            List<Storage> storages= _db.Storages.ToList();
            if(ModelState.IsValid)
            {
                if (storages.Count() < shops.Count())
                {
                    _db.Storages.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("ShopId", "The all shops already have storages");
                }
            }
            
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==0)
                return NotFound();
            Storage storageFromDb = _db.Storages.FirstOrDefault(s => s.Id==id);
            if (storageFromDb == null)
                return NotFound();
            return View(storageFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Storage obj)
        {
            if (ModelState.IsValid)
            {
                _db.Storages.Update(obj);
                _db.SaveChanges(); 
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            List<Shop> shopsFromDb = _db.Shops.ToList();
            if(id==0)
                return NotFound();
            Storage storageFromDb = _db.Storages.FirstOrDefault(u=>u.Id==id);
            if(storageFromDb == null)
                return NotFound();
            return View(storageFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Storage? obj = _db.Storages.FirstOrDefault(u=>u.Id == id);
            if (obj == null)
                return NotFound();
            _db.Storages.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
