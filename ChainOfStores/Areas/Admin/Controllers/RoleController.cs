using ChainOfStores.DataAccess.Data;
using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfStores.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Role> objRoleList = _unitOfWork.Role.GetAll().ToList();
            return View(objRoleList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Role.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Role created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0)
                return NotFound();
            Role roleFromDb = _unitOfWork.Role.Get(x => x.Id == id);
            if (roleFromDb == null)
                return NotFound();
            return View(roleFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Role obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Role.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Role updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0)
                return NotFound();
            Role roleFromDb = _unitOfWork.Role.Get(u => u.Id == id);
            if (roleFromDb == null)
                return NotFound();
            return View(roleFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Role? obj = _unitOfWork.Role.Get(u => u.Id == id);
            if (obj == null)
                return NotFound();
            _unitOfWork.Role.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Role deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
