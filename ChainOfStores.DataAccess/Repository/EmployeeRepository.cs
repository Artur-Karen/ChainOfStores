using ChainOfStores.DataAccess.Data;
using ChainOfStores.DataAccess.Repository.IRepository;
using ChainOfStores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfStores.DataAccess.Repository
{
    public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
    {
        private ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public void Update(Employee obj) 
        {
            _db.Employees.Update(obj);
        }
    }
}
