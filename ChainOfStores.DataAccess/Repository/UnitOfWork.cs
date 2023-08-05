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
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IEmployeeRepository Employee { get; private set; }
        public IBakeryRepository Bakery { get; private set; }
        public IRoleRepository Role { get; private set; }
        public ISalaryRepository Salary { get; private set; }
        public IShopRepository Shop { get; private set; }
        public IStorageRepository Storage { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Employee = new EmployeeRepository(_db);
            Bakery = new BakeryRepository(_db);
            Role = new RoleRepository(_db);
            Salary = new SalaryRepository(_db);
            Shop = new ShopRepository(_db);
            Storage = new StorageRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
