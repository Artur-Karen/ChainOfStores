using ChainOfStores.DataAccess.Data;
using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfStores.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShopController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public IActionResult Index()
        {
            List<Shop> objShopsList = _unitOfWork.Shop.GetAll().ToList();
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
                _unitOfWork.Shop.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Shop created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0)
                return NotFound();
            Shop shopFromDb = _unitOfWork.Shop.Get(x => x.Id == id);
            if (shopFromDb == null)
                return NotFound();
            return View(shopFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Shop obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Shop.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Shop updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0)
                return NotFound();
            Shop shopFromDb = _unitOfWork.Shop.Get(u => u.Id == id);
            if (shopFromDb == null)
                return NotFound();
            return View(shopFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Shop? obj = _unitOfWork.Shop.Get(s => s.Id == id);
            if (obj == null)
                return NotFound();
            _unitOfWork.Shop.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Shop deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
