using ChainOfStores.DataAccess.Data;
using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfStores.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SalaryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SalaryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Salary> objSalaryList = _unitOfWork.Salary.GetAll().ToList();
            return View(objSalaryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Salary obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Salary.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Salary created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0)
                return NotFound();
            Salary salaryFromDb = _unitOfWork.Salary.Get(s => s.Id == id);
            if (salaryFromDb == null)
                return NotFound();
            return View(salaryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Salary obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Salary.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Salary updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0)
                return NotFound();
            Salary salaryFromDb = _unitOfWork.Salary.Get(u => u.Id == id);
            if (salaryFromDb == null)
                return NotFound();
            return View(salaryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Salary? obj = _unitOfWork.Salary.Get(u => u.Id == id);
            if (obj == null)
                return NotFound();
            _unitOfWork.Salary.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Salary deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
