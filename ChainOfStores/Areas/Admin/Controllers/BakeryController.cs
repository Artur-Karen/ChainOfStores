using ChainOfStores.DataAccess.Data;
using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ChainOfStores.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BakeryController : Controller
    {
        private readonly IUnitOfWork _unitOFWork;

        public BakeryController(IUnitOfWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }

        public IActionResult Index()
        {
            List<Shop> objShopsList = _unitOFWork.Shop.GetAll().ToList();
            List<Bakery> objBakeryList = _unitOFWork.Bakery.GetAll().ToList();
            return View(objBakeryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bakery obj)
        {
            List<Shop> shops = _unitOFWork.Shop.GetAll().ToList();
            List<Bakery> bakeries = _unitOFWork.Bakery.GetAll().ToList();
            if (ModelState.IsValid)
            {
                if (bakeries.Count() < shops.Count())
                {
                    _unitOFWork.Bakery.Add(obj);
                    _unitOFWork.Save();
                    TempData["success"] = "Bakery created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    //ModelState.AddModelError("ShopId", "The all shops already have bakeries");
                    TempData["error"] = "All shops already have bakeries";
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0)
                return NotFound();
            Bakery bakeryFromDb = _unitOFWork.Bakery.Get(b => b.Id == id);
            if (bakeryFromDb == null)
                return NotFound();
            return View(bakeryFromDb);
        }

        [HttpPost]
        public ActionResult Edit(Bakery obj)
        {
            if (ModelState.IsValid)
            {
                _unitOFWork.Bakery.Update(obj);
                _unitOFWork.Save();
                TempData["success"] = "Bakery updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            List<Shop> shopsFromDb = _unitOFWork.Shop.GetAll().ToList();
            if (id == 0)
                return NotFound();
            Bakery bakeryFromDb = _unitOFWork.Bakery.Get(u => u.Id == id);
            if (bakeryFromDb == null)
                return NotFound();
            return View(bakeryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Bakery? obj = _unitOFWork.Bakery.Get(u => u.Id == id);
            if (obj == null)
                return NotFound();
            _unitOFWork.Bakery.Remove(obj);
            _unitOFWork.Save();
            TempData["success"] = "Bakery deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
