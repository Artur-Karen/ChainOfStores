using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChainOfStores.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Role> roles = _unitOfWork.Role.GetAll().ToList();
            List<Salary> salaries = _unitOfWork.Salary.GetAll().ToList();
            List<Employee> EmployeeList = _unitOfWork.Employee.GetAll().ToList();
            foreach (var Employee in EmployeeList)
            {
                for (int i = 1; i <= salaries.Count; i++)
                {
                    if (Employee.SalaryId == i)
                    {
                        if (Employee.Role.Name == "Manager")
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

            IEnumerable<Employee> employeeList = _unitOfWork.Employee.GetAll(includeProperties: "Salary,Role");
            return View(employeeList);
        }

        public IActionResult Details(int id) 
        {
            List<Role> roles = _unitOfWork.Role.GetAll().ToList();
            List<Salary> salaries = _unitOfWork.Salary.GetAll().ToList();
            List<Employee> EmployeeList = _unitOfWork.Employee.GetAll().ToList();
            foreach (var Employee in EmployeeList)
            {
                for (int i = 1; i <= salaries.Count; i++)
                {
                    if (Employee.SalaryId == i)
                    {
                        if (Employee.Role.Name == "Manager")
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
            Employee employee = _unitOfWork.Employee.Get(u=>u.Id == id, includeProperties: "Salary,Role");
            return View(employee);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}