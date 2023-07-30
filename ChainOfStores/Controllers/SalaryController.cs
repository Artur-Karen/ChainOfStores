using ChainOfStores.DataAccess.Data;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfStores.Controllers
{
    public class SalaryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SalaryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Salary> objSalaryList = _db.Salaries.ToList();
            return View(objSalaryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Salary obj)
        {
            if(ModelState.IsValid)
            {
                _db.Salaries.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Salary created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==0)
                return NotFound();
            Salary salaryFromDb = _db.Salaries.FirstOrDefault(s => s.Id == id);
            if(salaryFromDb==null)
                return NotFound();
            return View(salaryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Salary obj)
        {
            if(ModelState.IsValid)
            {
                _db.Salaries.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Salary updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id==0)
                return NotFound();
            Salary salaryFromDb = _db.Salaries.FirstOrDefault(u=>u.Id==id);
            if(salaryFromDb==null)
                return NotFound();
            return View(salaryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost (int? id)
        {
            Salary? obj = _db.Salaries.FirstOrDefault(u=>u.Id == id);
            if (obj==null)
                return NotFound();
            _db.Salaries.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Salary deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
