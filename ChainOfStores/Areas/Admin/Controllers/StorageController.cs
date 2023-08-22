using ChainOfStores.DataAccess.Data;
using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace ChainOfStores.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StorageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StorageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Shop> objShopList = _unitOfWork.Shop.GetAll().ToList();
            List<Storage> objStorageList = _unitOfWork.Storage.GetAll().ToList();
            return View(objStorageList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Storage obj)
        {
            List<Shop> shops = _unitOfWork.Shop.GetAll().ToList();
            List<Storage> storages = _unitOfWork.Storage.GetAll().ToList();
            if (ModelState.IsValid)
            {
                if (storages.Count() < shops.Count())
                {
                    _unitOfWork.Storage.Add(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Storage created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "All shops already have storages";
                    return RedirectToAction("Index");
                    //ModelState.AddModelError("ShopId", "The all shops already have storages");
                }
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0)
                return NotFound();
            Storage storageFromDb = _unitOfWork.Storage.Get(s => s.Id == id);
            if (storageFromDb == null)
                return NotFound();
            return View(storageFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Storage obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Storage.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Storage updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            List<Shop> shopsFromDb = _unitOfWork.Shop.GetAll().ToList();
            if (id == 0)
                return NotFound();
            Storage storageFromDb = _unitOfWork.Storage.Get(u => u.Id == id);
            if (storageFromDb == null)
                return NotFound();
            return View(storageFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Storage? obj = _unitOfWork.Storage.Get(u => u.Id == id);
            if (obj == null)
                return NotFound();
            _unitOfWork.Storage.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Storage deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
