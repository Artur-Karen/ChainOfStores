using ChainOfStores.DataAccess.Data;
using ChainOfStores.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfStores.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RoleController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Role> objRoleList = _db.Roles.ToList();
            return View(objRoleList);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Role obj) 
        {
            if(ModelState.IsValid)
            {
                _db.Roles.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Role created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == 0)
                return NotFound();
            Role roleFromDb = _db.Roles.FirstOrDefault(x => x.Id == id);
            if(roleFromDb == null)
                return NotFound();
            return View(roleFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Role obj) 
        {
            if(ModelState.IsValid)
            {
                _db.Roles.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Role updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0)
                return NotFound();
            Role roleFromDb = _db.Roles.FirstOrDefault(u=>u.Id == id);
            if (roleFromDb == null)
                return NotFound();
            return View(roleFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Role? obj = _db.Roles.FirstOrDefault(u=> u.Id == id);
            if(obj == null)
                return NotFound();
            _db.Roles.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Role deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
