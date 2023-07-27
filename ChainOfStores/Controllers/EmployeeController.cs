using ChainOfStores.Data;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Xml.Linq;

namespace ChainOfStores.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Employee> objEmployeesList = _db.Employees.ToList();
            List<Salary> objSalariesList = _db.Salaries.ToList();
            List<Role> objRolesList = _db.Roles.ToList();
            List<Bakery> objBakeriesList = _db.Bakeries.ToList();
            List<Shop> objShopsList = _db.Shops.ToList();

            foreach (var objEmployee in objEmployeesList)
            {
                for (int j = 1; j <= objSalariesList.Count; j++)
                {
                    if (objEmployee.SalaryId == j)
                    {
                        //For Manager role
                        if (objEmployee.RoleId == 1)
                        {
                            int result = DateTime.Now.Year - objEmployee.DateOfEmployment.Year;
                            objEmployee.SalaryId = result * 20 + objSalariesList[j - 1].BaseSalary;
                        }
                        else
                        {
                            int result = DateTime.Now.Year - objEmployee.DateOfEmployment.Year;
                            objEmployee.SalaryId = result * 10 + objSalariesList[j - 1].BaseSalary;
                        }
                    }
                }
            }

            return View(objEmployeesList);
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
                _db.Employees.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0)
                return NotFound();
            Employee employeeFromDb = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (employeeFromDb == null)
                return NotFound();
            return View(employeeFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges(true);
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if(id == 0)
                return NotFound();
            Employee employeeFromDb = _db.Employees.FirstOrDefault(u=>u.Id == id);
            if(employeeFromDb == null)
                return NotFound();
            return View(employeeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Employee? obj = _db.Employees.FirstOrDefault(u=> u.Id == id);
            if(obj == null)
                return NotFound();
            _db.Employees.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
