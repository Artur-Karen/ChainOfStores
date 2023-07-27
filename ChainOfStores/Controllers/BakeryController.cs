using ChainOfStores.Data;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ChainOfStores.Controllers
{
    public class BakeryController : Controller
    {
        private readonly ApplicationDbContext _db;
     
        public BakeryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Shop> objShopsList = _db.Shops.ToList();
            List<Bakery> objBakeryList=_db.Bakeries.ToList();
            return View(objBakeryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bakery obj)
        {
            List<Shop> shops = _db.Shops.ToList();
            List<Bakery> bakeries = _db.Bakeries.ToList();
            if (ModelState.IsValid)
            {
                if (bakeries.Count() < shops.Count())
                {
                    _db.Bakeries.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("ShopId", "The all shops already have bakeries");
                }
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id==0)
                return NotFound();
            Bakery bakeryFromDb = _db.Bakeries.FirstOrDefault(b => b.Id == id);
            if (bakeryFromDb==null)
                return NotFound();
            return View(bakeryFromDb);
        }

        [HttpPost]
        public ActionResult Edit(Bakery obj)
        {
            if (ModelState.IsValid)
            {
                _db.Bakeries.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            List<Shop> shopsFromDb = _db.Shops.ToList();
            if(id == 0)
                return NotFound();
            Bakery bakeryFromDb = _db.Bakeries.FirstOrDefault(u=>u.Id == id);
            if(bakeryFromDb==null)
                return NotFound();
            return View(bakeryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Bakery? obj = _db.Bakeries.FirstOrDefault(u=>u.Id==id);
            if (obj==null)
                return NotFound();
            _db.Bakeries.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
