using ChainOfStores.DataAccess.Data;
using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;

namespace ChainOfStores.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository db)
        {
            _employeeRepository = db;
        }
        public IActionResult Index()
        {
            List<Employee> objEmployeeList = _employeeRepository.GetAll().ToList();
            return View(objEmployeeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(obj);
                _employeeRepository.Save();
                TempData["success"] = "Employee added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0)
                return NotFound();
            Employee employeeFromDb = _employeeRepository.Get(x => x.Id == id);
            if (employeeFromDb == null)
                return NotFound();
            return View(employeeFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(obj);
                _employeeRepository.Save();
                TempData["success"] = "Employee updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if(id == 0)
                return NotFound();
            Employee employeeFromDb = _employeeRepository.Get(u=>u.Id == id);
            if(employeeFromDb == null)
                return NotFound();
            return View(employeeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Employee? obj = _employeeRepository.Get(u=> u.Id == id);
            if(obj == null)
                return NotFound();
            _employeeRepository.Remove(obj);
            _employeeRepository.Save();
            TempData["success"] = "Employee deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
