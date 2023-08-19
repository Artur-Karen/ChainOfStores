using ChainOfStores.DataAccess.Data;
using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using ChainOfStores.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Xml.Linq;

namespace ChainOfStores.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            //List<Role> roles = _unitOfWork.Role.GetAll().ToList();
            //List<Salary> salaries = _unitOfWork.Salary.GetAll().ToList();
            //List<Employee> EmployeeList = _unitOfWork.Employee.GetAll().ToList();
            //foreach(var Employee in EmployeeList)
            //{
            //    for(int i = 1; i <= salaries.Count; i++)
            //    {
            //        if(Employee.SalaryId == i)
            //        {
            //            if (Employee.Role.Name=="Manager")
            //            {
            //                int seniority = DateTime.Now.Year - Employee.DateOfEmployment.Year;
            //                Employee.SalaryId = seniority * 15 + salaries[i-1].BaseSalary;
            //            }
            //            else
            //            {
            //                int seniority = DateTime.Now.Year - Employee.DateOfEmployment.Year;
            //                Employee.SalaryId = seniority * 10 + salaries[i - 1].BaseSalary;
            //            }
            //        }
            //    }
            //}
     
            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll(includeProperties:"Salary,Role").ToList();
            return View(objEmployeeList);
        }

        public IActionResult Upsert(int? id)
        {
            EmployeeVM employeeVM = new()
            {
                SalaryList = _unitOfWork.Salary.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                RoleList = _unitOfWork.Role.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                ShopList = _unitOfWork.Shop.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                StorageList = _unitOfWork.Storage.GetAll().Select(u => new SelectListItem
                {
                    Text = u.PhoneNumber,
                    Value = u.Id.ToString(),
                }),
                BakeryList = _unitOfWork.Bakery.GetAll().Select(u => new SelectListItem
                {
                    Text = u.PhoneNumber,
                    Value = u.Id.ToString(),
                }),

                Employee = new Employee()
            };
            if (id == null || id == 0)
            {
                //Create
                return View(employeeVM);
            }
            else
            {
                //Update
                employeeVM.Employee = _unitOfWork.Employee.Get(u => u.Id == id);
                return View(employeeVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(EmployeeVM employeeVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string employeePath = Path.Combine(wwwRootPath, @"images\employee");

                    if (!string.IsNullOrEmpty(employeeVM.Employee.ImageURL))
                    {    //delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, employeeVM.Employee.ImageURL.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(employeePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    employeeVM.Employee.ImageURL = @"\images\employee\" + fileName;
                }
                
                if (employeeVM.Employee.Id == 0)
                {
                    _unitOfWork.Employee.Add(employeeVM.Employee);
                }
                else
                {
                    _unitOfWork.Employee.Update(employeeVM.Employee);
                }
                _unitOfWork.Save();
                if (employeeVM.Employee.Id == 0)
                    TempData["success"] = "Employee added successfully";
                else
                    TempData["success"] = "Employee updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                employeeVM.SalaryList = _unitOfWork.Salary.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                employeeVM.RoleList = _unitOfWork.Role.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                employeeVM.ShopList = _unitOfWork.Shop.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                employeeVM.StorageList = _unitOfWork.Shop.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                employeeVM.BakeryList = _unitOfWork.Shop.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                return View(employeeVM);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> objEmployeeList = _unitOfWork.Employee.GetAll(includeProperties: "Salary,Role").ToList();
            List<Role> roles = _unitOfWork.Role.GetAll().ToList();
            List<Salary> salaries = _unitOfWork.Salary.GetAll().ToList();
            
            foreach (var Employee in objEmployeeList)
            {
                for (int i = 1; i <= salaries.Count; i++)
                {
                    if (Employee.SalaryId == i)
                    {
                        if (Employee.RoleId == 1)
                        {
                            int seniority = DateTime.Now.Year - Employee.DateOfEmployment.Year;
                            Employee.SalaryId = seniority * 15 + salaries[i - 1].BaseSalary;
                        }
                        else
                        {
                            int seniority = DateTime.Now.Year - Employee.DateOfEmployment.Year;
                            Employee.SalaryId = seniority * 10 + salaries[i - 1].BaseSalary;
                        }
                    }
                }
            }
            
            return Json(new { data = objEmployeeList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var employeeToBeDeleted = _unitOfWork.Employee.Get(u => u.Id == id);
            if (employeeToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, employeeToBeDeleted.ImageURL.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Employee.Remove(employeeToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
